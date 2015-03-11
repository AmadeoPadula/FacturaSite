using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Cache;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
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
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Comprobantes comprobantes, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (comprobantes.Emisores==null)
                throw new ArgumentNullException("Emisores");
            if (comprobantes.Receptores == null)
                throw new ArgumentNullException("Receptores");

            if (String.IsNullOrEmpty(comprobantes.Folio))
                throw new ArgumentNullException("Folio");
            if (String.IsNullOrEmpty(comprobantes.FormaPago))
                throw new ArgumentNullException("FormaPago");
            if (String.IsNullOrEmpty(comprobantes.LugarExpedicion))
                throw new ArgumentNullException("LugarExpedicion");
            if (String.IsNullOrEmpty(comprobantes.MetodoPago))
                throw new ArgumentNullException("MetodoPago");
            if (String.IsNullOrEmpty(comprobantes.Moneda))
                throw new ArgumentNullException("Moneda");
            if (String.IsNullOrEmpty(comprobantes.NoCertificado))
                throw new ArgumentNullException("NoCertificado");
            if (String.IsNullOrEmpty(comprobantes.NumCtaPago))
                throw new ArgumentNullException("NumCtaPago");
            if (String.IsNullOrEmpty(comprobantes.TipoComprobante))
                throw new ArgumentNullException("TipoComprobante");
            if(comprobantes.BitacoraCargaIdXML==0)
                throw new ArgumentNullException("BitacoraCargaIdXML");
            if (comprobantes.UsuarioAltaId == 0)
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
                sentenciaSql += "	,[BitacoraCargaIdXML] ";
                sentenciaSql += "	,[BitacoraCargaIdPDF] ";
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
                sentenciaSql += "	,@BitacoraCargaIdXML ";
                sentenciaSql += "	,@BitacoraCargaIdPDF ";
                sentenciaSql += "	,1 ";
                sentenciaSql += "	,@FolioFiscalOrig ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@EmisorId", comprobantes.Emisores.EmisorId),
                    new SqlParameter("@ReceptorId", comprobantes.Receptores.ReceptorId),
                    new SqlParameter("@TotalImpuestosRetenidos", comprobantes.TotalImpuestosRetenidos),
                    new SqlParameter("@TotalImpuestosTrasladados", comprobantes.TotalImpuestosTrasladados),
                    new SqlParameter("@Certificado", comprobantes.Certificado),
                    new SqlParameter("@CondicionesPago", comprobantes.CondicionesPago),
                    new SqlParameter("@Descuento", comprobantes.Descuento),
                    new SqlParameter("@Fecha", comprobantes.Fecha),
                    new SqlParameter("@FechaFolioFiscalOrig", comprobantes.FechaFolioFiscalOrig ?? (object)DBNull.Value),
                    new SqlParameter("@Folio", comprobantes.Folio),
                    new SqlParameter("@FormaPago", comprobantes.FormaPago),
                    new SqlParameter("@LugarExpedicion", comprobantes.LugarExpedicion),
                    new SqlParameter("@MetodoPago", comprobantes.MetodoPago),
                    new SqlParameter("@Moneda", comprobantes.Moneda),
                    new SqlParameter("@MontoFolioFiscalOrig", comprobantes.MontoFolioFiscalOrig),
                    new SqlParameter("@MotivoDescuento", comprobantes.MotivoDescuento),
                    new SqlParameter("@NoCertificado", comprobantes.NoCertificado),
                    new SqlParameter("@NumCtaPago", comprobantes.NumCtaPago),
                    new SqlParameter("@Sello", comprobantes.Sello),
                    new SqlParameter("@Serie", comprobantes.Serie),
                    new SqlParameter("@SerieFolioFiscalOrig", comprobantes.SerieFolioFiscalOrig),
                    new SqlParameter("@SubTotal", comprobantes.SubTotal),
                    new SqlParameter("@TipoCambio", comprobantes.TipoCambio),
                    new SqlParameter("@TipoComprobante", comprobantes.TipoComprobante),
                    new SqlParameter("@Total", comprobantes.Total),
                    new SqlParameter("@Version", comprobantes.Version),
                    new SqlParameter("@BitacoraCargaIdXML", comprobantes.BitacoraCargaIdXML),
                    new SqlParameter("@BitacoraCargaIdPDF", comprobantes.BitacoraCargaIdPDF ?? (Object)DBNull.Value),
                    new SqlParameter("@FolioFiscalOrig", comprobantes.FolioFiscalOrig),
                    new SqlParameter("@UsuarioAltaId", comprobantes.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                comprobantes.ComprobanteId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));
                
                return Convert.ToInt32(comprobantes.ComprobanteId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Comprobantes Comprobantes)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Comprobantes comprobantes, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros

            if (comprobantes.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");

            if (comprobantes.Emisores == null)
                throw new ArgumentNullException("Emisores");
            if (comprobantes.Receptores == null)
                throw new ArgumentNullException("Receptores");

            if (String.IsNullOrEmpty(comprobantes.Folio))
                throw new ArgumentNullException("Folio");
            if (String.IsNullOrEmpty(comprobantes.FormaPago))
                throw new ArgumentNullException("FormaPago");
            if (String.IsNullOrEmpty(comprobantes.LugarExpedicion))
                throw new ArgumentNullException("LugarExpedicion");
            if (String.IsNullOrEmpty(comprobantes.MetodoPago))
                throw new ArgumentNullException("MetodoPago");
            if (String.IsNullOrEmpty(comprobantes.Moneda))
                throw new ArgumentNullException("Moneda");
            if (String.IsNullOrEmpty(comprobantes.MotivoDescuento))
                throw new ArgumentNullException("MotivoDescuento");
            if (String.IsNullOrEmpty(comprobantes.NoCertificado))
                throw new ArgumentNullException("NoCertificado");
            if (String.IsNullOrEmpty(comprobantes.NumCtaPago))
                throw new ArgumentNullException("NumCtaPago");
            if (String.IsNullOrEmpty(comprobantes.TipoComprobante))
                throw new ArgumentNullException("TipoComprobante");
            if (comprobantes.BitacoraCargaIdXML == 0)
                throw new ArgumentNullException("BitacoraCargaIdXML");
            if (comprobantes.UsuarioCambioId == 0)
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
                sentenciaSql += "	,[BitacoraCargaIdXML] = @BitacoraCargaIdXML ";
                sentenciaSql += "	,[BitacoraCargaIdPDF] = @BitacoraCargaIdPDF ";
                sentenciaSql += "	,[Activo] = @Activo ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[FolioFiscalOrig] = @FolioFiscalOrig ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[ComprobanteId] = @ComprobanteId ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("ComprobanteId", comprobantes.ComprobanteId),
                    new SqlParameter("EmisorId", comprobantes.Emisores.EmisorId),
                    new SqlParameter("ReceptorId", comprobantes.Receptores.ReceptorId),
                    new SqlParameter("TotalImpuestosRetenidos", comprobantes.TotalImpuestosRetenidos),
                    new SqlParameter("TotalImpuestosTrasladados", comprobantes.TotalImpuestosTrasladados),
                    new SqlParameter("Certificado", comprobantes.Certificado),
                    new SqlParameter("CondicionesPago", comprobantes.CondicionesPago),
                    new SqlParameter("Descuento", comprobantes.Descuento),
                    new SqlParameter("Fecha", comprobantes.Fecha),
                    new SqlParameter("FechaFolioFiscalOrig", comprobantes.FechaFolioFiscalOrig ?? (object)DBNull.Value),
                    new SqlParameter("Folio", comprobantes.Folio),
                    new SqlParameter("FormaPago", comprobantes.FormaPago),
                    new SqlParameter("LugarExpedicion", comprobantes.LugarExpedicion),
                    new SqlParameter("MetodoPago", comprobantes.MetodoPago),
                    new SqlParameter("Moneda", comprobantes.Moneda),
                    new SqlParameter("MontoFolioFiscalOrig", comprobantes.MontoFolioFiscalOrig),
                    new SqlParameter("MotivoDescuento", comprobantes.MotivoDescuento),
                    new SqlParameter("NoCertificado", comprobantes.NoCertificado),
                    new SqlParameter("NumCtaPago", comprobantes.NumCtaPago),
                    new SqlParameter("Sello", comprobantes.Sello),
                    new SqlParameter("Serie", comprobantes.Serie),
                    new SqlParameter("SerieFolioFiscalOrig", comprobantes.SerieFolioFiscalOrig),
                    new SqlParameter("SubTotal", comprobantes.SubTotal),
                    new SqlParameter("TipoCambio", comprobantes.TipoCambio),
                    new SqlParameter("TipoComprobante", comprobantes.TipoComprobante),
                    new SqlParameter("Total", comprobantes.Total),
                    new SqlParameter("Version", comprobantes.Version),
                    new SqlParameter("BitacoraCargaIdXML", comprobantes.BitacoraCargaIdXML),
                    new SqlParameter("@BitacoraCargaIdPDF", comprobantes.BitacoraCargaIdPDF ?? (Object)DBNull.Value),
                    new SqlParameter("Activo", comprobantes.Activo),
                    new SqlParameter("FolioFiscalOrig", comprobantes.FolioFiscalOrig),
                    new SqlParameter("UsuarioCambioId", comprobantes.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);
                
                return Convert.ToInt32(comprobantes.ComprobanteId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Personas Personas)

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
        public Comprobantes Cargar(int comprobanteId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable comprobanteDataTable;
            SqlParameter[] listaParametros;
            Comprobantes comprobantes = null;

            // Valida que los parámetros enviados sean correctos
            if (comprobanteId <= 0 )
                throw new ArgumentNullException("comprobanteId");

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
                sentenciaSql += "	[Comprobantes].[FolioFiscalOrig], ";
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
                sentenciaSql += "	[Comprobantes].[BitacoraCargaIdXML], ";
                sentenciaSql += "	[Comprobantes].[BitacoraCargaIdPDF], ";
                sentenciaSql += "	[Comprobantes].[Activo], ";
                sentenciaSql += "	[Comprobantes].[FechaAlta], ";
                sentenciaSql += "	[Comprobantes].[UsuarioAltaId], ";
                sentenciaSql += "	[Comprobantes].[FechaCambio], ";
                sentenciaSql += "	[Comprobantes].[UsuarioCambioId] ";
                sentenciaSql += "FROM  ";
                sentenciaSql += "	[dbo].[Comprobantes] ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	[Comprobantes].[ComprobanteId] = @ComprobanteId ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@ComprobanteId", comprobanteId)
                };

                comprobanteDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (comprobanteDataTable.Rows.Count > 0)
                {
                    comprobantes = new Comprobantes();

                    comprobantes.ComprobanteId = Convert.ToInt32(comprobanteDataTable.Rows[0]["ComprobanteId"]);
                    comprobantes.Emisores = new Emisores
                    {
                        EmisorId = Convert.ToInt32(comprobanteDataTable.Rows[0]["EmisorId"])
                    };

                    comprobantes.Receptores = new Receptores()
                    {
                        ReceptorId = Convert.ToInt32(comprobanteDataTable.Rows[0]["ReceptorId"])
                    };

                    comprobantes.TotalImpuestosRetenidos = Convert.ToDecimal(comprobanteDataTable.Rows[0]["TotalImpuestosRetenidos"]);
                    comprobantes.TotalImpuestosTrasladados = Convert.ToDecimal(comprobanteDataTable.Rows[0]["TotalImpuestosTrasladados"]);

                    comprobantes.Certificado = (comprobanteDataTable.Rows[0]["Certificado"]).ToString();
                    comprobantes.CondicionesPago = (comprobanteDataTable.Rows[0]["CondicionesPago"]).ToString();
                    comprobantes.Descuento = Convert.ToDecimal(comprobanteDataTable.Rows[0]["Descuento"]);
                    comprobantes.Fecha = Convert.ToDateTime(comprobanteDataTable.Rows[0]["Fecha"]);

                    if (comprobanteDataTable.Rows[0]["FechaFolioFiscalOrig"] == DBNull.Value)
                    {
                        comprobantes.FechaFolioFiscalOrig = null;
                    }
                    else
                    {
                        comprobantes.FechaFolioFiscalOrig = Convert.ToDateTime(comprobanteDataTable.Rows[0]["FechaFolioFiscalOrig"]);
                    }

                    comprobantes.Folio = (comprobanteDataTable.Rows[0]["Folio"]).ToString();
                    comprobantes.FolioFiscalOrig = (comprobanteDataTable.Rows[0]["FolioFiscalOrig"]).ToString();
                    comprobantes.FormaPago = (comprobanteDataTable.Rows[0]["FormaPago"]).ToString();
                    comprobantes.LugarExpedicion = (comprobanteDataTable.Rows[0]["LugarExpedicion"]).ToString();
                    comprobantes.MetodoPago = (comprobanteDataTable.Rows[0]["MetodoPago"]).ToString();
                    comprobantes.Moneda = (comprobanteDataTable.Rows[0]["Moneda"]).ToString();
                    comprobantes.MontoFolioFiscalOrig = Convert.ToDecimal(comprobanteDataTable.Rows[0]["MontoFolioFiscalOrig"]);
                    comprobantes.MotivoDescuento = (comprobanteDataTable.Rows[0]["MotivoDescuento"]).ToString();
                    comprobantes.NoCertificado = (comprobanteDataTable.Rows[0]["NoCertificado"]).ToString();
                    comprobantes.NumCtaPago = (comprobanteDataTable.Rows[0]["NumCtaPago"]).ToString();
                    comprobantes.Sello = (comprobanteDataTable.Rows[0]["Sello"]).ToString();
                    comprobantes.Serie = (comprobanteDataTable.Rows[0]["Serie"]).ToString();
                    comprobantes.SerieFolioFiscalOrig = (comprobanteDataTable.Rows[0]["SerieFolioFiscalOrig"]).ToString();
                    comprobantes.SubTotal = Convert.ToDecimal(comprobanteDataTable.Rows[0]["SubTotal"]);
                    comprobantes.TipoCambio = (comprobanteDataTable.Rows[0]["TipoCambio"]).ToString();
                    comprobantes.TipoComprobante = (comprobanteDataTable.Rows[0]["TipoComprobante"]).ToString();
                    comprobantes.Total = Convert.ToDecimal(comprobanteDataTable.Rows[0]["Total"]);
                    comprobantes.Version = (comprobanteDataTable.Rows[0]["Version"]).ToString();
                    comprobantes.BitacoraCargaIdXML = Convert.ToInt32(comprobanteDataTable.Rows[0]["BitacoraCargaIdXML"]);

                    if (comprobanteDataTable.Rows[0]["BitacoraCargaIdPDF"] == DBNull.Value)
                    {
                        comprobantes.BitacoraCargaIdPDF = null;
                    }
                    else
                    {
                        comprobantes.BitacoraCargaIdPDF = Convert.ToInt32(comprobanteDataTable.Rows[0]["BitacoraCargaIdPDF"]);
                    }

                    comprobantes.Activo = Convert.ToBoolean(comprobanteDataTable.Rows[0]["Activo"]);
                    comprobantes.FechaAlta = Convert.ToDateTime(comprobanteDataTable.Rows[0]["FechaAlta"]);
                    comprobantes.UsuarioAltaId = Convert.ToInt32(comprobanteDataTable.Rows[0]["UsuarioAltaId"]);


                    if (comprobanteDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        comprobantes.FechaCambio = null;
                    }
                    else
                    {
                        comprobantes.FechaCambio = Convert.ToDateTime(comprobanteDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (comprobanteDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        comprobantes.UsuarioCambioId = null;
                    }
                    else
                    {
                        comprobantes.UsuarioCambioId = Convert.ToInt32(comprobanteDataTable.Rows[0]["UsuarioCambioId"]);
                    }
                } // if (comprobanteDataTable.Rows.Count > 0)

                return comprobantes;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Personas Cargar(String rfc, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>   
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Julio 12 de 2014 </para>
        /// <para> Fecha de última modificación: Julio 12 de 2014 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <param name = "rfc" type = "String"></param>	    
        /// <param name = "folio" type = "String"></param>	    
        /// <param name = "serie" type = "String"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Comprobantes </returns>
        public Comprobantes Cargar(String rfc, String folio, string serie, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable comprobanteDataTable;
            SqlParameter[] listaParametros;
            Int32 comprobanteId;

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
                sentenciaSql += "	[Comprobantes].[ComprobanteId] ";
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

                var comprobanteIdDevuelto = adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros);

                if (comprobanteIdDevuelto != null)
                {
                    comprobanteId = Convert.ToInt32(comprobanteIdDevuelto);
                    return this.Cargar(comprobanteId, adsertiDataAccess);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Personas Cargar(String rfc, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>   
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Enero 27 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 27 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <returns> Comprobantes </returns>
        public List<Comprobantes> Cargar(int tamanioPagina, int indicePagina)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            String sentenciaSql = String.Empty;
            DataTable comprobanteDataTable;
            SqlParameter[] listaParametros;
            List<Comprobantes> comprobantesList = null;

            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);

            try
            {
                //Abre la conexion
                adsertiDataAccess.AbrirConexion();

                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@PageIndex", indicePagina),
                    new SqlParameter("@PageSize", tamanioPagina),
                    new SqlParameter("@RecordCount", 4) {Direction = ParameterDirection.Output}
                };

                comprobanteDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.StoredProcedure, "usp_CargarComprobates", listaParametros);

                if (comprobanteDataTable.Rows.Count <= 0) return null;

                comprobantesList = new List<Comprobantes>();

                foreach (DataRow comprobanteDataRow in comprobanteDataTable.Rows)
                {
                    Comprobantes comprobantes = new Comprobantes();

                    comprobantes.ComprobanteId = Convert.ToInt32(comprobanteDataRow["ComprobanteId"]);

                    comprobantes.Emisores = new Emisores
                    {
                        EmisorId = Convert.ToInt32(comprobanteDataRow["EmisorId"])
                    };
                    
                    // Cargar datos Receptores
                    EmisoresClass emisor = new EmisoresClass();
                    comprobantes.Emisores = emisor.Cargar(comprobantes.Emisores.EmisorId, adsertiDataAccess);

                    PersonasClass personaEmisor = new PersonasClass();
                    comprobantes.Emisores.Personas = personaEmisor.Cargar(comprobantes.Emisores.Personas.PersonaId, adsertiDataAccess);

                    comprobantes.Receptores = new Receptores()
                    {
                        ReceptorId = Convert.ToInt32(comprobanteDataRow["ReceptorId"])
                    };

                    //Cargar datos Receptores
                    ReceptoresClass receptor = new ReceptoresClass();
                    comprobantes.Receptores = receptor.Cargar(comprobantes.Receptores.ReceptorId, adsertiDataAccess);

                    PersonasClass personaReceptor = new PersonasClass();
                    comprobantes.Receptores.Personas = personaReceptor.Cargar(comprobantes.Receptores.Personas.PersonaId, adsertiDataAccess);
                    

                    comprobantes.TotalImpuestosRetenidos = Convert.ToDecimal(comprobanteDataRow["TotalImpuestosRetenidos"]);
                    comprobantes.TotalImpuestosTrasladados = Convert.ToDecimal(comprobanteDataRow["TotalImpuestosTrasladados"]);

                    comprobantes.Certificado = (comprobanteDataRow["Certificado"]).ToString();
                    comprobantes.CondicionesPago = (comprobanteDataRow["CondicionesPago"]).ToString();
                    comprobantes.Descuento = Convert.ToDecimal(comprobanteDataRow["Descuento"]);
                    comprobantes.Fecha = Convert.ToDateTime(comprobanteDataRow["Fecha"]);

                    if (comprobanteDataRow["FechaFolioFiscalOrig"] == DBNull.Value)
                    {
                        comprobantes.FechaFolioFiscalOrig = null;
                    }
                    else
                    {
                        comprobantes.FechaFolioFiscalOrig = Convert.ToDateTime(comprobanteDataRow["FechaFolioFiscalOrig"]);
                    }

                    comprobantes.Folio = (comprobanteDataRow["Folio"]).ToString();
                    comprobantes.FolioFiscalOrig = (comprobanteDataRow["FolioFiscalOrig"]).ToString();
                    comprobantes.FormaPago = (comprobanteDataRow["FormaPago"]).ToString();
                    comprobantes.LugarExpedicion = (comprobanteDataRow["LugarExpedicion"]).ToString();
                    comprobantes.MetodoPago = (comprobanteDataRow["MetodoPago"]).ToString();
                    comprobantes.Moneda = (comprobanteDataRow["Moneda"]).ToString();
                    comprobantes.MontoFolioFiscalOrig = Convert.ToDecimal(comprobanteDataRow["MontoFolioFiscalOrig"]);
                    comprobantes.MotivoDescuento = (comprobanteDataRow["MotivoDescuento"]).ToString();
                    comprobantes.NoCertificado = (comprobanteDataRow["NoCertificado"]).ToString();
                    comprobantes.NumCtaPago = (comprobanteDataRow["NumCtaPago"]).ToString();
                    comprobantes.Sello = (comprobanteDataRow["Sello"]).ToString();
                    comprobantes.Serie = (comprobanteDataRow["Serie"]).ToString();
                    comprobantes.SerieFolioFiscalOrig = (comprobanteDataRow["SerieFolioFiscalOrig"]).ToString();
                    comprobantes.SubTotal = Convert.ToDecimal(comprobanteDataRow["SubTotal"]);
                    comprobantes.TipoCambio = (comprobanteDataRow["TipoCambio"]).ToString();
                    comprobantes.TipoComprobante = (comprobanteDataRow["TipoComprobante"]).ToString();
                    comprobantes.Total = Convert.ToDecimal(comprobanteDataRow["Total"]);
                    comprobantes.Version = (comprobanteDataRow["Version"]).ToString();
                    comprobantes.BitacoraCargaIdXML = Convert.ToInt32(comprobanteDataRow["BitacoraCargaIdXML"]);
                    if (comprobanteDataRow["BitacoraCargaIdPDF"] == DBNull.Value)
                    {
                        comprobantes.BitacoraCargaIdPDF = Convert.ToInt32(comprobanteDataRow["BitacoraCargaIdPDF"]);
                    }
                    else
                    {
                        comprobantes.BitacoraCargaIdPDF = null;
                    }
                    
                    comprobantes.Activo = Convert.ToBoolean(comprobanteDataRow["Activo"]);
                    comprobantes.FechaAlta = Convert.ToDateTime(comprobanteDataRow["FechaAlta"]);
                    comprobantes.UsuarioAltaId = Convert.ToInt32(comprobanteDataRow["UsuarioAltaId"]);

                    if (comprobanteDataRow["FechaCambio"] == DBNull.Value)
                    {
                        comprobantes.FechaCambio = null;
                    }
                    else
                    {
                        comprobantes.FechaCambio = Convert.ToDateTime(comprobanteDataRow["FechaCambio"]);
                    }

                    if (comprobanteDataRow["UsuarioCambioId"] == DBNull.Value)
                    {
                        comprobantes.UsuarioCambioId = null;
                    }
                    else
                    {
                        comprobantes.UsuarioCambioId = Convert.ToInt32(comprobanteDataRow["UsuarioCambioId"]);
                    }

                    comprobantesList.Add(comprobantes);
                }

                return comprobantesList;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public List<Comprobantes> Cargar()

        /// <summary>   
        /// VincularPDF()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Enero 27 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 27 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <returns> Int32 </returns>
        public static void VincularPDF(Comprobantes comprobantes, BitacoraCargas bitacoraCargas, Int32 usuarioCambioId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable bitacoraCargaDataTable;
            SqlParameter[] listaParametros;

            // Valida que los parámetros enviados sean correctos

            if (comprobantes.ComprobanteId <= 0)
                throw new ArgumentNullException("ComprobanteId");
            if (bitacoraCargas.BitacoraCargaId <= 0)
                throw new ArgumentNullException("BitacoraCargaId");
            if(usuarioCambioId<=0)
                throw new ArgumentNullException("usuarioCambioId");

            try
            {
                sentenciaSql = "UPDATE ";
                sentenciaSql += "	[dbo].[Comprobantes] ";
                sentenciaSql += "SET ";
                sentenciaSql += "	[BitacoraCargaIdPDF] = @BitacoraCargaId, ";
                sentenciaSql += "	[FechaCambio] = getdate(), ";
                sentenciaSql += "	[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	[ComprobanteId] = @ComprobanteId ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@BitacoraCargaId", bitacoraCargas.BitacoraCargaId),
                    new SqlParameter("@ComprobanteId", comprobantes.ComprobanteId),
                    new SqlParameter("@UsuarioCambioId", usuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        }

        public Comprobantes ComprobanteArchivoXML(string nombreArchivo, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;

            // Valida que los parámetros enviados sean correctos
            if (String.IsNullOrEmpty(nombreArchivo))
                throw new ArgumentNullException("personaId");

            try
            {
                sentenciaSql = "SELECT ";
                sentenciaSql += "	ComprobanteId ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[Comprobantes] INNER JOIN [dbo].[BitacoraCargas] ";
                sentenciaSql += "		ON Comprobantes.BitacoraCargaIdXML = BitacoraCargas.BitacoraCargaId ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	Comprobantes.Activo = 1 ";
                sentenciaSql += "	AND NombreArchivo = @NombreArchivo ";

                SqlParameter[] listaParametros = new SqlParameter[1];
                listaParametros[0] = new SqlParameter("@NombreArchivo", nombreArchivo);

                object comprobanteIdDevuelto = adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros);
                Comprobantes comprobantes;

                if (comprobanteIdDevuelto != null)
                {
                    Int32 comprobanteId = Convert.ToInt32(comprobanteIdDevuelto);
                    return this.Cargar(comprobanteId, adsertiDataAccess);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        }


        /// <summary>
        /// Eliminar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Marzo 03 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 03 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Eliminar(Comprobantes comprobantes, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;


            // Valida parámetros
            if (comprobantes.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (comprobantes.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");

            try
            {
                //Configura la sentencia por ejecutar
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[Comprobantes]  ";
                sentenciaSql += "SET  ";
                sentenciaSql += "	FechaCambio = getdate(), ";
                sentenciaSql += "	UsuarioCambioId = @UsuarioCambioId, ";
                sentenciaSql += "	Activo =  0  ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	ComprobanteId = @ComprobanteId ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@BitacoraCargaId", comprobantes.ComprobanteId),
                    new SqlParameter("@UsuarioCambioId", comprobantes.UsuarioCambioId)
                };

                return Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));
                
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Personas Personas, AdsertiSqlDataAccess adsertiDataAccess)



        #endregion
    }
}
