using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;
using FacturaSite.DataAccess;
using FacturaSite.Models;

namespace FacturaSite.BusinessLogic
{
    public class ComprobantesBusiness
    {
        private static String CadenaDeConexion = ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString;

        /// <summary>
        /// Validar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 26 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 26 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Boolean ExisteComprobante(string rutaNombreArchivo)
        {
            // Instancía la clase de acceso a datos
            AdsertiSqlDataAccess adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);

            try
            {
                //Abre la conexion
                adsertiDataAccess.AbrirConexion();
                //¿Existe el documento?
                Comprobantes comprobantesBuscado = Utilidades.IdentificaEmisorYDocumento(rutaNombreArchivo);
                var comprobanteDataAccess = new ComprobantesClass();

                Comprobantes comprobantesEncontrado = comprobanteDataAccess.Cargar(comprobantesBuscado.Emisores.Personas.Rfc, comprobantesBuscado.Folio, comprobantesBuscado.Serie, adsertiDataAccess);

                return (comprobantesEncontrado != null);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public void Validar(Models.Comprobantes Comprobantes)

        /// <summary>
        /// Agregar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public void Agregar(Models.Comprobantes comprobantes)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);

            try
            {
                //Abre la conexion
                adsertiDataAccess.AbrirConexion();
                adsertiDataAccess.AbrirTransaccion();
                
                //----------//
                //--EMISOR--//
                //----------//

                //Existe EMISOR
                DataAccess.PersonasClass personaEmisorDataAccess = new DataAccess.PersonasClass();
                Models.Personas personasEmisor = personaEmisorDataAccess.Cargar(comprobantes.Emisores.Personas.Rfc, adsertiDataAccess);

                comprobantes.Emisores.Personas.PersonaId = (personasEmisor == null) ? personaEmisorDataAccess.Agregar(comprobantes.Emisores.Personas, adsertiDataAccess) : personasEmisor.PersonaId;

                //Domicilios Fiscal EMISOR
                DataAccess.DomiciliosClass domicilioFiscalDataAccess = new DataAccess.DomiciliosClass();
                comprobantes.Emisores.DomiciliosFiscal.DomicilioId = domicilioFiscalDataAccess.Agregar(comprobantes.Emisores.DomiciliosFiscal, adsertiDataAccess);

                //Domicilios Expedicion EMISOR
                DataAccess.DomiciliosClass domicilioExpedicionDataAccess = new DataAccess.DomiciliosClass();
                comprobantes.Emisores.DomiciliosExpedicion.DomicilioId = domicilioExpedicionDataAccess.Agregar(comprobantes.Emisores.DomiciliosExpedicion, adsertiDataAccess);

                //Agregar EMISOR
                DataAccess.EmisoresClass emisorDataAccess = new DataAccess.EmisoresClass();
                comprobantes.Emisores.EmisorId = emisorDataAccess.Agregar(comprobantes.Emisores, adsertiDataAccess);


                //Regimenes Fiscales Emisores
                DataAccess.RegimenesFiscalesClass regimenFiscalDataAccess = new DataAccess.RegimenesFiscalesClass();
                DataAccess.EmisoresRegimenesFiscalesClass emisoresRegimenesFiscalesDataAccess = new EmisoresRegimenesFiscalesClass();
                
                foreach (RegimenesFiscales regimenFiscalItem in comprobantes.Emisores.RegimenesFiscales)
                {
                    RegimenesFiscales regimenesFiscales = regimenFiscalDataAccess.Cargar(regimenFiscalItem.RegimenFiscal, adsertiDataAccess);
                    Int32 regimenFiscalId;

                    //Existe regimen Fiscal
                    regimenFiscalId = (regimenesFiscales == null) ? regimenFiscalDataAccess.Agregar(regimenFiscalItem, adsertiDataAccess) : regimenesFiscales.RegimenFiscalId;

                    //Inserta relacion RegimenesFiscales-Emisores
                    Models.EmisoresRegimenesFiscales emisoresRegimenesFiscales = new EmisoresRegimenesFiscales
                    {
                        EmisorId = comprobantes.Emisores.EmisorId,
                        RegimenFiscalId = regimenFiscalId,
                        UsuarioAltaId = regimenFiscalItem.UsuarioAltaId
                    };

                    emisoresRegimenesFiscalesDataAccess.Agregar(emisoresRegimenesFiscales, adsertiDataAccess);
                } // foreach (RegimenesFiscales regimenFiscalItem in Comprobantes.Emisores.RegimenesFiscales)

                //------------//
                //--RECEPTOR--//
                //------------//

                //Existe RECEPTOR:
                DataAccess.PersonasClass personaReceptorDataAccess = new DataAccess.PersonasClass();
                Models.Personas personasReceptor = personaEmisorDataAccess.Cargar(comprobantes.Receptores.Personas.Rfc, adsertiDataAccess);
                
                comprobantes.Receptores.Personas.PersonaId = personasReceptor == null ? personaReceptorDataAccess.Agregar(comprobantes.Receptores.Personas, adsertiDataAccess) : personasReceptor.PersonaId;

                //Domicilios RECEPTOR
                DataAccess.DomiciliosClass domicilioReceptorlDataAccess = new DataAccess.DomiciliosClass();
                comprobantes.Receptores.Domicilios.DomicilioId = domicilioReceptorlDataAccess.Agregar(comprobantes.Receptores.Domicilios, adsertiDataAccess);

                //Agregar RECEPTOR
                DataAccess.ReceptoresClass receptorDataAccess = new DataAccess.ReceptoresClass();
                comprobantes.Receptores.ReceptorId = receptorDataAccess.Agregar(comprobantes.Receptores, adsertiDataAccess);


                //---------------//
                //--COMPROBANTE--//
                //---------------//

                //Agregar COMPROBANTE
                DataAccess.ComprobantesClass comprobanteDataAccess = new ComprobantesClass();
                comprobantes.ComprobanteId = comprobanteDataAccess.Agregar(comprobantes, adsertiDataAccess);

                //-------------//
                //--CONCEPTOS--//
                //-------------//

                //Agregar CONCEPTOS
                DataAccess.ConceptosClass conceptoDataAccess = new ConceptosClass();

                foreach (Models.Conceptos concepto in comprobantes.Conceptos)
                {
                    concepto.ComprobanteId = comprobantes.ComprobanteId;
                    conceptoDataAccess.Agregar(concepto, adsertiDataAccess);
                }

                //--------------------------//
                //--COMPROBANTES IMPUESTOS--//
                //--------------------------//

                //Agregar ComprobantesImpuestos
                DataAccess.ComprobantesImpuestosClass comprobantesImpuestosDataAccess = new DataAccess.ComprobantesImpuestosClass();
                foreach (Models.ComprobanteImpuesto comprobanteImpuesto in comprobantes.ComprobantesImpuestos)
                {
                    comprobanteImpuesto.ComprobanteId = comprobantes.ComprobanteId;
                    comprobantesImpuestosDataAccess.Agregar(comprobanteImpuesto, adsertiDataAccess);
                }

                //-------------------------//
                //--TIMBRE FISCAL DIGITAL--//
                //-------------------------//

                //Agregar Timbre Fiscal Digital
                DataAccess.TimbresFiscalesDigitalesClass timbreFiscalDigitalDataAccess = new TimbresFiscalesDigitalesClass();
                comprobantes.TimbresFiscalesDigitales.ComprobanteId = comprobantes.ComprobanteId;
                comprobantes.TimbresFiscalesDigitales.TimbreFiscalDigitalId = timbreFiscalDigitalDataAccess.Agregar(comprobantes.TimbresFiscalesDigitales, adsertiDataAccess);

                adsertiDataAccess.CerrarTransaccion();
            }
            catch (Exception ex)
            {
                adsertiDataAccess.CancelarTransaccion();
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        }

        /// <summary>
        /// VincularBitacora()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public void VincularBitacora(Int32 bitacoraId, Int32 usuarioAltaId)
        {
            //Instacia la clase de acceso a datos
            AdsertiSqlDataAccess adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);

            try
            {
                //Abre la conexion
                adsertiDataAccess.AbrirConexion();
                adsertiDataAccess.AbrirTransaccion();

                BitacoraCargasClass bitacoraCargasDataAccess = new BitacoraCargasClass();
                ComprobantesClass comprobantesDataAccess = new ComprobantesClass();

                var bitacoraCarga = bitacoraCargasDataAccess.Cargar(bitacoraId, adsertiDataAccess);

                if (bitacoraCarga.Extension == ".pdf")
                {
                   Comprobantes comprobantes =  comprobantesDataAccess.ComprobanteArchivoXML(bitacoraCarga.NombreArchivo, adsertiDataAccess);
                    if (comprobantes != null)
                        ComprobantesClass.VincularPDF(comprobantes, bitacoraCarga, usuarioAltaId, adsertiDataAccess);
                }
                adsertiDataAccess.CerrarTransaccion();
            }
            catch (Exception ex)
            {
                adsertiDataAccess.CancelarTransaccion();
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        }

        /// <summary>
        /// ComprobantesSinEvidencia()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public List<Comprobantes> ComprobantesSinEvidencia()
        {
            //Instacia la clase de acceso a datos
            AdsertiSqlDataAccess adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);

            try
            {
                //Abre la conexion
                adsertiDataAccess.AbrirConexion();
                adsertiDataAccess.AbrirTransaccion();

                ComprobantesClass comprobantesDataAccess = new ComprobantesClass();

                return comprobantesDataAccess.ComprobantesSinEvidencia(adsertiDataAccess);

            }
            catch (Exception ex)
            {
                adsertiDataAccess.CancelarTransaccion();
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        }

        /// <summary>
        /// ComprobantesPagados()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public List<Comprobantes> ComprobantesConEvidencia()
        {
            //Instacia la clase de acceso a datos
            AdsertiSqlDataAccess adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);

            try
            {
                //Abre la conexion
                adsertiDataAccess.AbrirConexion();
                adsertiDataAccess.AbrirTransaccion();

                ComprobantesClass comprobantesDataAccess = new ComprobantesClass();
                
                List<Comprobantes> comprobantes = comprobantesDataAccess.ComprobantesConEvidencia(adsertiDataAccess);
                EvidenciasBusiness evidenciasBusiness = new EvidenciasBusiness();
                BitacoraCargasBusiness bitacoraCargasBusiness = new BitacoraCargasBusiness();

                //Carga datos de la Evidencia Vinculada
                foreach (Comprobantes comprobante in comprobantes)
                {
                    comprobante.Evidencia = evidenciasBusiness.Cargar(comprobante.Evidencia.EvidenciaId);
                }

                return comprobantes;
            }
            catch (Exception ex)
            {
                adsertiDataAccess.CancelarTransaccion();
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        }

    }
}
