using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
{
    public class ReceptoresClass
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
        public Int32 Agregar(Models.Receptores receptores, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            if (receptores == null)
                throw new ArgumentNullException("emisor");
            if (receptores.Domicilios== null)
                throw new ArgumentNullException("Domicilios");
            if (receptores.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "INSERT INTO [dbo].[Receptores] ( ";
                sentenciaSql += "	[PersonaId] ";
                sentenciaSql += "	,[DomicilioId] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@PersonaId ";
                sentenciaSql += "	,@DomicilioId ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("PersonaId", receptores.Personas.PersonaId),
                    new SqlParameter("DomicilioId", receptores.Domicilios.DomicilioId),
                    new SqlParameter("UsuarioAltaId", receptores.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                receptores.ReceptorId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(receptores.ReceptorId);
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
        public Int32 Actualizar(Models.Receptores receptores, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (receptores == null)
                throw new ArgumentNullException("Receptores");
            if (receptores.Domicilios == null)
                throw new ArgumentNullException("Domicilios");
            if (receptores.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");

            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[Receptores] ";
                sentenciaSql += "SET [PersonaId] = @PersonaId ";
                sentenciaSql += "	,[DomicilioId] = @DomicilioId ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[ReceptorId] = @ReceptorId ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@ReceptorId", receptores.ReceptorId),
                    new SqlParameter("@PersonaId", receptores.Personas.PersonaId),
                    new SqlParameter("@DomicilioId", receptores.Domicilios.DomicilioId),
                    new SqlParameter("@UsuarioCambioId", receptores.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(receptores.ReceptorId);
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
        /// <returns> Models.Receptores </returns>
        public Models.Receptores Cargar(int receptorId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable receptorDataTable;
            Models.Receptores receptores = null;

            // Valida que los parámetros enviados sean correctos
            if (receptorId == 0)
                throw new ArgumentNullException("emisorId");
            try
            {
                sentenciaSql = "SELECT  ";
                sentenciaSql += "	[PersonaId], ";
                sentenciaSql += "	[DomicilioId], ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	[UsuarioAltaId], ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[Receptores] ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[ReceptorId] = @ReceptorId ";

                SqlParameter[] listaParametros = new SqlParameter[1];
                listaParametros[0] = new SqlParameter("@ReceptorId", receptorId);

                receptorDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (receptorDataTable.Rows.Count > 0)
                {
                    receptores = new Receptores();

                    receptores.ReceptorId = receptorId;
                    receptores.Personas.PersonaId = Convert.ToInt32(receptorDataTable.Rows[0]["PersonaId"]);
                    receptores.Domicilios.DomicilioId = Convert.ToInt32(receptorDataTable.Rows[0]["DomicilioId"]);
                    receptores.FechaAlta = Convert.ToDateTime((receptorDataTable.Rows[0]["FechaAlta"]));
                    receptores.UsuarioAltaId = Convert.ToInt32((receptorDataTable.Rows[0]["UsuarioAltaId"]));

                    if (receptorDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        receptores.FechaCambio = null;
                    }
                    else
                    {
                        receptores.FechaCambio = Convert.ToDateTime(receptorDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (receptorDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        receptores.UsuarioCambioId = null;
                    }
                    else
                    {
                        receptores.UsuarioCambioId = Convert.ToInt32(receptorDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } //if (clienteDataTable.Rows.Count > 0)

                return receptores;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Personas Cargar(String rfc)


        #endregion
    }
}
