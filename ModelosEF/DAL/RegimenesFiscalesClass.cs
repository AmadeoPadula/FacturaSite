using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;
using ModelosEF.Models;

namespace ModelosEF.DAL
{
    public class RegimenesFiscalesClass
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
        public Int32 Agregar(Models.RegimenFiscal regimenFiscal, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (String.IsNullOrEmpty(regimenFiscal.RegimenFiscalDescripcion))
                throw new ArgumentNullException("RegimenFiscalDescripcion");
            if (regimenFiscal.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");
            try
            {
                //Configura la sentencia por ejecutar
                sentenciaSql = "INSERT INTO [dbo].[RegimenesFiscales] ( ";
                sentenciaSql += "	[RegimenFiscal] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@RegimenFiscal ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@RegimenFiscal", regimenFiscal.RegimenFiscalDescripcion),
                    new SqlParameter("@UsuarioAltaId", regimenFiscal.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                regimenFiscal.RegimenFiscalId= Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));
                
                return Convert.ToInt32(regimenFiscal.RegimenFiscalId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.RegimenFiscal regimenFiscal, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Models.RegimenFiscal regimenFiscal, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (regimenFiscal.RegimenFiscalId== 0)
                throw new ArgumentNullException("PersonaId");
            if (String.IsNullOrEmpty(regimenFiscal.RegimenFiscalDescripcion))
                throw new ArgumentNullException("RegimenFiscalDescripcion");
            if (regimenFiscal.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId ");
            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[RegimenesFiscales] ";
                sentenciaSql += "SET  ";
                sentenciaSql += "	[RegimenFiscal] = @RegimenFiscal ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[RegimenFiscalId] = @RegimenFiscalId; ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("RegimenFiscalId", regimenFiscal.RegimenFiscalId),
                    new SqlParameter("@RegimenFiscal", regimenFiscal.RegimenFiscalDescripcion),
                    new SqlParameter("@UsuarioCambioId", regimenFiscal.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(regimenFiscal.RegimenFiscalId);
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
        /// <param name = "regimenFiscal" type = "String"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Models.Persona </returns>
        public Models.RegimenFiscal Cargar(String regimenFiscalDescripcion, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable regimenFiscalDataTable;
            Models.RegimenFiscal regimenFiscal = null;

            // Valida que los parámetros enviados sean correctos
            if (String.IsNullOrEmpty(regimenFiscalDescripcion))
                throw new ArgumentNullException("regimenFiscal");
            try
            {
                sentenciaSql = "SELECT ";
                sentenciaSql += "	[RegimenesFiscales].[RegimenFiscalId], ";
                sentenciaSql += "	[RegimenesFiscales].[RegimenFiscal], ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	[RegimenesFiscales].[UsuarioAltaId], ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	[RegimenesFiscales].[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[RegimenesFiscales] ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[RegimenFiscal] = @RegimenFiscal ";

                SqlParameter[] listaParametros = new SqlParameter[1];
                listaParametros[0] = new SqlParameter("@RegimenFiscal", regimenFiscalDescripcion);

                regimenFiscalDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (regimenFiscalDataTable.Rows.Count > 0)
                {
                    regimenFiscal = new RegimenFiscal();

                    regimenFiscal.RegimenFiscalId = Convert.ToInt32(regimenFiscalDataTable.Rows[0]["RegimenFiscalId"]);
                    regimenFiscal.RegimenFiscalDescripcion = (regimenFiscalDataTable.Rows[0]["RegimenFiscal"]).ToString();
                    regimenFiscal.FechaAlta = Convert.ToDateTime((regimenFiscalDataTable.Rows[0]["FechaAlta"]));
                    regimenFiscal.UsuarioAltaId = Convert.ToInt32((regimenFiscalDataTable.Rows[0]["UsuarioAltaId"]));

                    if (regimenFiscalDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        regimenFiscal.FechaCambio = null;
                    }
                    else
                    {
                        regimenFiscal.FechaCambio = Convert.ToDateTime(regimenFiscalDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (regimenFiscalDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        regimenFiscal.UsuarioCambioId = null;
                    }
                    else
                    {
                        regimenFiscal.UsuarioCambioId = Convert.ToInt32(regimenFiscalDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } //if (clienteDataTable.Rows.Count > 0)

                return regimenFiscal;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Persona Cargar(String rfc)





        #endregion
    }
}
