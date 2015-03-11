using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;

namespace ModelosEF.DAL
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
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.Receptor receptor, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            if (receptor == null)
                throw new ArgumentNullException("emisor");
            if (receptor.Domicilio== null)
                throw new ArgumentNullException("Domicilio");
            if (receptor.UsuarioAltaId == 0)
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
                    new SqlParameter("PersonaId", receptor.Persona.PersonaId),
                    new SqlParameter("DomicilioId", receptor.Domicilio.DomicilioId),
                    new SqlParameter("UsuarioAltaId", receptor.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                receptor.ReceptorId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(receptor.ReceptorId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Domicilio domicilio, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Models.Receptor receptor, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (receptor == null)
                throw new ArgumentNullException("receptor");
            if (receptor.Domicilio == null)
                throw new ArgumentNullException("Domicilio");
            if (receptor.UsuarioCambioId == 0)
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
                    new SqlParameter("@ReceptorId", receptor.ReceptorId),
                    new SqlParameter("@PersonaId", receptor.Persona.PersonaId),
                    new SqlParameter("@DomicilioId", receptor.Domicilio.DomicilioId),
                    new SqlParameter("@UsuarioCambioId", receptor.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(receptor.ReceptorId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Persona persona)

        #endregion
    }
}
