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
    public class ComprobanteBusiness
    {
        private static String CadenaDeConexion = ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString;

        /// <summary>
        /// Validar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 26 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 26 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
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
                Comprobante comprobanteBuscado = Utilidades.IdentificaEmisorYDocumento(rutaNombreArchivo);
                var comprobanteDataAccess = new ComprobantesClass();

                Comprobante comprobanteEncontrado = comprobanteDataAccess.Cargar(comprobanteBuscado.Emisor.Persona.Rfc, comprobanteBuscado.Folio, comprobanteBuscado.Serie, adsertiDataAccess);

                return (comprobanteEncontrado != null);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public void Validar(Models.Comprobante comprobante)

        /// <summary>
        /// Agregar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public void Agregar(Models.Comprobante comprobante)
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
                Models.Persona personaEmisor = personaEmisorDataAccess.Cargar(comprobante.Emisor.Persona.Rfc, adsertiDataAccess);

                comprobante.Emisor.Persona.PersonaId = (personaEmisor == null) ? personaEmisorDataAccess.Agregar(comprobante.Emisor.Persona, adsertiDataAccess) : personaEmisor.PersonaId;

                //Domicilio Fiscal EMISOR
                DataAccess.DomiciliosClass domicilioFiscalDataAccess = new DataAccess.DomiciliosClass();
                comprobante.Emisor.DomicilioFiscal.DomicilioId = domicilioFiscalDataAccess.Agregar(comprobante.Emisor.DomicilioFiscal, adsertiDataAccess);

                //Domicilio Expedicion EMISOR
                DataAccess.DomiciliosClass domicilioExpedicionDataAccess = new DataAccess.DomiciliosClass();
                comprobante.Emisor.DomicilioExpedicion.DomicilioId = domicilioExpedicionDataAccess.Agregar(comprobante.Emisor.DomicilioExpedicion, adsertiDataAccess);

                //Agregar EMISOR
                DataAccess.EmisoresClass emisorDataAccess = new DataAccess.EmisoresClass();
                comprobante.Emisor.EmisorId = emisorDataAccess.Agregar(comprobante.Emisor, adsertiDataAccess);


                //Regimenes Fiscales Emisor
                DataAccess.RegimenesFiscalesClass regimenFiscalDataAccess = new DataAccess.RegimenesFiscalesClass();
                DataAccess.EmisoresRegimenesFiscalesClass emisoresRegimenesFiscalesDataAccess = new EmisoresRegimenesFiscalesClass();
                
                foreach (RegimenFiscal regimenFiscalItem in comprobante.Emisor.RegimenesFiscales)
                {
                    Models.RegimenFiscal regimenFiscal = regimenFiscalDataAccess.Cargar(regimenFiscalItem.RegimenFiscalDescripcion, adsertiDataAccess);
                    Int32 regimenFiscalId;

                    //Existe regimen Fiscal
                    regimenFiscalId = (regimenFiscal == null) ? regimenFiscalDataAccess.Agregar(regimenFiscalItem, adsertiDataAccess) : regimenFiscal.RegimenFiscalId;

                    //Inserta relacion RegimenesFiscales-Emisores
                    Models.EmisorRegimenFiscal emisorRegimenFiscal = new EmisorRegimenFiscal
                    {
                        EmisorId = comprobante.Emisor.EmisorId,
                        RegimenFiscalId = regimenFiscalId,
                        UsuarioAltaId = regimenFiscalItem.UsuarioAltaId
                    };

                    emisoresRegimenesFiscalesDataAccess.Agregar(emisorRegimenFiscal, adsertiDataAccess);
                } // foreach (RegimenFiscal regimenFiscalItem in comprobante.Emisor.RegimenesFiscales)

                //------------//
                //--RECEPTOR--//
                //------------//

                //Existe RECEPTOR:
                DataAccess.PersonasClass personaReceptorDataAccess = new DataAccess.PersonasClass();
                Models.Persona personaReceptor = personaEmisorDataAccess.Cargar(comprobante.Receptor.Persona.Rfc, adsertiDataAccess);
                
                comprobante.Receptor.Persona.PersonaId = personaReceptor == null ? personaReceptorDataAccess.Agregar(comprobante.Receptor.Persona, adsertiDataAccess) : personaReceptor.PersonaId;

                //Domicilio RECEPTOR
                DataAccess.DomiciliosClass domicilioReceptorlDataAccess = new DataAccess.DomiciliosClass();
                comprobante.Receptor.Domicilio.DomicilioId = domicilioReceptorlDataAccess.Agregar(comprobante.Receptor.Domicilio, adsertiDataAccess);

                //Agregar RECEPTOR
                DataAccess.ReceptoresClass receptorDataAccess = new DataAccess.ReceptoresClass();
                comprobante.Receptor.ReceptorId = receptorDataAccess.Agregar(comprobante.Receptor, adsertiDataAccess);


                //---------------//
                //--COMPROBANTE--//
                //---------------//

                //Agregar COMPROBANTE
                DataAccess.ComprobantesClass comprobanteDataAccess = new ComprobantesClass();
                comprobante.ComprobanteId = comprobanteDataAccess.Agregar(comprobante, adsertiDataAccess);

                //-------------//
                //--CONCEPTOS--//
                //-------------//

                //Agregar CONCEPTOS
                DataAccess.ConceptosClass conceptoDataAccess = new ConceptosClass();

                foreach (Models.Concepto concepto in comprobante.Conceptos)
                {
                    concepto.ComprobanteId = comprobante.ComprobanteId;
                    conceptoDataAccess.Agregar(concepto, adsertiDataAccess);
                }

                //--------------------------//
                //--COMPROBANTES IMPUESTOS--//
                //--------------------------//

                //Agregar ComprobantesImpuestos
                DataAccess.ComprobantesImpuestosClass comprobantesImpuestosDataAccess = new DataAccess.ComprobantesImpuestosClass();
                foreach (Models.ComprobanteImpuesto comprobanteImpuesto in comprobante.ComprobantesImpuestos)
                {
                    comprobanteImpuesto.ComprobanteId = comprobante.ComprobanteId;
                    comprobantesImpuestosDataAccess.Agregar(comprobanteImpuesto, adsertiDataAccess);
                }


                //-------------------------//
                //--TIMBRE FISCAL DIGITAL--//
                //-------------------------//

                //Agregar Timbre Fiscal Digital
                DataAccess.TimbresFiscalesDigitalesClass timbreFiscalDigitalDataAccess = new TimbresFiscalesDigitalesClass();
                comprobante.TimbreFiscalDigital.ComprobanteId = comprobante.ComprobanteId;
                comprobante.TimbreFiscalDigital.TimbreFiscalDigitalId = timbreFiscalDigitalDataAccess.Agregar(comprobante.TimbreFiscalDigital, adsertiDataAccess);

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
        /// Agregar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
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
                   Comprobante comprobante =  comprobantesDataAccess.ComprobanteArchivoXML(bitacoraCarga.NombreArchivo, adsertiDataAccess);
                    if (comprobante != null)
                        ComprobantesClass.VincularPDF(comprobante, bitacoraCarga, usuarioAltaId, adsertiDataAccess);
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
    }
}
