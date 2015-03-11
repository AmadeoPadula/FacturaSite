using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AdsertiVS2013ClassLibrary;
using ModelosEF.Models;

namespace ModelosEF.DAL
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
        public Int32 Agregar(Models.Persona persona, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (String.IsNullOrEmpty(persona.Rfc))
                throw new ArgumentNullException("Rfc");
            if (String.IsNullOrEmpty(persona.Nombre))
                throw new ArgumentNullException("Nombre");
            if (persona.UsuarioAltaId == 0)
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
                    new SqlParameter("@Rfc", persona.Rfc),
                    new SqlParameter("@Nombre", persona.Nombre),
                    new SqlParameter("@UsuarioAltaId", persona.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";
                persona.PersonaId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(persona.PersonaId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Persona persona, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Models.Persona persona, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (persona.PersonaId == 0)
                throw new ArgumentNullException("PersonaId");
            if (String.IsNullOrEmpty(persona.Rfc))
                throw new ArgumentNullException("Rfc");
            if (String.IsNullOrEmpty(persona.Nombre))
                throw new ArgumentNullException("Nombre");
            if (persona.UsuarioCambioId == 0)
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
                    new SqlParameter("@Rfc", persona.Rfc),
                    new SqlParameter("@GeneroId", persona.Nombre),
                    new SqlParameter("@UsuarioCambioId", persona.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(persona.PersonaId);
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
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> Models.Persona </returns>
        public Models.Persona Cargar(String rfc, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable personaDataTable;
            Models.Persona persona = null;

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
                    persona = new Persona();

                    persona.PersonaId = Convert.ToInt32(personaDataTable.Rows[0]["PersonaId"]);
                    persona.Rfc = (personaDataTable.Rows[0]["Rfc"]).ToString();
                    persona.Nombre = (personaDataTable.Rows[0]["Nombre"]).ToString();
                    persona.FechaAlta = Convert.ToDateTime((personaDataTable.Rows[0]["FechaAlta"]));
                    persona.UsuarioAltaId = Convert.ToInt32((personaDataTable.Rows[0]["UsuarioAltaId"]));

                    if (personaDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        persona.FechaCambio = null;
                    }
                    else
                    {
                        persona.FechaCambio = Convert.ToDateTime(personaDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (personaDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        persona.UsuarioCambioId = null;
                    }
                    else
                    {
                        persona.UsuarioCambioId = Convert.ToInt32(personaDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } //if (clienteDataTable.Rows.Count > 0)

                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Persona Cargar(String rfc)

        #endregion

        }
}
