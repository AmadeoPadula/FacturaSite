using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaSite.DataAccess;

namespace FacturaSite
{
    public partial class FileUploadHtml5 : System.Web.UI.Page
    {

        private static int PageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) return;

            BindDummyRow();
        }

        private void BindDummyRow()
        {
            DataTable dummyTable = new DataTable();
            dummyTable.Columns.Add("EmisorId");
            dummyTable.Columns.Add("ReceptorId");
            dummyTable.Columns.Add("TotalImpuestosRetenidos");
            dummyTable.Columns.Add("TotalImpuestosTrasladados");

            dummyTable.Rows.Add();
            FacturasGridView.DataSource = dummyTable;
            FacturasGridView.DataBind();
        }

        [WebMethod]
        public static string CargarComprobantes(int pageIndex)
        {
            ComprobantesClass comprobantesDataAccess = new ComprobantesClass();

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(comprobantesDataAccess.Cargar(PageSize, pageIndex));
            return json;
        }
    }
}