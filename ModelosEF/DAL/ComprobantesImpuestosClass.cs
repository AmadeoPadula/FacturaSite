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
    public class ComprobantesImpuestosClass
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
        public Int32 Agregar(Models.ComprobanteImpuesto comprobanteImpuesto, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (comprobanteImpuesto.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (comprobanteImpuesto.Importe == 0)
                throw new ArgumentNullException("Importe");
            if (String.IsNullOrEmpty(comprobanteImpuesto.Impuesto))
                throw new ArgumentNullException("Impuesto");
            if (comprobanteImpuesto.Tasa == 0)
                throw new ArgumentNullException("Tasa");
            if (comprobanteImpuesto.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "INSERT INTO [dbo].[ComprobantesImpuestos] ( ";
                sentenciaSql += "	[ComprobanteId] ";
                sentenciaSql += "	,[TipoImpuestoId] ";
                sentenciaSql += "	,[Importe] ";
                sentenciaSql += "	,[Impuesto] ";
                sentenciaSql += "	,[Tasa] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@ComprobanteId ";
                sentenciaSql += "	,@TipoImpuestoId ";
                sentenciaSql += "	,@Importe ";
                sentenciaSql += "	,@Impuesto ";
                sentenciaSql += "	,@Tasa ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@ComprobanteId", comprobanteImpuesto.ComprobanteId),
                    new SqlParameter("@TipoImpuestoId", (int) comprobanteImpuesto.TipoImpuesto),
                    new SqlParameter("@Importe", comprobanteImpuesto.Importe),
                    new SqlParameter("@Impuesto", comprobanteImpuesto.Impuesto),
                    new SqlParameter("@Tasa", comprobanteImpuesto.Tasa),
                    new SqlParameter("@UsuarioAltaId", comprobanteImpuesto.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                comprobanteImpuesto.ComprobanteImpuestoId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(comprobanteImpuesto.ComprobanteImpuestoId);
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
        public Int32 Actualizar(Models.ComprobanteImpuesto comprobanteImpuesto, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (comprobanteImpuesto.ComprobanteImpuestoId == 0)
                throw new ArgumentNullException("ComprobanteImpuestoId");
            if (comprobanteImpuesto.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (comprobanteImpuesto.Importe == 0)
                throw new ArgumentNullException("Importe");
            if (String.IsNullOrEmpty(comprobanteImpuesto.Impuesto))
                throw new ArgumentNullException("Impuesto");
            if (comprobanteImpuesto.Tasa == 0)
                throw new ArgumentNullException("Tasa");
            if (comprobanteImpuesto.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[ComprobantesImpuestos] ";
                sentenciaSql += "SET  ";
                sentenciaSql += "	[ComprobanteId] = @ComprobanteId ";
                sentenciaSql += "	,[TipoImpuestoId] = @TipoImpuestoId ";
                sentenciaSql += "	,[Importe] = @Importe ";
                sentenciaSql += "	,[Impuesto] = @Impuesto ";
                sentenciaSql += "	,[Tasa] = @Tasa ";
                sentenciaSql += "	,[FechaAlta] = @FechaAlta ";
                sentenciaSql += "	,[UsuarioAltaId] = @UsuarioAltaId ";
                sentenciaSql += "	,[FechaCambio] = @FechaCambio ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[ComprobanteImpuestoId] = @ComprobanteImpuestoId; ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@ComprobanteImpuestoId", comprobanteImpuesto.ComprobanteImpuestoId),
                    new SqlParameter("@ComprobanteId", comprobanteImpuesto.ComprobanteId),
                    new SqlParameter("@TipoImpuestoId", (int) comprobanteImpuesto.TipoImpuesto),
                    new SqlParameter("@Importe", comprobanteImpuesto.Importe),
                    new SqlParameter("@Impuesto", comprobanteImpuesto.Impuesto),
                    new SqlParameter("@Tasa", comprobanteImpuesto.Tasa),
                    new SqlParameter("@UsuarioAltaId", comprobanteImpuesto.UsuarioAltaId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(comprobanteImpuesto.ComprobanteImpuestoId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Persona persona)

        #endregion
    }
}
