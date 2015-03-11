using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.DataAccess;
using FacturaSite.Models;

namespace FacturaSite.BusinessLogic
{
    public class EvidenciasBusiness
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

        public static List<Bancos> CargarBancos()
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                BancosClass bancosDataAccess = new BancosClass();
                return bancosDataAccess.CargarTodos(adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        }

        public static List<Empresas> CargarEmpresas()
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                EmpresasClass empresasDataAccess = new EmpresasClass();
                return empresasDataAccess.CargarTodos(adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        }


        public static List<TiposTransacciones> CargarTiposTransacciones()
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                TiposTransaccionesClass tiposTransaccionesDataAccess = new TiposTransaccionesClass();
                return tiposTransaccionesDataAccess.CargarTodos(adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        }

        #endregion

    }
}