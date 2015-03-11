using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.DataAccess;

namespace FacturaSite.BusinessLogic
{
    public class BitacoraCargaBusiness
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

        /// <summary>
        /// Agregar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Febrero 13 de 2015 </para>
        /// <para> Fecha de última modificación: Febrero 13 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.BitacoraCarga bitacoraCarga)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();

                BitacoraCargasClass bitacoraCargaDataAccess = new BitacoraCargasClass();
                return bitacoraCargaDataAccess.Agregar(bitacoraCarga, adsertiDataAccess);
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