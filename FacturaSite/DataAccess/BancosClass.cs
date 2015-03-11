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
    public class BancosClass
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
        public List<Bancos> CargarTodos(AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable bancosDataTable;
            try
            {
                sentenciaSql = "SELECT  ";
                sentenciaSql += "	BancoId, ";
                sentenciaSql += "	Identificador, ";
                sentenciaSql += "	Banco, ";
                sentenciaSql += "	FechaAlta, ";
                sentenciaSql += "	UsuarioAltaId, ";
                sentenciaSql += "	FechaCambio, ";
                sentenciaSql += "	UsuarioCambioId ";
                sentenciaSql += "FROM  ";
                sentenciaSql += "	[dbo].[Bancos] ";


                bancosDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, null);

                if (bancosDataTable.Rows.Count > 0)
                {
                    List<Bancos> bancos = new List<Bancos>();

                    foreach (DataRow empresaRow in bancosDataTable.Rows)
                    {
                        Bancos banco = new Bancos();

                        banco.BancoId = Convert.ToInt32(empresaRow["BancoId"]);
                        banco.Identificador = empresaRow["Identificador"].ToString();
                        banco.Banco = empresaRow["Banco"].ToString();

                        banco.FechaAlta = Convert.ToDateTime((empresaRow["FechaAlta"]));
                        banco.UsuarioAltaId = Convert.ToInt32((empresaRow["UsuarioAltaId"]));

                        if (empresaRow["FechaCambio"] == DBNull.Value)
                        {
                            banco.FechaCambio = null;
                        }
                        else
                        {
                            banco.FechaCambio = Convert.ToDateTime(empresaRow["FechaCambio"]);
                        }

                        if (empresaRow["UsuarioCambioId"] == DBNull.Value)
                        {
                            banco.UsuarioCambioId = null;
                        }
                        else
                        {
                            banco.UsuarioCambioId = Convert.ToInt32(empresaRow["UsuarioCambioId"]);
                        }

                        bancos.Add(banco);
                    }

                    return bancos;
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