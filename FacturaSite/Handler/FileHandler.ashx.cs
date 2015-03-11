using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
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
            List<Archivos> resultados = new List<Archivos>();
            string path = context.Server.MapPath("~/Upload");
            string fileExtension = "";
            bool existe = false;
            Int32 usuarioAltaId = 1;
            string fileName = string.Empty;
            string fullName = string.Empty;

            try
            {
                if (context.Request.Files.Count > 0)
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    HttpFileCollection files = context.Request.Files;
                    foreach (string key in files)
                    {
                        HttpPostedFile file = files[key];

                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] fileParts = file.FileName.Split(new char[] {'\\'});
                            fileName = fileParts[fileParts.Length - 1];
                        }
                        else
                        {
                            fileName = file.FileName;
                        }

                        fileExtension = Path.GetExtension(fileName);
                        fullName = Path.Combine(path, fileName);

                        if (!File.Exists(fullName))
                        {
                            //Guardar el archivo en el servidor
                            file.SaveAs(fullName);

                            BitacoraCargasBusiness bitacoraCargasBusiness = new BitacoraCargasBusiness();
                            BitacoraCargas bitacoraCargas = new BitacoraCargas()
                            {
                                NombreArchivo = Path.GetFileNameWithoutExtension(fullName),
                                Extension = Path.GetExtension(fullName),
                                UsuarioAltaId = usuarioAltaId
                            };

                            Int32 bitacoraId = bitacoraCargasBusiness.Agregar(bitacoraCargas);

                            //Si es un documento PDF
                            if (fileExtension == ".pdf")
                            {
                                ComprobantesBusiness comprobantesBusiness = new ComprobantesBusiness();
                                comprobantesBusiness.VincularBitacora(bitacoraId, usuarioAltaId);
                            }

                            //Si es XML procesa como factura
                            if (fileExtension == ".xml")
                            {
                                ComprobantesBusiness comprobantesBusiness = new ComprobantesBusiness();
                                bool existeComprobante = comprobantesBusiness.ExisteComprobante(fullName);

                                if (!existeComprobante)
                                {
                                    //Revisar si existe un pdf con el mismo nombre para vincularlo a la factura
                                    Utilidades.ParseXmlToFactura(fullName, bitacoraId);

                                    //Comprobar si existen PDFs que no esten vinculados a otras facturas y si no, ligarlos a la actual.
                                    BitacoraCargas bitacoraPDFMismoNombre = bitacoraCargasBusiness.PDFSinFactura(bitacoraCargas.NombreArchivo);
                                    if (bitacoraPDFMismoNombre != null)
                                        comprobantesBusiness.VincularBitacora(bitacoraPDFMismoNombre.BitacoraCargaId, usuarioAltaId);

                                    resultados.Add(new Archivos()
                                    {
                                        NombreArchivo = fileName,
                                        Correcto = true,
                                        Mensaje = "Documento guardado correctamente.",
                                        Fecha = DateTime.Now
                                    });
                                }
                                else
                                {
                                    //TODO: Borrar archivo ya que no fue utilizado
                                    resultados.Add(new Archivos()
                                    {
                                        NombreArchivo = fileName,
                                        Correcto = false,
                                        Mensaje = "El documento ya fue previamente cargado.",
                                        Fecha = DateTime.Now
                                    });
                                }
                            }
                            else
                            {
                                resultados.Add(new Archivos()
                                {
                                    NombreArchivo = fileName,
                                    Correcto = true,
                                    Mensaje = "Documento guardado correctamente.",
                                    Fecha = DateTime.Now
                                });
                            }
                        }
                        else
                        {
                            resultados.Add(new Archivos()
                            {
                                NombreArchivo = fileName,
                                Correcto = false,
                                Mensaje = "El documento ya fue previamente cargado.",
                                Fecha = DateTime.Now
                            });
                        }
                    }

                    //string defaultJson = JsonConvert.SerializeObject(resultados);

                    //context.Response.ContentType = "application/json";
                    //context.Response.Write(defaultJson);
                }
            }
            catch (Exception ex)
            {
                resultados.Add(new Archivos()
                {
                    NombreArchivo = fileName,
                    Correcto = false,
                    Mensaje = ex.Message,
                    Fecha = DateTime.Now
                });

                //TODO: Validar que este  funcionamiento sea el correcto, que pasa cuando solamente se guarda en bitacora y no se almacena como factura? Eliminar
                //segun pasos alcanzados: 1 = Guardar Bitacora, 2 = Guardar Comprobantes , Vinculación etc...
                //Eliminar arhchivo si ocurre algun error
                if (Directory.Exists(fullName))
                    File.Delete(fullName);

            }
            finally
            {
                var defaultJson = JsonConvert.SerializeObject(resultados);

                context.Response.ContentType = "application/json";
                context.Response.Write(defaultJson);
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