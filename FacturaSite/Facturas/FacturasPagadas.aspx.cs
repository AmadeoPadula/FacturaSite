using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaSite.BusinessLogic;
using FacturaSite.Documentos;
using FacturaSite.Models;

namespace FacturaSite.Facturas
{
    public partial class FacturasPagadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) return;

            CargarFacturasPagadas();
        }

        private void CargarFacturasPagadas()
        {
            ComprobantesBusiness comprobantesBusiness = new ComprobantesBusiness();
            FacturasPagadasGridView.DataSource = comprobantesBusiness.ComprobantesConEvidencia();
            FacturasPagadasGridView.DataBind();
        }
    }
}