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
    public class TimbresFiscalesDigitalesClass
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
        public Int32 Agregar(Models.TimbreFiscalDigital timbreFiscalDigital, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (timbreFiscalDigital.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (timbreFiscalDigital.FechaTimbrado == null)
                throw new ArgumentNullException("FechaTimbrado");
            if (String.IsNullOrEmpty(timbreFiscalDigital.NoCertificadoSAT))
                throw new ArgumentNullException("NoCertificadoSAT");
            if (String.IsNullOrEmpty(timbreFiscalDigital.SelloCFD))
                throw new ArgumentNullException("SelloCFD");
            if (String.IsNullOrEmpty(timbreFiscalDigital.SelloSAT))
                throw new ArgumentNullException("SelloSAT");
            if (String.IsNullOrEmpty(timbreFiscalDigital.UUID))
                throw new ArgumentNullException("UUID");
            if (String.IsNullOrEmpty(timbreFiscalDigital.Version))
                throw new ArgumentNullException("Version");
            if (timbreFiscalDigital.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "INSERT INTO [dbo].[TimbresFiscalesDigitales] ( ";
                sentenciaSql += "	[ComprobanteId] ";
                sentenciaSql += "	,[FechaTimbrado] ";
                sentenciaSql += "	,[NoCertificadoSAT] ";
                sentenciaSql += "	,[SelloCFD] ";
                sentenciaSql += "	,[SelloSAT] ";
                sentenciaSql += "	,[UUID] ";
                sentenciaSql += "	,[Version] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@ComprobanteId ";
                sentenciaSql += "	,@FechaTimbrado ";
                sentenciaSql += "	,@NoCertificadoSAT ";
                sentenciaSql += "	,@SelloCFD ";
                sentenciaSql += "	,@SelloSAT ";
                sentenciaSql += "	,@UUID ";
                sentenciaSql += "	,@Version ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@ComprobanteId", timbreFiscalDigital.ComprobanteId),
                    new SqlParameter("@FechaTimbrado", timbreFiscalDigital.FechaTimbrado),
                    new SqlParameter("@NoCertificadoSAT", timbreFiscalDigital.NoCertificadoSAT),
                    new SqlParameter("@SelloCFD", timbreFiscalDigital.SelloCFD),
                    new SqlParameter("@SelloSAT", timbreFiscalDigital.SelloSAT),
                    new SqlParameter("@UUID", timbreFiscalDigital.UUID),
                    new SqlParameter("@Version", timbreFiscalDigital.Version),
                    new SqlParameter("@UsuarioAltaId", timbreFiscalDigital.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                timbreFiscalDigital.TimbreFiscalDigitalId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(timbreFiscalDigital.TimbreFiscalDigitalId);
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
        public Int32 Actualizar(Models.TimbreFiscalDigital timbreFiscalDigital, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (timbreFiscalDigital.TimbreFiscalDigitalId == 0)
                throw new ArgumentNullException("TimbreFiscalDigitalId");
            if (timbreFiscalDigital.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (timbreFiscalDigital.FechaTimbrado == null)
                throw new ArgumentNullException("FechaTimbrado");
            if (String.IsNullOrEmpty(timbreFiscalDigital.NoCertificadoSAT))
                throw new ArgumentNullException("NoCertificadoSAT");
            if (String.IsNullOrEmpty(timbreFiscalDigital.SelloCFD))
                throw new ArgumentNullException("SelloCFD");
            if (String.IsNullOrEmpty(timbreFiscalDigital.SelloSAT))
                throw new ArgumentNullException("SelloSAT");
            if (String.IsNullOrEmpty(timbreFiscalDigital.UUID))
                throw new ArgumentNullException("UUID");
            if (String.IsNullOrEmpty(timbreFiscalDigital.Version))
                throw new ArgumentNullException("Version");
            if (timbreFiscalDigital.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");

            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[TimbresFiscalesDigitales] ";
                sentenciaSql += "SET  ";
                sentenciaSql += "	[ComprobanteId] = @ComprobanteId ";
                sentenciaSql += "	,[FechaTimbrado] = @FechaTimbrado ";
                sentenciaSql += "	,[NoCertificadoSAT] = @NoCertificadoSAT ";
                sentenciaSql += "	,[SelloCFD] = @SelloCFD ";
                sentenciaSql += "	,[SelloSAT] = @SelloSAT ";
                sentenciaSql += "	,[UUID] = @UUID ";
                sentenciaSql += "	,[Version] = @Version ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[TimbreFiscalDigitalId] = @TimbreFiscalDigitalId; ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@TimbreFiscalDigitalId", timbreFiscalDigital.TimbreFiscalDigitalId),
                    new SqlParameter("@ComprobanteId", timbreFiscalDigital.ComprobanteId),
                    new SqlParameter("@FechaTimbrado", timbreFiscalDigital.FechaTimbrado),
                    new SqlParameter("@NoCertificadoSAT", timbreFiscalDigital.NoCertificadoSAT),
                    new SqlParameter("@SelloCFD", timbreFiscalDigital.SelloCFD),
                    new SqlParameter("@SelloSAT", timbreFiscalDigital.SelloSAT),
                    new SqlParameter("@UUID", timbreFiscalDigital.UUID),
                    new SqlParameter("@Version", timbreFiscalDigital.Version),
                    new SqlParameter("@UsuarioCambioId", timbreFiscalDigital.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(timbreFiscalDigital.TimbreFiscalDigitalId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Persona persona)

        #endregion
    }
}
