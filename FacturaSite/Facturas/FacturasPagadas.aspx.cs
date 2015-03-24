using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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

        protected void FacturasPagadasGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string fullPath = string.Empty;

                var bitacoraId = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(bitacoraId))
                {
                    fullPath = RutaArchivoBitacora(Convert.ToInt32(bitacoraId));
                }


                if (string.IsNullOrEmpty(fullPath)) return;

                if (!File.Exists(fullPath)) return;

                string nombreArchivo = Path.GetFileName(fullPath);
                string extension = Path.GetExtension(nombreArchivo);

                var f = new FileInfo(fullPath);
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
                Response.AddHeader("Content-Length", f.Length.ToString());

                switch (extension)
                {
                    case ".pdf":
                        Response.ContentType = "application/pdf";
                        break;
                    case ".xml":
                        Response.ContentType = "text/xml";
                        break;
                    default:
                        Response.ContentType = "text/plain";
                        break;
                }
                Response.Flush();
                Response.TransmitFile(fullPath);
                Response.End();



                FacturasPagadasUpdatePanel.Update();
            }
            catch (Exception eClick)
            {
                msjLabel.Text = eClick.Message;
            }
        }

        private string RutaArchivoBitacora(Int32 bitacoraId)
        {
            BitacoraCargasBusiness bitacoraCargasBusiness = new BitacoraCargasBusiness();
            BitacoraCargas bitacoraCarga = bitacoraCargasBusiness.Cargar(bitacoraId);

            if (bitacoraCarga != null)
            {
                //string fullPath = ConfigurationManager.AppSettings["Upload"];
                var fullPath = System.Web.HttpContext.Current.Server.MapPath("~/Upload/");
                return fullPath + bitacoraCarga.NombreArchivo.Trim() + bitacoraCarga.Extension.Trim();
            }
            else
            {
                return String.Empty;
            }
        } // private string RutaArchivoBitacora(Int32 bitacoraId)


        protected void FacturasPagadasGridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView objGridView = (GridView) sender;
                GridViewRow objGridViewRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell objTableCell = new TableCell();

                AddMergedCells(objGridViewRow, objTableCell, 1, "", System.Drawing.Color.LightGreen.Name);
                AddMergedCells(objGridViewRow, objTableCell, 1, "", System.Drawing.Color.LightGreen.Name);
                AddMergedCells(objGridViewRow, objTableCell, 1, "", System.Drawing.Color.LightGreen.Name);
                AddMergedCells(objGridViewRow, objTableCell, 2, "Emisor", System.Drawing.Color.LightGreen.Name);
                AddMergedCells(objGridViewRow, objTableCell, 2, "Receptor", System.Drawing.Color.SkyBlue.Name);
                objGridView.Controls[0].Controls.AddAt(0, objGridViewRow);
            }
        }

        protected void AddMergedCells(GridViewRow objgridviewrow, TableCell objtablecell, int colspan, string celltext, string backcolor)
        {
            objtablecell = new TableCell();
            objtablecell.Text = celltext;
            objtablecell.ColumnSpan = colspan;
            objtablecell.Style.Add("background-color",backcolor);
            objtablecell.HorizontalAlign = HorizontalAlign.Center;
            objgridviewrow.Cells.Add(objtablecell);
        }
    }
}