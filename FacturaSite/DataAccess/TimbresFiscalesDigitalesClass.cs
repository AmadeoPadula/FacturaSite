using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;

namespace FacturaSite.DataAccess
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
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.TimbresFiscalesDigitales timbresFiscalesDigitales, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (timbresFiscalesDigitales.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (timbresFiscalesDigitales.FechaTimbrado == null)
                throw new ArgumentNullException("FechaTimbrado");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.NoCertificadoSAT))
                throw new ArgumentNullException("NoCertificadoSAT");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.SelloCFD))
                throw new ArgumentNullException("SelloCFD");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.SelloSAT))
                throw new ArgumentNullException("SelloSAT");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.UUID))
                throw new ArgumentNullException("UUID");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.Version))
                throw new ArgumentNullException("Version");
            if (timbresFiscalesDigitales.UsuarioAltaId == 0)
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
                    new SqlParameter("@ComprobanteId", timbresFiscalesDigitales.ComprobanteId),
                    new SqlParameter("@FechaTimbrado", timbresFiscalesDigitales.FechaTimbrado),
                    new SqlParameter("@NoCertificadoSAT", timbresFiscalesDigitales.NoCertificadoSAT),
                    new SqlParameter("@SelloCFD", timbresFiscalesDigitales.SelloCFD),
                    new SqlParameter("@SelloSAT", timbresFiscalesDigitales.SelloSAT),
                    new SqlParameter("@UUID", timbresFiscalesDigitales.UUID),
                    new SqlParameter("@Version", timbresFiscalesDigitales.Version),
                    new SqlParameter("@UsuarioAltaId", timbresFiscalesDigitales.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                timbresFiscalesDigitales.TimbreFiscalDigitalId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(timbresFiscalesDigitales.TimbreFiscalDigitalId);
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
        public Int32 Actualizar(Models.TimbresFiscalesDigitales timbresFiscalesDigitales, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (timbresFiscalesDigitales.TimbreFiscalDigitalId == 0)
                throw new ArgumentNullException("TimbreFiscalDigitalId");
            if (timbresFiscalesDigitales.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (timbresFiscalesDigitales.FechaTimbrado == null)
                throw new ArgumentNullException("FechaTimbrado");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.NoCertificadoSAT))
                throw new ArgumentNullException("NoCertificadoSAT");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.SelloCFD))
                throw new ArgumentNullException("SelloCFD");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.SelloSAT))
                throw new ArgumentNullException("SelloSAT");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.UUID))
                throw new ArgumentNullException("UUID");
            if (String.IsNullOrEmpty(timbresFiscalesDigitales.Version))
                throw new ArgumentNullException("Version");
            if (timbresFiscalesDigitales.UsuarioCambioId == 0)
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
                    new SqlParameter("@TimbreFiscalDigitalId", timbresFiscalesDigitales.TimbreFiscalDigitalId),
                    new SqlParameter("@ComprobanteId", timbresFiscalesDigitales.ComprobanteId),
                    new SqlParameter("@FechaTimbrado", timbresFiscalesDigitales.FechaTimbrado),
                    new SqlParameter("@NoCertificadoSAT", timbresFiscalesDigitales.NoCertificadoSAT),
                    new SqlParameter("@SelloCFD", timbresFiscalesDigitales.SelloCFD),
                    new SqlParameter("@SelloSAT", timbresFiscalesDigitales.SelloSAT),
                    new SqlParameter("@UUID", timbresFiscalesDigitales.UUID),
                    new SqlParameter("@Version", timbresFiscalesDigitales.Version),
                    new SqlParameter("@UsuarioCambioId", timbresFiscalesDigitales.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(timbresFiscalesDigitales.TimbreFiscalDigitalId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Personas Personas)

        #endregion
    }
}
