using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
{
    public class EvidenciasClass
    {
        #region * Constructor generado por Adserti *

        #endregion

        #region * Enumeraciones declaradas por Adserti *

        #endregion

        #region * Variables declaradas por Adserti *

        //private static String CadenaDeConexion = AdsertiFunciones.DesencriptarTexto(ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString);
        private static String CadenaDeConexion = ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString;

        #endregion

        #region * Propiedades declaradas por Adserti *

        #endregion

        #region * Eventos generados por Adserti *

        #endregion

        #region * Métodos creados por Adserti *


        /// <summary>
        /// Agregar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.Evidencias evidencia, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            if (evidencia == null)
                throw new ArgumentNullException("emisor");
            if (evidencia.Empresa.EmpresaId == 0)
                throw new ArgumentNullException("EmpresaId");
            if (evidencia.TipoTransaccion.TipoTransaccionId == 0)
                throw new ArgumentNullException("TipoTransaccionId");
            if (String.IsNullOrEmpty(evidencia.NumeroTransferencia))
                throw new ArgumentNullException("NumeroTransferencia");
            try
            {
                //Configura la sentencia por ejecutar
                sentenciaSql = "INSERT INTO [Evidencias] ( ";
                sentenciaSql += "	[EmpresaId] ";
                sentenciaSql += "	,[BancoId] ";
                sentenciaSql += "	,[TipoTransaccionId] ";
                sentenciaSql += "	,[NumeroTransferencia] ";
                sentenciaSql += "	,[FechaPago] ";
                sentenciaSql += "	,[MontoPago] ";
                sentenciaSql += "	,[ComprobanteId] ";
                sentenciaSql += "	,[ClaveEvidencia] ";
                sentenciaSql += "	,[BitacoraCargaId] ";
                sentenciaSql += "	,[FechaAlta] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@EmpresaId ";
                sentenciaSql += "	,@BancoId ";
                sentenciaSql += "	,@TipoTransaccionId ";
                sentenciaSql += "	,@NumeroTransferencia ";
                sentenciaSql += "	,@FechaPago ";
                sentenciaSql += "	,@MontoPago ";
                sentenciaSql += "	,@ComprobanteId ";
                sentenciaSql += "	,@ClaveEvidencia ";
                sentenciaSql += "	,@BitacoraCargaId ";
                sentenciaSql += "	,getdate() ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@EmpresaId", evidencia.Empresa.EmpresaId),
                    new SqlParameter("@BancoId", evidencia.Banco == null ? (object) DBNull.Value : evidencia.Banco.BancoId),
                    new SqlParameter("@TipoTransaccionId", evidencia.TipoTransaccion.TipoTransaccionId),
                    new SqlParameter("@NumeroTransferencia", evidencia.NumeroTransferencia),
                    new SqlParameter("@FechaPago", evidencia.FechaPago),
                    new SqlParameter("@MontoPago", evidencia.MontoPago),
                    new SqlParameter("@ComprobanteId", evidencia.Comprobante.ComprobanteId),
                    new SqlParameter("@ClaveEvidencia", evidencia.ClaveEvidencia),
                    new SqlParameter("@BitacoraCargaId", evidencia.BitacoraCargaId),
                    new SqlParameter("@UsuarioAltaId", evidencia.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";
                evidencia.EvidenciaId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(evidencia.EvidenciaId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        }

        #endregion

    }
}