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
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.Concepto concepto, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (concepto.ComprobanteId==0)
                throw new ArgumentNullException("ComprobanteId");
            if (String.IsNullOrEmpty(concepto.NoIdentificacion))
                throw new ArgumentNullException("NoIdentificacion");
            if (concepto.Cantidad== 0)
                throw new ArgumentNullException("Cantidad");
            if (String.IsNullOrEmpty(concepto.Descripcion))
                throw new ArgumentNullException("Descripcion");
            if (String.IsNullOrEmpty(concepto.Unidad))
                throw new ArgumentNullException("Unidad");
            if (concepto.ValorUnitario == 0)
                throw new ArgumentNullException("ValorUnitario");
            if (concepto.Importe== 0)
                throw new ArgumentNullException("Importe");
            if (concepto.UsuarioAltaId == 0)
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
                    new SqlParameter("@ComprobanteId", concepto.ComprobanteId),
                    new SqlParameter("@NoIdentificacion", concepto.NoIdentificacion),
                    new SqlParameter("@Cantidad", concepto.Cantidad),
                    new SqlParameter("@Descripcion", concepto.Descripcion),
                    new SqlParameter("@Unidad", concepto.Unidad),
                    new SqlParameter("@ValorUnitario", concepto.ValorUnitario),
                    new SqlParameter("@Importe", concepto.Importe),
                    new SqlParameter("@UsuarioAltaId", concepto.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                concepto.ConceptoId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(concepto.ConceptoId);
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
        public Int32 Actualizar(Models.Concepto concepto, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (concepto.ConceptoId == 0)
                throw new ArgumentNullException("ConceptoId");
            if (concepto.ComprobanteId == 0)
                throw new ArgumentNullException("ComprobanteId");
            if (String.IsNullOrEmpty(concepto.NoIdentificacion))
                throw new ArgumentNullException("NoIdentificacion");
            if (concepto.Cantidad == 0)
                throw new ArgumentNullException("Cantidad");
            if (String.IsNullOrEmpty(concepto.Descripcion))
                throw new ArgumentNullException("Descripcion");
            if (String.IsNullOrEmpty(concepto.Unidad))
                throw new ArgumentNullException("Unidad");
            if (concepto.ValorUnitario == 0)
                throw new ArgumentNullException("ValorUnitario");
            if (concepto.Importe == 0)
                throw new ArgumentNullException("Importe");
            if (concepto.UsuarioCambioId == 0)
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
                    new SqlParameter("@ConceptoId", concepto.ConceptoId),
                    new SqlParameter("@ComprobanteId", concepto.ComprobanteId),
                    new SqlParameter("@NoIdentificacion", concepto.NoIdentificacion),
                    new SqlParameter("@Cantidad", concepto.Cantidad),
                    new SqlParameter("@Descripcion", concepto.Descripcion),
                    new SqlParameter("@Unidad", concepto.Unidad),
                    new SqlParameter("@ValorUnitario", concepto.ValorUnitario),
                    new SqlParameter("@Importe", concepto.Importe),
                    new SqlParameter("@UsuarioCambioId", concepto.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(concepto.ConceptoId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Persona persona)

        #endregion
    }
}
