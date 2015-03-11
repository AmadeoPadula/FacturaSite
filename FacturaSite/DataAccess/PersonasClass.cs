using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
{
    public class PersonasClass
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
        public Int32 Agregar(Models.Personas personas, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (String.IsNullOrEmpty(personas.Rfc))
                throw new ArgumentNullException("Rfc");
            if (String.IsNullOrEmpty(personas.Nombre))
                throw new ArgumentNullException("Nombre");
            if (personas.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                //Configura la sentencia por ejecutar
                sentenciaSql = "INSERT INTO [DBO].[PERSONAS] ( ";
                sentenciaSql += "	[Rfc] ";
                sentenciaSql += "	,[Nombre] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@Rfc ";
                sentenciaSql += "	,@Nombre ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@Rfc", personas.Rfc),
                    new SqlParameter("@Nombre", personas.Nombre),
                    new SqlParameter("@UsuarioAltaId", personas.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";
                personas.PersonaId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(personas.PersonaId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Personas Personas, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Models.Personas personas, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (personas.PersonaId == 0)
                throw new ArgumentNullException("PersonaId");
            if (String.IsNullOrEmpty(personas.Rfc))
                throw new ArgumentNullException("Rfc");
            if (String.IsNullOrEmpty(personas.Nombre))
                throw new ArgumentNullException("Nombre");
            if (personas.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId ");

            try
            {
                sentenciaSql = "UPDATE [DBO].[PERSONAS] ";
                sentenciaSql += "SET  ";
                sentenciaSql += "	[Rfc] = @Rfc ";
                sentenciaSql += "	,[Nombre] = @Nombre ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	([PersonaId] = @PersonaId) ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@Rfc", personas.Rfc),
                    new SqlParameter("@GeneroId", personas.Nombre),
                    new SqlParameter("@UsuarioCambioId", personas.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(personas.PersonaId);
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
        /// <param name = "personaId" type = "int"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Models.Personas </returns>
        public Models.Personas Cargar(int personaId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable personaDataTable;
            Models.Personas personas = null;

            // Valida que los parámetros enviados sean correctos
            if (personaId == 0)
                throw new ArgumentNullException("personaId");
            try
            {
                sentenciaSql = "SELECT  ";
                sentenciaSql += "	[PersonaId], ";
                sentenciaSql += "	[Rfc], ";
                sentenciaSql += "	[Nombre], ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	[UsuarioAltaId], ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[Personas] ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[PersonaId] = @PersonaId ";

                SqlParameter[] listaParametros = new SqlParameter[1];
                listaParametros[0] = new SqlParameter("@PersonaId", personaId);

                personaDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (personaDataTable.Rows.Count > 0)
                {
                    personas = new Personas();

                    personas.PersonaId = Convert.ToInt32(personaDataTable.Rows[0]["PersonaId"]);
                    personas.Rfc = (personaDataTable.Rows[0]["Rfc"]).ToString();
                    personas.Nombre = (personaDataTable.Rows[0]["Nombre"]).ToString();
                    personas.FechaAlta = Convert.ToDateTime((personaDataTable.Rows[0]["FechaAlta"]));
                    personas.UsuarioAltaId = Convert.ToInt32((personaDataTable.Rows[0]["UsuarioAltaId"]));

                    if (personaDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        personas.FechaCambio = null;
                    }
                    else
                    {
                        personas.FechaCambio = Convert.ToDateTime(personaDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (personaDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        personas.UsuarioCambioId = null;
                    }
                    else
                    {
                        personas.UsuarioCambioId = Convert.ToInt32(personaDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } //if (clienteDataTable.Rows.Count > 0)

                return personas;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Personas Cargar(String rfc)

        /// <summary>   
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Julio 12 de 2014 </para>
        /// <para> Fecha de última modificación: Julio 12 de 2014 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <param name = "rfc" type = "String"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Models.Personas </returns>
        public Models.Personas Cargar(String rfc, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable personaDataTable;
            Models.Personas personas = null;

            // Valida que los parámetros enviados sean correctos
            if (String.IsNullOrEmpty(rfc))
                throw new ArgumentNullException("rfc");
            try
            {
                sentenciaSql = "SELECT  ";
                sentenciaSql += "	[PersonaId], ";
                sentenciaSql += "	[Rfc], ";
                sentenciaSql += "	[Nombre], ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	[UsuarioAltaId], ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[Personas] ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[Rfc] = @Rfc ";

                SqlParameter[] listaParametros = new SqlParameter[1];
                listaParametros[0] = new SqlParameter("@Rfc", rfc);

                personaDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (personaDataTable.Rows.Count > 0)
                {
                    personas = new Personas();

                    personas.PersonaId = Convert.ToInt32(personaDataTable.Rows[0]["PersonaId"]);
                    personas.Rfc = (personaDataTable.Rows[0]["Rfc"]).ToString();
                    personas.Nombre = (personaDataTable.Rows[0]["Nombre"]).ToString();
                    personas.FechaAlta = Convert.ToDateTime((personaDataTable.Rows[0]["FechaAlta"]));
                    personas.UsuarioAltaId = Convert.ToInt32((personaDataTable.Rows[0]["UsuarioAltaId"]));

                    if (personaDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        personas.FechaCambio = null;
                    }
                    else
                    {
                        personas.FechaCambio = Convert.ToDateTime(personaDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (personaDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        personas.UsuarioCambioId = null;
                    }
                    else
                    {
                        personas.UsuarioCambioId = Convert.ToInt32(personaDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } //if (clienteDataTable.Rows.Count > 0)

                return personas;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Personas Cargar(String rfc)

        #endregion

        }
}
