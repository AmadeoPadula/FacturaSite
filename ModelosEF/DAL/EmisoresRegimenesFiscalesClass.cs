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
    class EmisoresRegimenesFiscalesClass
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
        public void Agregar(Models.EmisorRegimenFiscal emisorRegimenFiscal, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (emisorRegimenFiscal.EmisorId == 0)
                throw new ArgumentNullException("UsuarioAltaId");
            if (emisorRegimenFiscal.RegimenFiscalId == 0)
                throw new ArgumentNullException("RegimenFiscalId");
            if (emisorRegimenFiscal.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "INSERT INTO [dbo].[EmisoresRegimenesFiscales] ( ";
                sentenciaSql += "	[EmisorId] ";
                sentenciaSql += "	,[RegimenFiscalId] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@EmisorId ";
                sentenciaSql += "	,@RegimenFiscalId ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@EmisorId", emisorRegimenFiscal.EmisorId),
                    new SqlParameter("@RegimenFiscalId", emisorRegimenFiscal.RegimenFiscalId),
                    new SqlParameter("@UsuarioAltaId", emisorRegimenFiscal.UsuarioAltaId)
                };

                adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros);
                
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Domicilio domicilio, AdsertiSqlDataAccess adsertiDataAccess)

        #endregion
    }
}
