using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaSite.BusinessLogic;

namespace FacturaSite.Resumen
{
    public partial class EvidenciaContable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FechaInicioTextBox.Text.Trim()) || string.IsNullOrEmpty(FechaFinTextBox.Text.Trim())) return;

                DateTime fechaInicio = DateTime.ParseExact(FechaInicioTextBox.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(FechaFinTextBox.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ResumenEvidenciaContableBusiness resumenEvidenciaBusiness = new ResumenEvidenciaContableBusiness();
                EvidenciaContableGridView.DataSource = resumenEvidenciaBusiness.EvidenciaContableFecha(fechaInicio, fechaFin);
                EvidenciaContableGridView.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}