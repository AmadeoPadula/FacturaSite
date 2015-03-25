using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaSite.BusinessLogic;
using FacturaSite.Models;

namespace FacturaSite.Facturas
{
    public partial class FacturasPendientes : System.Web.UI.Page
    {
        protected enum Orientacion
        {
            Columna = 1,
            Fila
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) return;

            CargarFacturasPendientes();
        }
        private void CargarFacturasPendientes()
        {
            ComprobantesBusiness comprobantesBusiness = new ComprobantesBusiness();
            FacturasPendientesGridView.DataSource = comprobantesBusiness.ComprobantesSinEvidencia();
            FacturasPendientesGridView.DataBind();
        }

        protected void FacturasPendientesGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
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



                FacturasPendientesUpdatePanel.Update();
            }
            catch (Exception eClick)
            {
                //msjLabel.Text = eClick.Message;
            }
        }

        protected void FacturasPendientesGridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                var objGridView = (GridView)sender;
                var headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerRow.Cells.Add(AgregarCeldaEncabezado(Orientacion.Fila, 2, "Fecha", "HeaderStyle azul", HorizontalAlign.Center));
                headerRow.Cells.Add(AgregarCeldaEncabezado(Orientacion.Fila, 2, "Folio y Serie", "HeaderStyle azul", HorizontalAlign.Center));

                headerRow.Cells.Add(AgregarCeldaEncabezado(Orientacion.Columna, 2, "EMISOR", "HeaderStyle azul", HorizontalAlign.Center));
                headerRow.Cells.Add(AgregarCeldaEncabezado(Orientacion.Columna, 2, "RECEPTOR", "HeaderStyle azul", HorizontalAlign.Center));
                
                headerRow.Cells.Add(AgregarCeldaEncabezado(Orientacion.Fila, 2, "Total", "HeaderStyle azul", HorizontalAlign.Center));

                objGridView.Controls[0].Controls.AddAt(0, headerRow);
            }
        }

        protected TableCell AgregarCeldaEncabezado(Orientacion orientacion, int span, string texto, string cssClass, HorizontalAlign horizontalAlign)
        {
            TableCell objTableCell = new TableCell();
            objTableCell.Text = texto;
            objTableCell.HorizontalAlign = horizontalAlign;

            switch (orientacion)
            {
                case Orientacion.Fila:
                    objTableCell.RowSpan = span;
                    break;
                case Orientacion.Columna:
                    objTableCell.ColumnSpan = span;
                    break;
            }

            objTableCell.CssClass = cssClass;

            return objTableCell;
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

        protected void FacturasPendientesGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false; // Fecha Factura
                e.Row.Cells[1].Visible = false; // Folio y Serie
                e.Row.Cells[6].Visible = false; // Total Factura

                e.Row.Cells[7].Visible = false; // Descarga XML
                e.Row.Cells[8].Visible = false; // Descarga PDF
            }
        }
    }
}