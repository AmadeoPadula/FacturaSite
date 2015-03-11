using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;
using ModelosEF.Models;

namespace ModelosEF.DAL
{
    public class ComprobantesClass
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
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.Comprobante comprobante, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (comprobante.Emisor==null)
                throw new ArgumentNullException("Emisor");
            if (comprobante.Receptor == null)
                throw new ArgumentNullException("Receptor");

            if (String.IsNullOrEmpty(comprobante.Folio))
                throw new ArgumentNullException("Folio");
            if (String.IsNullOrEmpty(comprobante.FormaPago))
                throw new ArgumentNullException("FormaPago");
            if (String.IsNullOrEmpty(comprobante.LugarExpedicion))
                throw new ArgumentNullException("LugarExpedicion");
            if (String.IsNullOrEmpty(comprobante.MetodoPago))
                throw new ArgumentNullException("MetodoPago");
            if (String.IsNullOrEmpty(comprobante.Moneda))
                throw new ArgumentNullException("Moneda");
            if (String.IsNullOrEmpty(comprobante.NoCertificado))
                throw new ArgumentNullException("NoCertificado");
            if (String.IsNullOrEmpty(comprobante.NumCtaPago))
                throw new ArgumentNullException("NumCtaPago");
            if (String.IsNullOrEmpty(comprobante.TipoComprobante))
                throw new ArgumentNullException("TipoComprobante");
            if (comprobante.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                //Configura la sentencia por ejecutar
                sentenciaSql = "INSERT INTO [dbo].[Comprobantes] ( ";
                sentenciaSql += "	[EmisorId] ";
                sentenciaSql += "	,[ReceptorId] ";
                sentenciaSql += "	,[TotalImpuestosRetenidos] ";
                sentenciaSql += "	,[TotalImpuestosTrasladados] ";
                sentenciaSql += "	,[Certificado] ";
                sentenciaSql += "	,[CondicionesPago] ";
                sentenciaSql += "	,[Descuento] ";
                sentenciaSql += "	,[Fecha] ";
                sentenciaSql += "	,[FechaFolioFiscalOrig] ";
                sentenciaSql += "	,[Folio] ";
                sentenciaSql += "	,[FormaPago] ";
                sentenciaSql += "	,[LugarExpedicion] ";
                sentenciaSql += "	,[MetodoPago] ";
                sentenciaSql += "	,[Moneda] ";
                sentenciaSql += "	,[MontoFolioFiscalOrig] ";
                sentenciaSql += "	,[MotivoDescuento] ";
                sentenciaSql += "	,[NoCertificado] ";
                sentenciaSql += "	,[NumCtaPago] ";
                sentenciaSql += "	,[Sello] ";
                sentenciaSql += "	,[Serie] ";
                sentenciaSql += "	,[SerieFolioFiscalOrig] ";
                sentenciaSql += "	,[SubTotal] ";
                sentenciaSql += "	,[TipoCambio] ";
                sentenciaSql += "	,[TipoComprobante] ";
                sentenciaSql += "	,[Total] ";
                sentenciaSql += "	,[Version] ";
                sentenciaSql += "	,[NombreArchivo] ";
                sentenciaSql += "	,[Activo] ";
                sentenciaSql += "	,[FolioFiscalOrig] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@EmisorId ";
                sentenciaSql += "	,@ReceptorId ";
                sentenciaSql += "	,@TotalImpuestosRetenidos ";
                sentenciaSql += "	,@TotalImpuestosTrasladados ";
                sentenciaSql += "	,@Certificado ";
                sentenciaSql += "	,@CondicionesPago ";
                sentenciaSql += "	,@Descuento ";
                sentenciaSql += "	,@Fecha ";
                sentenciaSql += "	,@FechaFolioFiscalOrig ";
                sentenciaSql += "	,@Folio ";
                sentenciaSql += "	,@FormaPago ";
                sentenciaSql += "	,@LugarExpedicion ";
                sentenciaSql += "	,@MetodoPago ";
                sentenciaSql += "	,@Moneda ";
                sentenciaSql += "	,@MontoFolioFiscalOrig ";
                sentenciaSql += "	,@MotivoDescuento ";
                sentenciaSql += "	,@NoCertificado ";
                sentenciaSql += "	,@NumCtaPago ";
                sentenciaSql += "	,@Sello ";
                sentenciaSql += "	,@Serie ";
                sentenciaSql += "	,@SerieFolioFiscalOrig ";
                sentenciaSql += "	,@SubTotal ";
                sentenciaSql += "	,@TipoCambio ";
                sentenciaSql += "	,@TipoComprobante ";
                sentenciaSql += "	,@Total ";
                sentenciaSql += "	,@Version ";
                sentenciaSql += "	,@NombreArchivo ";
                sentenciaSql += "	,1 ";
                sentenciaSql += "	,@FolioFiscalOrig ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("EmisorId", comprobante.Emisor.EmisorId),
                    new SqlParameter("ReceptorId", comprobante.Receptor.ReceptorId),
                    new SqlParameter("TotalImpuestosRetenidos", comprobante.TotalImpuestosRetenidos),
                    new SqlParameter("TotalImpuestosTrasladados", comprobante.TotalImpuestosTrasladados),
                    new SqlParameter("Certificado", comprobante.Certificado),
                    new SqlParameter("CondicionesPago", comprobante.CondicionesPago),
                    new SqlParameter("Descuento", comprobante.Descuento),
                    new SqlParameter("Fecha", comprobante.Fecha),
                    new SqlParameter("FechaFolioFiscalOrig", comprobante.FechaFolioFiscalOrig ?? (object)DBNull.Value),
                    new SqlParameter("Folio", comprobante.Folio),
                    new SqlParameter("FormaPago", comprobante.FormaPago),
                    new SqlParameter("LugarExpedicion", comprobante.LugarExpedicion),
                    new SqlParameter("MetodoPago", comprobante.MetodoPago),
                    new SqlParameter("Moneda", comprobante.Moneda),
                    new SqlParameter("MontoFolioFiscalOrig", comprobante.MontoFolioFiscalOrig),
                    new SqlParameter("MotivoDescuento", comprobante.MotivoDescuento),
                    new SqlParameter("NoCertificado", comprobante.NoCertificado),
                    new SqlParameter("NumCtaPago", comprobante.NumCtaPago),
                    new SqlParameter("Sello", comprobante.Sello),
                    new SqlParameter("Serie", comprobante.Serie),
                    new SqlParameter("SerieFolioFiscalOrig", comprobante.SerieFolioFiscalOrig),
                    new SqlParameter("SubTotal", comprobante.SubTotal),
                    new SqlParameter("TipoCambio", comprobante.TipoCambio),
                    new SqlParameter("TipoComprobante", comprobante.TipoComprobante),
                    new SqlParameter("Total", comprobante.Total),
                    new SqlParameter("Version", comprobante.Version),
                    new SqlParameter("NombreArchivo", comprobante.NombreArchivo),
                    new SqlParameter("FolioFiscalOrig", comprobante.FolioFiscalOrig),
                    new SqlParameter("@UsuarioAltaId", comprobante.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                comprobante.ComprobanteId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));
                
