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
                    new SqlParameter("@BitacoraCargaId", evidencia.BitacoraCarga.BitacoraCargaId),
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


        /// <summary>   
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Julio 12 de 2014 </para>
        /// <para> Fecha de última modificación: Julio 12 de 2014 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <param name = "comprobanteId" type = "String"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Comprobantes </returns>
        public Models.Evidencias Cargar(int evidenciaId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable evidenciaseDataTable;
            SqlParameter[] listaParametros;
            Models.Evidencias evidencia = null;

            // Valida que los parámetros enviados sean correctos
            if (evidenciaId <= 0)
                throw new ArgumentNullException("evidenciaId");

            try
            {

                sentenciaSql += "SELECT ";
                sentenciaSql += "	[Evidencias].[EvidenciaId], ";
                sentenciaSql += "	[Evidencias].[EmpresaId], ";
                sentenciaSql += "	[Evidencias].[BancoId], ";
                sentenciaSql += "	[Evidencias].[TipoTransaccionId], ";
                sentenciaSql += "	[Evidencias].[NumeroTransferencia], ";
                sentenciaSql += "	[Evidencias].[FechaPago], ";
                sentenciaSql += "	[Evidencias].[MontoPago], ";
                sentenciaSql += "	[Evidencias].[ClaveEvidencia], ";
                sentenciaSql += "	[Evidencias].[BitacoraCargaId], ";
                sentenciaSql += "	[Evidencias].[ComprobanteId], ";
                sentenciaSql += "	[Evidencias].[Activo], ";
                sentenciaSql += "	[Evidencias].[FechaAlta], ";
                sentenciaSql += "	[Evidencias].[UsuarioAltaId], ";
                sentenciaSql += "	[Evidencias].[FechaCambio], ";
                sentenciaSql += "	[Evidencias].[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[Evidencias] ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	[Evidencias].[EvidenciaId] = @EvidenciaId ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@EvidenciaId", evidenciaId)
                };

                evidenciaseDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);
                if (evidenciaseDataTable.Rows.Count > 0)
                {
                    evidencia = new Models.Evidencias();

                    evidencia.EvidenciaId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["EvidenciaId"]);

                    evidencia.Banco = new Bancos()
                    {
                        BancoId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["EmpresaId"])
                    };

                    evidencia.Empresa = new Empresas()
                    {
                        EmpresaId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["BancoId"])
                    };
                    evidencia.TipoTransaccion = new TiposTransacciones()
                    {
                        TipoTransaccionId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["TipoTransaccionId"])
                    };
                    
                    evidencia.NumeroTransferencia = (evidenciaseDataTable.Rows[0]["NumeroTransferencia"]).ToString();
                    evidencia.FechaPago = Convert.ToDateTime(evidenciaseDataTable.Rows[0]["FechaPago"]);
                    evidencia.MontoPago = Convert.ToDecimal(evidenciaseDataTable.Rows[0]["MontoPago"]);
                    evidencia.ClaveEvidencia = (evidenciaseDataTable.Rows[0]["ClaveEvidencia"]).ToString();
                    evidencia.BitacoraCarga = new BitacoraCargas()
                    {
                        BitacoraCargaId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["BitacoraCargaId"])
                    };

                    evidencia.Comprobante = new Comprobantes()
                    {
                        ComprobanteId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["ComprobanteId"])
                    };
                    
                    evidencia.Activo = Convert.ToBoolean(evidenciaseDataTable.Rows[0]["Activo"]);
                    evidencia.FechaAlta = Convert.ToDateTime(evidenciaseDataTable.Rows[0]["FechaAlta"]);
                    evidencia.UsuarioAltaId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["UsuarioAltaId"]);

                    if (evidenciaseDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        evidencia.FechaCambio = null;
                    }
                    else
                    {
                        evidencia.FechaCambio = Convert.ToDateTime(evidenciaseDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (evidenciaseDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        evidencia.UsuarioCambioId = null;
                    }
                    else
                    {
                        evidencia.UsuarioCambioId = Convert.ToInt32(evidenciaseDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } // if (evidenciaseDataTable.Rows.Count > 0)

                return evidencia;

            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Evidencias Cargar(int evidenciaId, AdsertiSqlDataAccess adsertiDataAccess)



        #endregion

    }
}