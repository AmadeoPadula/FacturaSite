using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.DataAccess;
using FacturaSite.Models;

namespace FacturaSite.BusinessLogic
{
    public class EvidenciasBusiness
    {

        #region * Constructor generado por Adserti *

        #endregion

        #region * Enumeraciones declaradas por Adserti *

        #endregion

        #region * Variables declaradas por Adserti *

        private static String CadenaDeConexion = ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString;

        #endregion

        #region * Propiedades declaradas por Adserti *

        #endregion

        #region * Eventos generados por Adserti *

        #endregion

        #region * Métodos creados por Adserti *

        private String CalcularClaveEvidencia(Models.Evidencias evidencia)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(evidencia.Empresa.Identificador); //Empresa
            sb.Append(evidencia.Banco.Identificador); //Banco
            sb.Append(evidencia.TipoTransaccion.Identificador); //Transaccion
            sb.Append(evidencia.NumeroTransferencia.ToString()); //Numero de Transferencia
            sb.Append(evidencia.FechaPago.ToString("yyyyMMdd")); //Fecha Pago 
            sb.Append(((int) evidencia.MontoPago).ToString()); // Monto Pagado

            sb.Append(evidencia.Comprobante.Identificador); // Factura Pagada
            sb.Append(' '); // Espacio en blanco
            sb.Append(evidencia.Comprobante.BitacoraCargasXml.NombreArchivo); // Nombre Archivo Factura
            //sb.Append(); // Extension archivo

            return sb.ToString();
        }

        /// <summary>
        /// Agregar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Marzo 18 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 18 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.Evidencias evidencia)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                EvidenciasClass evidenciasDataAccess = new EvidenciasClass();

                //Consulta Información para completar información de la evidencia
                BancosClass bancosDataAccess = new BancosClass();
                Bancos banco = bancosDataAccess.Cargar(evidencia.Banco.BancoId, adsertiDataAccess);

                EmpresasClass empresasDataAccess = new EmpresasClass();
                Empresas empresa = empresasDataAccess.Cargar(evidencia.Empresa.EmpresaId, adsertiDataAccess);

                TiposTransaccionesClass tiposTransaccionesDataAccess = new TiposTransaccionesClass();
                TiposTransacciones tipoTransaccion = tiposTransaccionesDataAccess.Cargar(evidencia.TipoTransaccion.TipoTransaccionId, adsertiDataAccess);

                ComprobantesClass comprobantesDataAccess = new ComprobantesClass();
                Comprobantes comprobante = comprobantesDataAccess.Cargar(evidencia.Comprobante.ComprobanteId, adsertiDataAccess);

                BitacoraCargasClass bitacoraCargaDataAccesss = new BitacoraCargasClass();
                BitacoraCargas bitacoraCargaXML = bitacoraCargaDataAccesss.Cargar(comprobante.BitacoraCargaIdXML, adsertiDataAccess);

                evidencia.Empresa = empresa;
                evidencia.Banco = banco;
                evidencia.TipoTransaccion = tipoTransaccion;
                evidencia.Comprobante = comprobante;
                evidencia.Comprobante.BitacoraCargasXml = bitacoraCargaXML;
                evidencia.ClaveEvidencia = CalcularClaveEvidencia(evidencia);

                return evidenciasDataAccess.Agregar(evidencia, adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public Int32 Agregar(Models.Evidencias evidencia)

        public static List<Bancos> CargarBancos()
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                BancosClass bancosDataAccess = new BancosClass();
                return bancosDataAccess.CargarTodos(adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public static List<Bancos> CargarBancos()

        public static List<Empresas> CargarEmpresas()
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                EmpresasClass empresasDataAccess = new EmpresasClass();
                return empresasDataAccess.CargarTodos(adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public static List<Empresas> CargarEmpresas()

        public static List<TiposTransacciones> CargarTiposTransacciones()
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                TiposTransaccionesClass tiposTransaccionesDataAccess = new TiposTransaccionesClass();
                return tiposTransaccionesDataAccess.CargarTodos(adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public static List<TiposTransacciones> CargarTiposTransacciones()


        /// <summary>
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Febrero 13 de 2015 </para>
        /// <para> Fecha de última modificación: Febrero 13 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Models.Evidencias Cargar(Int32 evidenciaId)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();

                EvidenciasClass evidenciasDataAccess = new EvidenciasClass();
                return evidenciasDataAccess.Cargar(evidenciaId, adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public BitacoraCargas Cargar(Int32 bitacoraId)

        #endregion

    }
}