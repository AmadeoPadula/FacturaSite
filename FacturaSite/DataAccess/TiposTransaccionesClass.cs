using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
{
    public class TiposTransaccionesClass
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
        /// CargarTodos()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Marzo 03 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 03 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns> List&lt;Empresas&gt;</returns>
        public List<TiposTransacciones> CargarTodos(AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable tiposTransaccionesDataTable;
            try
            {
                sentenciaSql = "SELECT ";
                sentenciaSql += "	TipoTransaccionId, ";
                sentenciaSql += "	Identificador, ";
                sentenciaSql += "	TipoTransaccion, ";
                sentenciaSql += "	FechaAlta, ";
                sentenciaSql += "	UsuarioAltaId, ";
                sentenciaSql += "	FechaCambio, ";
                sentenciaSql += "	UsuarioCambioId ";
                sentenciaSql += "FROM  ";
                sentenciaSql += "	[dbo].[TiposTransacciones] ";


                tiposTransaccionesDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, null);

                if (tiposTransaccionesDataTable.Rows.Count > 0)
                {
                    List<TiposTransacciones> tiposTransacciones = new List<TiposTransacciones>();

                    foreach (DataRow empresaRow in tiposTransaccionesDataTable.Rows)
                    {
                        TiposTransacciones tipoTransaccion = new TiposTransacciones();

                        tipoTransaccion.TipoTransaccionId = Convert.ToInt32(empresaRow["TipoTransaccionId"]);
                        tipoTransaccion.Identificador = empresaRow["Identificador"].ToString();
                        tipoTransaccion.TipoTransaccion = empresaRow["TipoTransaccion"].ToString();

                        tipoTransaccion.FechaAlta = Convert.ToDateTime((empresaRow["FechaAlta"]));
                        tipoTransaccion.UsuarioAltaId = Convert.ToInt32((empresaRow["UsuarioAltaId"]));

                        if (empresaRow["FechaCambio"] == DBNull.Value)
                        {
                            tipoTransaccion.FechaCambio = null;
                        }
                        else
                        {
                            tipoTransaccion.FechaCambio = Convert.ToDateTime(empresaRow["FechaCambio"]);
                        }

                        if (empresaRow["UsuarioCambioId"] == DBNull.Value)
                        {
                            tipoTransaccion.UsuarioCambioId = null;
                        }
                        else
                        {
                            tipoTransaccion.UsuarioCambioId = Convert.ToInt32(empresaRow["UsuarioCambioId"]);
                        }

                        tiposTransacciones.Add(tipoTransaccion);
                    }

                    return tiposTransacciones;
                } //if (clienteDataTable.Rows.Count > 0)

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Models.Personas Cargar(String rfc)

        #endregion

    }
}