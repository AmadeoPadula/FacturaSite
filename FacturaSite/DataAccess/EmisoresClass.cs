using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
{
    public class EmisoresClass
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
        public Int32 Agregar(Models.Emisores emisores, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            if (emisores==null)
                throw new ArgumentNullException("Emisores");
            if (emisores.DomiciliosFiscal==null)
                throw new ArgumentNullException("DomiciliosFiscal");
            if (emisores.DomiciliosExpedicion == null)
                throw new ArgumentNullException("DomiciliosExpedicion");
            if (emisores.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "INSERT INTO [dbo].[Emisores] ( ";
                sentenciaSql += "	[PersonaId] ";
                sentenciaSql += "	,[DomicilioFiscalId] ";
                sentenciaSql += "	,[DomicilioExpedicionId] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@PersonaId ";
                sentenciaSql += "	,@DomicilioFiscalId ";
                sentenciaSql += "	,@DomicilioExpedicionId ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("PersonaId", emisores.Personas.PersonaId),
                    new SqlParameter("DomicilioFiscalId", emisores.DomiciliosFiscal.DomicilioId),
                    new SqlParameter("DomicilioExpedicionId", emisores.DomiciliosExpedicion.DomicilioId),
                    new SqlParameter("UsuarioAltaId", emisores.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                emisores.EmisorId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(emisores.EmisorId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Domicilios Domicilios, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Models.Emisores emisores, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (emisores == null)
                throw new ArgumentNullException("Emisores");
            if (emisores.DomiciliosFiscal == null)
                throw new ArgumentNullException("DomiciliosFiscal");
            if (emisores.DomiciliosExpedicion == null)
                throw new ArgumentNullException("DomiciliosExpedicion");
            if (emisores.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");

            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[Emisores] ";
                sentenciaSql += "SET [PersonaId] = @PersonaId ";
                sentenciaSql += "	,[DomicilioFiscalId] = @DomicilioFiscalId ";
                sentenciaSql += "	,[DomicilioExpedicionId] = @DomicilioExpedicionId ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[EmisorId] = @EmisorId ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@EmisorId", emisores.EmisorId),
                    new SqlParameter("@PersonaId", emisores.Personas.PersonaId),
                    new SqlParameter("@DomicilioFiscalId", emisores.DomiciliosFiscal.DomicilioId),
                    new SqlParameter("@DomicilioExpedicionId", emisores.DomiciliosExpedicion.DomicilioId),
                    new SqlParameter("@UsuarioCambioId", emisores.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(emisores.EmisorId);
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
        /// <para> Fecha de creación: Enero 28 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 28 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <param name = "emisorId" type = "int"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Models.Emisores </returns>
        public Models.Emisores Cargar(int emisorId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable emisorDataTable;
            Models.Emisores emisores = null;

            // Valida que los parámetros enviados sean correctos
            if (emisorId == 0)
                throw new ArgumentNullException("emisorId");
            try
            {
                sentenciaSql = "SELECT  ";
                sentenciaSql += "	[PersonaId], ";
                sentenciaSql += "	[DomicilioFiscalId], ";
                sentenciaSql += "	[DomicilioExpedicionId], ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	[UsuarioAltaId], ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[Emisores] ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[EmisorId] = @EmisorId ";

                SqlParameter[] listaParametros = new SqlParameter[1];
                listaParametros[0] = new SqlParameter("@EmisorId", emisorId);

                emisorDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (emisorDataTable.Rows.Count > 0)
                {
                    emisores = new Emisores();

                    emisores.EmisorId = emisorId;
                    emisores.Personas.PersonaId = Convert.ToInt32(emisorDataTable.Rows[0]["PersonaId"]);
                    emisores.DomiciliosFiscal.DomicilioId = Convert.ToInt32(emisorDataTable.Rows[0]["DomicilioFiscalId"]);
                    emisores.DomiciliosExpedicion.DomicilioId = Convert.ToInt32(emisorDataTable.Rows[0]["DomicilioExpedicionId"]);
                    emisores.FechaAlta = Convert.ToDateTime((emisorDataTable.Rows[0]["FechaAlta"]));
                    emisores.UsuarioAltaId = Convert.ToInt32((emisorDataTable.Rows[0]["UsuarioAltaId"]));

                    if (emisorDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        emisores.FechaCambio = null;
                    }
                    else
                    {
                        emisores.FechaCambio = Convert.ToDateTime(emisorDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (emisorDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        emisores.UsuarioCambioId = null;
                    }
                    else
                    {
                        emisores.UsuarioCambioId = Convert.ToInt32(emisorDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } //if (clienteDataTable.Rows.Count > 0)

                return emisores;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Personas Cargar(String rfc)

        #endregion
    }
}
