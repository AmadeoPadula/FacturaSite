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
    public class BitacoraCargasBusiness
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
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.BitacoraCargas bitacoraCargas)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();

                BitacoraCargasClass bitacoraCargaDataAccess = new BitacoraCargasClass();
                return bitacoraCargaDataAccess.Agregar(bitacoraCargas, adsertiDataAccess);
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

        /// <summary>
        /// PDFSinFactura()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Febrero 13 de 2015 </para>
        /// <para> Fecha de última modificación: Febrero 13 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public BitacoraCargas PDFSinFactura(string nombreArchivo)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();

                BitacoraCargasClass bitacoraCargaDataAccess = new BitacoraCargasClass();
                return bitacoraCargaDataAccess.PDFSinFactura(nombreArchivo, adsertiDataAccess);
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

        /// <summary>
        /// CargarSinClasificar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Marzo 03 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 03 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public List<BitacoraCargas> CargasSinClasificar()
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();
                BitacoraCargasClass bitacoraCargaDataAccess = new BitacoraCargasClass();
                return bitacoraCargaDataAccess.CargasSinClasificar(adsertiDataAccess);
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


        /// <summary>
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Febrero 13 de 2015 </para>
        /// <para> Fecha de última modificación: Febrero 13 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public BitacoraCargas Cargar(Int32 bitacoraId)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();

                BitacoraCargasClass bitacoraCargaDataAccess = new BitacoraCargasClass();
                return bitacoraCargaDataAccess.Cargar(bitacoraId, adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public BitacoraCargas Cargar(Int32 bitacoraId)

        /// <summary>
        /// Eliminar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Marzo 18 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 18 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public void Eiminar(Int32 bitacoraId)
        {
            AdsertiSqlDataAccess adsertiDataAccess;
            // Instancía la clase de acceso a datos
            adsertiDataAccess = new AdsertiSqlDataAccess(CadenaDeConexion);
            try
            {
                adsertiDataAccess.AbrirConexion();

                BitacoraCargasClass bitacoraCargaDataAccess = new BitacoraCargasClass();
                BitacoraCargas bitacoraCarga = bitacoraCargaDataAccess.Cargar(bitacoraId, adsertiDataAccess);

                //Validar si existe el elemento
                if (bitacoraCarga != null)
                    bitacoraCargaDataAccess.Eliminar(bitacoraCarga, adsertiDataAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
            finally
            {
                adsertiDataAccess.CerrarConexion();
            } //finally
        } // public void Eiminar(Int32 bitacoraId)


        #endregion

    }
}