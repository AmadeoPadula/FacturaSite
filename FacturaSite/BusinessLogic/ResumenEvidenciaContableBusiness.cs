using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.DataAccess;
using FacturaSite.ModelsView;

namespace FacturaSite.BusinessLogic
{
    public class ResumenEvidenciaContableBusiness
    {
        #region * Constructor generado por Adserti *

        #endregion

        #region * Enumeraciones declaradas por Adserti *

        #endregion

        #region * Variables declaradas por Adserti *

        private static String CadenaDeConexion = ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString;

        #endregion

        #region * Propiedades declaradas por Adserti *

        #endregion

        #region * Eventos generados por Adserti *

        #endregion

        #region * Métodos creados por Adserti *

        public List<ResumenEvidenciaContable> EvidenciaContableFecha(DateTime fechaInicio,DateTime fechaFin)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                ResumenEvidenciaContableClass resumenEvidenciaContableDataAccess = new ResumenEvidenciaContableClass();
                return resumenEvidenciaContableDataAccess.EvidenciaContableFecha(fechaInicio, fechaFin, adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public static List<Empresas> CargarEmpresas()

        #endregion
    }
}