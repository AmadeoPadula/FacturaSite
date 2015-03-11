using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AdsertiVS2013ClassLibrary;

namespace FacturaSite.DataAccess
{
    public class ConceptosClass
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
        public Int32 Agregar(Models.Conceptos conceptos, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (conceptos.ComprobanteId==0)
                throw new ArgumentNullException("ComprobanteId");
            if (String.IsNullOrEmpty(conceptos.NoIdentificacion))
                throw new ArgumentNullException("NoIdentificacion");
            if (conceptos.Cantidad== 0)
                throw new ArgumentNullException("Cantidad");
            if (String.IsNullOrEmpty(conceptos.Descripcion))
                throw new ArgumentNullException("Descripcion");
            if (String.IsNullOrEmpty(conceptos.Unidad))
                throw new ArgumentNullException("Unidad");
            if (conceptos.ValorUnitario == 0)
                throw new ArgumentNullException("ValorUnitario");
            if (conceptos.Importe== 0)
                throw new ArgumentNullException("Importe");
            if (conceptos.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "INSERT INTO [dbo].[Conceptos] ( ";
                sentenciaSql += "	[ComprobanteId] ";
                sentenciaSql += "	,[NoIdentificacion] ";
                sentenciaSql += "	,[Cantidad] ";
                sentenciaSql += "	,[Descripcion] ";
                sentenciaSql += "	,[Unidad] ";
                sentenciaSql += "	,[ValorUnitario] ";
                sentenciaSql += "	,[Importe] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@ComprobanteId ";
                sentenciaSql += "	,@NoIdentificacion ";
                sentenciaSql += "	,@Cantidad ";
                sentenciaSql += "	,@Descripcion ";
                sentenciaSql += "	,@Unidad ";
                sentenciaSql += "	,@ValorUnitario ";
                sentenciaSql += "	,@Importe ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@ComprobanteId", conceptos.ComprobanteId),
                    new SqlParameter("@NoIdentificacion", conceptos.NoIdentificacion),
                    new SqlParameter("@Cantidad", conceptos.Cantidad),
                    new SqlParameter("@Descripcion", conceptos.Descripcion),
                    new SqlParameter("@Unidad", conceptos.Unidad),
                    new SqlParameter("@ValorUnitario", conceptos.ValorUnitario),
                    new SqlParameter("@Importe", conceptos.Importe),
                    new SqlParameter("@UsuarioAltaId", conceptos.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                conceptos.ConceptoId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(conceptos.ConceptoId);
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
        public Int32 Actualizar(Models.Conceptos conceptos, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (conceptos.ConceptoId == 0)
                throw new ArgumentNullException("ConceptoId");
            if (conceptos.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (String.IsNullOrEmpty(conceptos.NoIdentificacion))
                throw new ArgumentNullException("NoIdentificacion");
            if (conceptos.Cantidad == 0)
                throw new ArgumentNullException("Cantidad");
            if (String.IsNullOrEmpty(conceptos.Descripcion))
                throw new ArgumentNullException("Descripcion");
            if (String.IsNullOrEmpty(conceptos.Unidad))
                throw new ArgumentNullException("Unidad");
            if (conceptos.ValorUnitario == 0)
                throw new ArgumentNullException("ValorUnitario");
            if (conceptos.Importe == 0)
                throw new ArgumentNullException("Importe");
            if (conceptos.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");

            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[Conceptos] ";
                sentenciaSql += "SET [ComprobanteId] = @ComprobanteId ";
                sentenciaSql += "	,[NoIdentificacion] = @NoIdentificacion ";
                sentenciaSql += "	,[Cantidad] = @Cantidad ";
                sentenciaSql += "	,[Descripcion] = @Descripcion ";
                sentenciaSql += "	,[Unidad] = @Unidad ";
                sentenciaSql += "	,[ValorUnitario] = @ValorUnitario ";
                sentenciaSql += "	,[Importe] = @Importe ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[ConceptoId] = @Original_ConceptoId ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@ConceptoId", conceptos.ConceptoId),
                    new SqlParameter("@ComprobanteId", conceptos.ComprobanteId),
                    new SqlParameter("@NoIdentificacion", conceptos.NoIdentificacion),
                    new SqlParameter("@Cantidad", conceptos.Cantidad),
                    new SqlParameter("@Descripcion", conceptos.Descripcion),
                    new SqlParameter("@Unidad", conceptos.Unidad),
                    new SqlParameter("@ValorUnitario", conceptos.ValorUnitario),
                    new SqlParameter("@Importe", conceptos.Importe),
                    new SqlParameter("@UsuarioCambioId", conceptos.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(conceptos.ConceptoId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Personas Personas)

        #endregion
    }
}