                return Convert.ToInt32(comprobante.ComprobanteId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Comprobante comprobante)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Models.Comprobante comprobante, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros

            if (comprobante.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");

            if (comprobante.Emisor == null)
                throw new ArgumentNullException("Emisor");
            if (comprobante.Receptor == null)
                throw new ArgumentNullException("Receptor");

            if (String.IsNullOrEmpty(comprobante.Folio))
                throw new ArgumentNullException("Folio");
            if (String.IsNullOrEmpty(comprobante.FormaPago))
                throw new ArgumentNullException("FormaPago");
            if (String.IsNullOrEmpty(comprobante.LugarExpedicion))
                throw new ArgumentNullException("LugarExpedicion");
            if (String.IsNullOrEmpty(comprobante.MetodoPago))
                throw new ArgumentNullException("MetodoPago");
            if (String.IsNullOrEmpty(comprobante.Moneda))
                throw new ArgumentNullException("Moneda");
            if (String.IsNullOrEmpty(comprobante.MotivoDescuento))
                throw new ArgumentNullException("MotivoDescuento");
            if (String.IsNullOrEmpty(comprobante.NoCertificado))
                throw new ArgumentNullException("NoCertificado");
            if (String.IsNullOrEmpty(comprobante.NumCtaPago))
                throw new ArgumentNullException("NumCtaPago");
            if (String.IsNullOrEmpty(comprobante.TipoComprobante))
                throw new ArgumentNullException("TipoComprobante");
            if (comprobante.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");

            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[Comprobantes] ";
                sentenciaSql += "SET [EmisorId] = @EmisorId ";
                sentenciaSql += "	,[ReceptorId] = @ReceptorId ";
                sentenciaSql += "	,[TotalImpuestosRetenidos] = @TotalImpuestosRetenidos ";
                sentenciaSql += "	,[TotalImpuestosTrasladados] = @TotalImpuestosTrasladados ";
                sentenciaSql += "	,[Certificado] = @Certificado ";
                sentenciaSql += "	,[CondicionesPago] = @CondicionesPago ";
                sentenciaSql += "	,[Descuento] = @Descuento ";
                sentenciaSql += "	,[Fecha] = @Fecha ";
                sentenciaSql += "	,[FechaFolioFiscalOrig] = @FechaFolioFiscalOrig ";
                sentenciaSql += "	,[Folio] = @Folio ";
                sentenciaSql += "	,[FormaPago] = @FormaPago ";
                sentenciaSql += "	,[LugarExpedicion] = @LugarExpedicion ";
                sentenciaSql += "	,[MetodoPago] = @MetodoPago ";
                sentenciaSql += "	,[Moneda] = @Moneda ";
                sentenciaSql += "	,[MontoFolioFiscalOrig] = @MontoFolioFiscalOrig ";
                sentenciaSql += "	,[MotivoDescuento] = @MotivoDescuento ";
                sentenciaSql += "	,[NoCertificado] = @NoCertificado ";
                sentenciaSql += "	,[NumCtaPago] = @NumCtaPago ";
                sentenciaSql += "	,[Sello] = @Sello ";
                sentenciaSql += "	,[Serie] = @Serie ";
                sentenciaSql += "	,[SerieFolioFiscalOrig] = @SerieFolioFiscalOrig ";
                sentenciaSql += "	,[SubTotal] = @SubTotal ";
                sentenciaSql += "	,[TipoCambio] = @TipoCambio ";
                sentenciaSql += "	,[TipoComprobante] = @TipoComprobante ";
                sentenciaSql += "	,[Total] = @Total ";
                sentenciaSql += "	,[Version] = @Version ";
                sentenciaSql += "	,[NombreArchivo] = @NombreArchivo ";
                sentenciaSql += "	,[Activo] = @Activo ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[FolioFiscalOrig] = @FolioFiscalOrig ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[ComprobanteId] = @ComprobanteId ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("ComprobanteId", comprobante.ComprobanteId),
                    new SqlParameter("EmisorId", comprobante.Emisor.EmisorId),
                    new SqlParameter("ReceptorId", comprobante.Receptor.ReceptorId),
                    new SqlParameter("TotalImpuestosRetenidos", comprobante.TotalImpuestosRetenidos),
                    new SqlParameter("TotalImpuestosTrasladados", comprobante.TotalImpuestosTrasladados),
                    new SqlParameter("Certificado", comprobante.Certificado),
                    new SqlParameter("CondicionesPago", comprobante.CondicionesPago),
                    new SqlParameter("Descuento", comprobante.Descuento),
                    new SqlParameter("Fecha", comprobante.Fecha),
                    new SqlParameter("FechaFolioFiscalOrig", comprobante.FechaFolioFiscalOrig ?? (object)DBNull.Value),
                    new SqlParameter("Folio", comprobante.Folio),
                    new SqlParameter("FormaPago", comprobante.FormaPago),
                    new SqlParameter("LugarExpedicion", comprobante.LugarExpedicion),
                    new SqlParameter("MetodoPago", comprobante.MetodoPago),
                    new SqlParameter("Moneda", comprobante.Moneda),
                    new SqlParameter("MontoFolioFiscalOrig", comprobante.MontoFolioFiscalOrig),
                    new SqlParameter("MotivoDescuento", comprobante.MotivoDescuento),
                    new SqlParameter("NoCertificado", comprobante.NoCertificado),
                    new SqlParameter("NumCtaPago", comprobante.NumCtaPago),
                    new SqlParameter("Sello", comprobante.Sello),
                    new SqlParameter("Serie", comprobante.Serie),
                    new SqlParameter("SerieFolioFiscalOrig", comprobante.SerieFolioFiscalOrig),
                    new SqlParameter("SubTotal", comprobante.SubTotal),
                    new SqlParameter("TipoCambio", comprobante.TipoCambio),
                    new SqlParameter("TipoComprobante", comprobante.TipoComprobante),
                    new SqlParameter("Total", comprobante.Total),
                    new SqlParameter("Version", comprobante.Version),
                    new SqlParameter("NombreArchivo", comprobante.NombreArchivo),
                    new SqlParameter("Activo", comprobante.Activo),
                    new SqlParameter("FolioFiscalOrig", comprobante.FolioFiscalOrig),
                    new SqlParameter("UsuarioCambioId", comprobante.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);
                
                return Convert.ToInt32(comprobante.ComprobanteId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Persona persona)


        /// <summary>   
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Julio 12 de 2014 </para>
        /// <para> Fecha de última modificación: Julio 12 de 2014 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <param name = "rfc" type = "String"></param>	    
        /// <param name = "folio" type = "String"></param>	    
        /// <param name = "serie" type = "String"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Models.Comprobante </returns>
        public Models.Comprobante Cargar(String rfc, String folio, string serie, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable comprobanteDataTable;
            SqlParameter[] listaParametros;
            Models.Comprobante comprobante = null;

            // Valida que los parámetros enviados sean correctos
            if (String.IsNullOrEmpty(rfc))
                throw new ArgumentNullException("rfc");
            if (String.IsNullOrEmpty(folio))
                throw new ArgumentNullException("folio");
            if (String.IsNullOrEmpty(serie))
                throw new ArgumentNullException("serie");
            try
            {
                sentenciaSql = "SELECT ";
                sentenciaSql += "	[Comprobantes].[ComprobanteId], ";
                sentenciaSql += "	[Comprobantes].[EmisorId], ";
                sentenciaSql += "	[Comprobantes].[ReceptorId], ";
                sentenciaSql += "	[Comprobantes].[TotalImpuestosRetenidos], ";
                sentenciaSql += "	[Comprobantes].[TotalImpuestosTrasladados], ";
                sentenciaSql += "	[Comprobantes].[Certificado], ";
                sentenciaSql += "	[Comprobantes].[CondicionesPago], ";
                sentenciaSql += "	[Comprobantes].[Descuento], ";
                sentenciaSql += "	[Comprobantes].[Fecha], ";
                sentenciaSql += "	[Comprobantes].[FechaFolioFiscalOrig], ";
                sentenciaSql += "	[Comprobantes].[Folio], ";
                sentenciaSql += "	[Comprobantes].[FormaPago], ";
                sentenciaSql += "	[Comprobantes].[LugarExpedicion], ";
                sentenciaSql += "	[Comprobantes].[MetodoPago], ";
                sentenciaSql += "	[Comprobantes].[Moneda], ";
                sentenciaSql += "	[Comprobantes].[MontoFolioFiscalOrig], ";
                sentenciaSql += "	[Comprobantes].[MotivoDescuento], ";
                sentenciaSql += "	[Comprobantes].[NoCertificado], ";
                sentenciaSql += "	[Comprobantes].[NumCtaPago], ";
                sentenciaSql += "	[Comprobantes].[Sello], ";
                sentenciaSql += "	[Comprobantes].[Serie], ";
                sentenciaSql += "	[Comprobantes].[SerieFolioFiscalOrig], ";
                sentenciaSql += "	[Comprobantes].[SubTotal], ";
                sentenciaSql += "	[Comprobantes].[TipoCambio], ";
                sentenciaSql += "	[Comprobantes].[TipoComprobante], ";
                sentenciaSql += "	[Comprobantes].[Total], ";
                sentenciaSql += "	[Comprobantes].[Version], ";
                sentenciaSql += "	[Comprobantes].[NombreArchivo], ";
                sentenciaSql += "	[Comprobantes].[Activo] ";
                sentenciaSql += "FROM  ";
                sentenciaSql += "	[dbo].[Comprobantes] INNER JOIN [dbo].[Emisores] ";
                sentenciaSql += "		ON ([Comprobantes].[EmisorId] = [Emisores].[EmisorId]) ";
                sentenciaSql += "	INNER JOIN [dbo].[Personas] ";
                sentenciaSql += "		ON ([Emisores].[PersonaId] = [Personas].[PersonaId]) ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	[Comprobantes].[Folio] = @Folio AND ";
                sentenciaSql += "	[Comprobantes].[Serie] = @Serie AND ";
                sentenciaSql += "	[Personas].[Rfc] = @Rfc AND ";
                sentenciaSql += "	[Comprobantes].[Activo] = 1 ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@Folio", folio),
                    new SqlParameter("@Serie", serie),
                    new SqlParameter("@Rfc", rfc)
                };

                comprobanteDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (comprobanteDataTable.Rows.Count > 0)
                {
                    comprobante = new Models.Comprobante();

                    comprobante.ComprobanteId = Convert.ToInt32(comprobanteDataTable.Rows[0]["ComprobanteId"]);
                    comprobante.Emisor = new Models.Emisor
                    {
                        EmisorId = Convert.ToInt32(comprobanteDataTable.Rows[0]["EmisorId"])
                    };

                    comprobante.Receptor = new Models.Receptor()
                    {
                        ReceptorId = Convert.ToInt32(comprobanteDataTable.Rows[0]["ReceptorId"])
                    };

                    comprobante.TotalImpuestosRetenidos = Convert.ToDecimal(comprobanteDataTable.Rows[0]["TotalImpuestosRetenidos"]);
                    comprobante.TotalImpuestosTrasladados = Convert.ToDecimal(comprobanteDataTable.Rows[0]["TotalImpuestosTrasladados"]);

                    comprobante.Certificado = (comprobanteDataTable.Rows[0]["Certificado"]).ToString();
                    comprobante.CondicionesPago = (comprobanteDataTable.Rows[0]["CondicionesPago"]).ToString();
                    comprobante.Descuento = Convert.ToDecimal(comprobanteDataTable.Rows[0]["Descuento"]);
                    comprobante.Fecha = Convert.ToDateTime(comprobanteDataTable.Rows[0]["Fecha"]);
                    comprobante.FechaFolioFiscalOrig = Convert.ToDateTime(comprobanteDataTable.Rows[0]["FechaFolioFiscalOrig"]);
                    comprobante.Folio = (comprobanteDataTable.Rows[0]["Folio"]).ToString();
                    comprobante.FolioFiscalOrig = (comprobanteDataTable.Rows[0]["FolioFiscalOrig"]).ToString();
                    comprobante.FormaPago = (comprobanteDataTable.Rows[0]["FormaPago"]).ToString();
                    comprobante.LugarExpedicion = (comprobanteDataTable.Rows[0]["LugarExpedicion"]).ToString();
                    comprobante.MetodoPago = (comprobanteDataTable.Rows[0]["MetodoPago"]).ToString();
                    comprobante.Moneda = (comprobanteDataTable.Rows[0]["Moneda"]).ToString();
                    comprobante.MontoFolioFiscalOrig = Convert.ToDecimal(comprobanteDataTable.Rows[0]["MontoFolioFiscalOrig"]);
                    comprobante.MotivoDescuento = (comprobanteDataTable.Rows[0]["MotivoDescuento"]).ToString();
                    comprobante.NoCertificado = (comprobanteDataTable.Rows[0]["NoCertificado"]).ToString();
                    comprobante.NumCtaPago = (comprobanteDataTable.Rows[0]["NumCtaPago"]).ToString();
                    comprobante.Sello = (comprobanteDataTable.Rows[0]["Sello"]).ToString();
                    comprobante.Serie = (comprobanteDataTable.Rows[0]["Serie"]).ToString();
                    comprobante.SerieFolioFiscalOrig = (comprobanteDataTable.Rows[0]["SerieFolioFiscalOrig"]).ToString();
                    comprobante.SubTotal = Convert.ToDecimal(comprobanteDataTable.Rows[0]["SubTotal"]);
                    comprobante.TipoCambio = (comprobanteDataTable.Rows[0]["TipoCambio"]).ToString();
                    comprobante.TipoComprobante = (comprobanteDataTable.Rows[0]["TipoComprobante"]).ToString();
                    comprobante.Total = Convert.ToDecimal(comprobanteDataTable.Rows[0]["Total"]);
                    comprobante.Version = (comprobanteDataTable.Rows[0]["Version"]).ToString();
                    comprobante.NombreArchivo = (comprobanteDataTable.Rows[0]["NombreArchivo"]).ToString();
                    comprobante.Activo = Convert.ToBoolean(comprobanteDataTable.Rows[0]["Activo"]);
                    comprobante.FechaAlta = Convert.ToDateTime(comprobanteDataTable.Rows[0]["FechaAlta"]);
                    comprobante.UsuarioAltaId = Convert.ToInt32(comprobanteDataTable.Rows[0]["UsuarioAltaId"]);


                    if (comprobanteDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        comprobante.FechaCambio = null;
                    }
                    else
                    {
                        comprobante.FechaCambio = Convert.ToDateTime(comprobanteDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (comprobanteDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        comprobante.UsuarioCambioId = null;
                    }
                    else
                    {
                        comprobante.UsuarioCambioId = Convert.ToInt32(comprobanteDataTable.Rows[0]["UsuarioCambioId"]);
                    }
                } // if (comprobanteDataTable.Rows.Count > 0)

                return comprobante;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Persona Cargar(String rfc, AdsertiSqlDataAccess adsertiDataAccess)

        #endregion
    }
}
