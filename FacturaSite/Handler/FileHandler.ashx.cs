using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using FacturaSite.BusinessLogic;
using FacturaSite.DataAccess;
using FacturaSite.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FacturaSite.Handler
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    public class FileHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Archivos resultado = null;

            var path = context.Server.MapPath("~/Upload");
            var fileExtension = "";
            var usuarioAltaId = 1;
            var fileName = string.Empty;
            var fullName = string.Empty;
            var onlyName = string.Empty;

            try
            {
                if (context.Request.Files.Count > 0)
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    var files = context.Request.Files;
                    foreach (string key in files)
                    {
                        var file = files[key];

                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            var fileParts = file.FileName.Split(new char[] {'\\'});
                            fileName = fileParts[fileParts.Length - 1];
                        }
                        else
                        {
                            fileName = file.FileName;
                        }

                        fileExtension = Path.GetExtension(fileName);
                        fullName = Path.Combine(path, fileName);
                        onlyName = Path.GetFileNameWithoutExtension(fullName);

                        var extensionEnum = BitacoraCargas.ExtensionArchivo.Invalida;

                        switch (fileExtension)
                        {
                            case ".pdf":
                                extensionEnum = BitacoraCargas.ExtensionArchivo.Pdf;
                                break;
                            case ".xml":
                                extensionEnum = BitacoraCargas.ExtensionArchivo.Xml;
                                break;
                        }


                        if (extensionEnum == BitacoraCargas.ExtensionArchivo.Invalida)
                        {
                            resultado = new Archivos()
                            {
                                NombreArchivo = fileName,
                                Correcto = false,
                                Mensaje = "Archivo con Extensión Inválida.",
                                Fecha = DateTime.Now
                            };

                            return;
                        }

                        //if (!File.Exists(fullName))
                        if(!BitacoraCargasBusiness.Existe(onlyName,extensionEnum))
                        {
                            //Guardar el archivo en el servidor
                            file.SaveAs(fullName);

                            var bitacoraCargasBusiness = new BitacoraCargasBusiness();
                            var bitacoraCargas = new BitacoraCargas()
                            {
                                NombreArchivo = Path.GetFileNameWithoutExtension(fullName),
                                Extension = Path.GetExtension(fullName),
                                UsuarioAltaId = usuarioAltaId
                            };

                            var bitacoraId = bitacoraCargasBusiness.Agregar(bitacoraCargas);

                            //Si es un documento PDF
                            if (extensionEnum == BitacoraCargas.ExtensionArchivo.Pdf)
                            {
                                var comprobantesBusiness = new ComprobantesBusiness();
                                comprobantesBusiness.VincularBitacora(bitacoraId, usuarioAltaId);
                            }

                            //Si es XML procesa como factura
                            if (extensionEnum == BitacoraCargas.ExtensionArchivo.Xml)
                            {
                                var comprobantesBusiness = new ComprobantesBusiness();
                                var existeComprobante = comprobantesBusiness.ExisteComprobante(fullName);

                                if (!existeComprobante)
                                {
                                    //Revisar si existe un pdf con el mismo nombre para vincularlo a la factura
                                    Utilidades.ParseXmlToFactura(fullName, bitacoraId);

                                    //Comprobar si existen PDFs que no esten vinculados a otras facturas y si no, ligarlos a la actual.
                                    var bitacoraPDFMismoNombre = bitacoraCargasBusiness.PDFSinFactura(bitacoraCargas.NombreArchivo);
                                    if (bitacoraPDFMismoNombre != null)
                                        comprobantesBusiness.VincularBitacora(bitacoraPDFMismoNombre.BitacoraCargaId, usuarioAltaId);

                                    resultado = new Archivos()
                                    {
                                        NombreArchivo = fileName,
                                        Correcto = true,
                                        Mensaje = "Archivo guardado correctamente.",
                                        Fecha = DateTime.Now
                                    };
                                }
                                else
                                {
                                    //Marcar como inactivo la entrada en la bitacora
                                    bitacoraCargasBusiness.Eliminar(bitacoraId, usuarioAltaId);
                                    //TODO: Borrar archivo ya que no fue utilizado
                                    resultado = new Archivos()
                                    {
                                        NombreArchivo = fileName,
                                        Correcto = false,
                                        Mensaje = "Comprobante cargado previamente pero con nombre de archivo distinto.",
                                        Fecha = DateTime.Now
                                    };
                                }
                            }
                            else
                            {
                                resultado = new Archivos()
                                {
                                    NombreArchivo = fileName,
                                    Correcto = true,
                                    Mensaje = "Archivo guardado correctamente.",
                                    Fecha = DateTime.Now
                                };
                            }
                        }
                        else
                        {
                            resultado = new Archivos()
                            {
                                NombreArchivo = fileName,
                                Correcto = false,
                                Mensaje = "Archivo previamente cargado.",
                                Fecha = DateTime.Now
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Archivos()
                {
                    NombreArchivo = fileName,
                    Correcto = false,
                    Mensaje = ex.Message,
                    Fecha = DateTime.Now
                };

                //TODO: Validar que este  funcionamiento sea el correcto, que pasa cuando solamente se guarda en bitacora y no se almacena como factura? Eliminar
                //segun pasos alcanzados: 1 = Guardar Bitacora, 2 = Guardar Comprobantes , Vinculación etc...
                //Eliminar arhchivo si ocurre algun error
                if (Directory.Exists(fullName))
                    File.Delete(fullName);

            }
            finally
            {
                if (resultado != null)
                {

                    var defaultJson = JsonConvert.SerializeObject(resultado);
                    if (resultado.Correcto == false)
                    {
                        context.Response.StatusCode = 501;
                        context.Response.StatusDescription = resultado.Mensaje;
                    }
                    else
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.OK;
                    }

                    context.Response.ContentType = "application/json";
                    context.Response.Write(defaultJson);
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}