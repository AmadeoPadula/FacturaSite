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
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.Emisor emisor, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            if (emisor==null)
                throw new ArgumentNullException("emisor");
            if (emisor.DomicilioFiscal==null)
                throw new ArgumentNullException("DomicilioFiscal");
            if (emisor.DomicilioExpedicion == null)
                throw new ArgumentNullException("DomicilioExpedicion");
            if (emisor.UsuarioAltaId == 0)
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
                    new SqlParameter("PersonaId", emisor.Persona.PersonaId),
                    new SqlParameter("DomicilioFiscalId", emisor.DomicilioFiscal.DomicilioId),
                    new SqlParameter("DomicilioExpedicionId", emisor.DomicilioExpedicion.DomicilioId),
                    new SqlParameter("UsuarioAltaId", emisor.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                emisor.EmisorId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(emisor.EmisorId);
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
        public Int32 Actualizar(Models.Emisor emisor, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (emisor == null)
                throw new ArgumentNullException("emisor");
            if (emisor.DomicilioFiscal == null)
                throw new ArgumentNullException("DomicilioFiscal");
            if (emisor.DomicilioExpedicion == null)
                throw new ArgumentNullException("DomicilioExpedicion");
            if (emisor.UsuarioCambioId == 0)
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
                    new SqlParameter("@EmisorId", emisor.EmisorId),
                    new SqlParameter("@PersonaId", emisor.Persona.PersonaId),
                    new SqlParameter("@DomicilioFiscalId", emisor.DomicilioFiscal.DomicilioId),
                    new SqlParameter("@DomicilioExpedicionId", emisor.DomicilioExpedicion.DomicilioId),
                    new SqlParameter("@UsuarioCambioId", emisor.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(emisor.EmisorId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Persona persona)

        #endregion
    }
}
