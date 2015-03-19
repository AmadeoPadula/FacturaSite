using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
{
    public class EmpresasClass
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
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Marzo 18 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 18 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <param name = "empresaId" type = "Int32"></param>	    
        /// <param name = "adsertiDataAccess" type = "AdsertiSqlDataAccess"></param>	    
        /// <returns>Bancos</returns>
        public Empresas Cargar(Int32 empresaId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable empresasDataTable;
            Models.Empresas empresa = null;

            if (empresaId < 1)
                throw new ArgumentNullException("empresaId");

            try
            {
                sentenciaSql = "SELECT ";
                sentenciaSql += "	EmpresaId, ";
                sentenciaSql += "	Identificador, ";
                sentenciaSql += "	Empresa, ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	UsuarioAltaId, ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	UsuarioCambioId ";
                sentenciaSql += "FROM  ";
                sentenciaSql += "	[dbo].[Empresas] ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	EmpresaId = @EmpresaId ";

                SqlParameter[] listaParametros = new SqlParameter[1];
                listaParametros[0] = new SqlParameter("@EmpresaId", empresaId);

                empresasDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (empresasDataTable.Rows.Count > 0)
                {
                    empresa = new Empresas();

                    empresa.EmpresaId = Convert.ToInt32(empresasDataTable.Rows[0]["EmpresaId"]);
                    empresa.Identificador = empresasDataTable.Rows[0]["Identificador"].ToString();
                    empresa.Empresa = empresasDataTable.Rows[0]["Empresa"].ToString();

                    empresa.FechaAlta = Convert.ToDateTime((empresasDataTable.Rows[0]["FechaAlta"]));
                    empresa.UsuarioAltaId = Convert.ToInt32((empresasDataTable.Rows[0]["UsuarioAltaId"]));

                    if (empresasDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        empresa.FechaCambio = null;
                    }
                    else
                    {
                        empresa.FechaCambio = Convert.ToDateTime(empresasDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (empresasDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        empresa.UsuarioCambioId = null;
                    }
                    else
                    {
                        empresa.UsuarioCambioId = Convert.ToInt32(empresasDataTable.Rows[0]["UsuarioCambioId"]);
                    }
                }

                return empresa;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Empresas Cargar(Int32 empresaId, AdsertiSqlDataAccess adsertiDataAccess)


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
        public List<Empresas> CargarTodos(AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable empresasDataTable;
            try
            {
                sentenciaSql = "SELECT ";
                sentenciaSql += "	EmpresaId, ";
                sentenciaSql += "	Identificador, ";
                sentenciaSql += "	Empresa, ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	UsuarioAltaId, ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	UsuarioCambioId ";
                sentenciaSql += "FROM  ";
                sentenciaSql += "	[dbo].[Empresas] ";


                empresasDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, null);

                if (empresasDataTable.Rows.Count > 0)
                {
                    List<Empresas> empresas = new List<Empresas>();

                    foreach (DataRow empresaRow in empresasDataTable.Rows)
                    {
                        Empresas empresa = new Empresas();

                        empresa.EmpresaId = Convert.ToInt32(empresaRow["EmpresaId"]);
                        empresa.Identificador = empresaRow["Identificador"].ToString();
                        empresa.Empresa = empresaRow["Empresa"].ToString();

                        empresa.FechaAlta = Convert.ToDateTime((empresaRow["FechaAlta"]));
                        empresa.UsuarioAltaId = Convert.ToInt32((empresaRow["UsuarioAltaId"]));

                        if (empresaRow["FechaCambio"] == DBNull.Value)
                        {
                            empresa.FechaCambio = null;
                        }
                        else
                        {
                            empresa.FechaCambio = Convert.ToDateTime(empresaRow["FechaCambio"]);
                        }

                        if (empresaRow["UsuarioCambioId"] == DBNull.Value)
                        {
                            empresa.UsuarioCambioId = null;
                        }
                        else
                        {
                            empresa.UsuarioCambioId = Convert.ToInt32(empresaRow["UsuarioCambioId"]);
                        }

                        empresas.Add(empresa);
                    }

                    return empresas;
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