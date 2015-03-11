using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;
using ModelosEF.DAL;
using ModelosEF.Models;

namespace ModelosEF.BusinessLogic
{
    public class ComprobanteBusiness
    {
        private static String CadenaDeConexion = ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString;

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
                DAL.PersonasClass personaEmisorDal = new DAL.PersonasClass();
                Models.Persona personaEmisor = personaEmisorDal.Cargar(comprobante.Emisor.Persona.Rfc, adsertiDataAccess);

                comprobante.Emisor.Persona.PersonaId = (personaEmisor == null) ? personaEmisorDal.Agregar(comprobante.Emisor.Persona, adsertiDataAccess) : personaEmisor.PersonaId;

                //Domicilio Fiscal EMISOR
                DAL.DomiciliosClass domicilioFiscalDal = new DAL.DomiciliosClass();
                comprobante.Emisor.DomicilioFiscal.DomicilioId = domicilioFiscalDal.Agregar(comprobante.Emisor.DomicilioFiscal, adsertiDataAccess);

                //Domicilio Expedicion EMISOR
                DAL.DomiciliosClass domicilioExpedicionDal = new DAL.DomiciliosClass();
                comprobante.Emisor.DomicilioExpedicion.DomicilioId = domicilioExpedicionDal.Agregar(comprobante.Emisor.DomicilioExpedicion, adsertiDataAccess);

                //Agregar EMISOR
                DAL.EmisoresClass emisorDal = new DAL.EmisoresClass();
                comprobante.Emisor.EmisorId = emisorDal.Agregar(comprobante.Emisor, adsertiDataAccess);


                //Regimenes Fiscales Emisor
                DAL.RegimenesFiscalesClass regimenFiscalDal = new DAL.RegimenesFiscalesClass();
                DAL.EmisoresRegimenesFiscalesClass emisoresRegimenesFiscalesDal = new EmisoresRegimenesFiscalesClass();
                
                foreach (RegimenFiscal regimenFiscalItem in comprobante.Emisor.RegimenesFiscales)
                {
                    Models.RegimenFiscal regimenFiscal = regimenFiscalDal.Cargar(regimenFiscalItem.RegimenFiscalDescripcion, adsertiDataAccess);
                    Int32 regimenFiscalId;

                    //Existe regimen Fiscal
                    regimenFiscalId = (regimenFiscal == null) ? regimenFiscalDal.Agregar(regimenFiscalItem, adsertiDataAccess) : regimenFiscal.RegimenFiscalId;

                    //Inserta relacion RegimenesFiscales-Emisores
                    Models.EmisorRegimenFiscal emisorRegimenFiscal = new EmisorRegimenFiscal
                    {
                        EmisorId = comprobante.Emisor.EmisorId,
                        RegimenFiscalId = regimenFiscalId,
                        UsuarioAltaId = regimenFiscalItem.UsuarioAltaId
                    };

                    emisoresRegimenesFiscalesDal.Agregar(emisorRegimenFiscal, adsertiDataAccess);
                } // foreach (RegimenFiscal regimenFiscalItem in comprobante.Emisor.RegimenesFiscales)

                //------------//
                //--RECEPTOR--//
                //------------//

                //Existe RECEPTOR:
                DAL.PersonasClass personaReceptorDal = new DAL.PersonasClass();
                Models.Persona personaReceptor = personaEmisorDal.Cargar(comprobante.Receptor.Persona.Rfc, adsertiDataAccess);
                
                comprobante.Receptor.Persona.PersonaId = personaReceptor == null ? personaReceptorDal.Agregar(comprobante.Receptor.Persona, adsertiDataAccess) : personaReceptor.PersonaId;

                //Domicilio RECEPTOR
                DAL.DomiciliosClass domicilioReceptorlDal = new DAL.DomiciliosClass();
                comprobante.Receptor.Domicilio.DomicilioId = domicilioReceptorlDal.Agregar(comprobante.Receptor.Domicilio, adsertiDataAccess);

                //Agregar RECEPTOR
                DAL.ReceptoresClass receptorDal = new DAL.ReceptoresClass();
                comprobante.Receptor.ReceptorId = receptorDal.Agregar(comprobante.Receptor, adsertiDataAccess);


                //---------------//
                //--COMPROBANTE--//
                //---------------//

                //Agregar COMPROBANTE
                DAL.ComprobantesClass comprobanteDal= new ComprobantesClass();
                comprobante.ComprobanteId = comprobanteDal.Agregar(comprobante, adsertiDataAccess);

                //-------------//
                //--CONCEPTOS--//
                //-------------//

                //Agregar CONCEPTOS
                DAL.ConceptosClass conceptoDal = new ConceptosClass();

                foreach (Models.Concepto concepto in comprobante.Conceptos)
                {
                    concepto.ComprobanteId = comprobante.ComprobanteId;
                    conceptoDal.Agregar(concepto, adsertiDataAccess);
                }

                //--------------------------//
                //--COMPROBANTES IMPUESTOS--//
                //--------------------------//

                //Agregar ComprobantesImpuestos
                DAL.ComprobantesImpuestosClass comprobantesImpuestosDal = new DAL.ComprobantesImpuestosClass();
                foreach (Models.ComprobanteImpuesto comprobanteImpuesto in comprobante.ComprobantesImpuestos)
                {
                    comprobanteImpuesto.ComprobanteId = comprobante.ComprobanteId;
                    comprobantesImpuestosDal.Agregar(comprobanteImpuesto, adsertiDataAccess);
                }


                //-------------------------//
                //--TIMBRE FISCAL DIGITAL--//
                //-------------------------//

                //Agregar Timbre Fiscal Digital
                DAL.TimbresFiscalesDigitalesClass timbreFiscalDigitalDal = new TimbresFiscalesDigitalesClass();
                comprobante.TimbreFiscalDigital.ComprobanteId = comprobante.ComprobanteId;
                comprobante.TimbreFiscalDigital.TimbreFiscalDigitalId = timbreFiscalDigitalDal.Agregar(comprobante.TimbreFiscalDigital, adsertiDataAccess);

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
