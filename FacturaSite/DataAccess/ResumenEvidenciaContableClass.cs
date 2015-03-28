using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;
using FacturaSite.ModelsView;

namespace FacturaSite.DataAccess
{
    public class ResumenEvidenciaContableClass
    {
        /// <summary>   
        /// EvidenciaContableFecha()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez</para>
        /// <para> Fecha de creación: Marzo 27 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 27 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        /// <returns> Comprobantes </returns>
        public List<ResumenEvidenciaContable> EvidenciaContableFecha(DateTime fechaInicio, DateTime fechaFin, AdsertiSqlDataAccess adsertiDataAccess)
        {
            DataTable evidenciaContableDataTable;
            SqlParameter[] listaParametros;
            List<ResumenEvidenciaContable> evidenciaContableList = null;

            try
            {
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@FechaInicio", fechaInicio),
                    new SqlParameter("@FechaFin", fechaFin)
                };

                evidenciaContableDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.StoredProcedure, "usp_EvidenciaContableFechaFactura", listaParametros);

                if (evidenciaContableDataTable.Rows.Count <= 0) return null;

                evidenciaContableList = new List<ResumenEvidenciaContable>();

                foreach (DataRow evidenciaContableDataRow in evidenciaContableDataTable.Rows)
                {
                    ResumenEvidenciaContable evidenciaContable = new ResumenEvidenciaContable();

                    if (evidenciaContableDataRow["OperacionId"] == DBNull.Value)
                        evidenciaContable.OperacionId = null;
                    else
                        evidenciaContable.OperacionId = Convert.ToInt32(evidenciaContableDataRow["OperacionId"]);
                    
                    evidenciaContable.TipoTransaccion = (evidenciaContableDataRow["TipoTransaccion"]).ToString();
                    
                    evidenciaContable.Total = Convert.ToDecimal(evidenciaContableDataRow["Total"]);

                    evidenciaContableList.Add(evidenciaContable);
                }

                return evidenciaContableList;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public List<ResumenEvidenciaContable> EvidenciaContableFecha(DateTime fechaInicio, DateTime fechaFin, AdsertiSqlDataAccess adsertiDataAccess)
    }
}