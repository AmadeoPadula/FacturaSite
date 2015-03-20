using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaSite.BusinessLogic;
using FacturaSite.Models;

namespace FacturaSite.Evidencias
{
    public partial class EvidenciasSinClasificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarEvidenciaSinClasificar();
                CargarBancos();
                CargarEmpresas();
                CargarTiposTransacciones();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<Comprobantes> AutoArrayList()
        {
            ComprobantesBusiness comprobantes = new ComprobantesBusiness();

            return comprobantes.ComprobantesSinEvidencia();
        }

        protected void CargarBancos()
        {
            ListItem vacioListItem;

            BancoDropDownList.DataSource = EvidenciasBusiness.CargarBancos();
            BancoDropDownList.DataTextField = "Banco";
            BancoDropDownList.DataValueField = "BancoId";
            BancoDropDownList.DataBind();

            vacioListItem = new ListItem("- Seleccione una opción -", string.Empty);

            // Agrega el listitem de selección al dropdownlist en la primera posición
            BancoDropDownList.Items.Insert(0, vacioListItem);
        }

        protected void CargarEmpresas()
        {
            ListItem vacioListItem;

            EmpresaDropDownList.DataSource = EvidenciasBusiness.CargarEmpresas();
            EmpresaDropDownList.DataTextField = "Empresa";
            EmpresaDropDownList.DataValueField = "EmpresaId";
            EmpresaDropDownList.DataBind();

            vacioListItem = new ListItem("- Seleccione una opción -", string.Empty);

            // Agrega el listitem de selección al dropdownlist en la primera posición
            EmpresaDropDownList.Items.Insert(0, vacioListItem);
        }

        protected void CargarTiposTransacciones()
        {
            ListItem vacioListItem;

            TipoTransaccionDropDownList.DataSource = EvidenciasBusiness.CargarTiposTransacciones();
            TipoTransaccionDropDownList.DataTextField = "TipoTransaccion";
            TipoTransaccionDropDownList.DataValueField = "TipoTransaccionId";
            TipoTransaccionDropDownList.DataBind();

            vacioListItem = new ListItem("- Seleccione una opción -", string.Empty);

            // Agrega el listitem de selección al dropdownlist en la primera posición
            TipoTransaccionDropDownList.Items.Insert(0, vacioListItem);
        } // protected void CargarTiposTransacciones()

        protected void CargarEvidenciaSinClasificar()
        {
            BitacoraCargasBusiness bitacoraCargasBusiness = new BitacoraCargasBusiness();
            EvidenciasSinClasificarGridView.DataSource = bitacoraCargasBusiness.CargasSinClasificar();
            EvidenciasSinClasificarGridView.DataBind();
        } // protected void CargarEvidenciaSinClasificar()

        protected void EvidenciasSinClasificarGridView_OnPageIndexChanged(object sender, EventArgs e)
        {
            CargarEvidenciaSinClasificar();
        } // protected void EvidenciasSinClasificarGridView_OnPageIndexChanged(object sender, EventArgs e)

        protected void EvidenciasSinClasificarGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EvidenciasSinClasificarGridView.PageIndex = e.NewPageIndex;
            EvidenciasSinClasificarGridView.DataBind();
        } // protected void EvidenciasSinClasificarGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)

        protected void EvidenciasSinClasificarGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "select":
                    LimpiarVentanaModal();
                    TraerInfoBitacora(Convert.ToInt32(e.CommandArgument));
                    MostarVentanaModal(true);
                    break;
            }
        } // protected void EvidenciasSinClasificarGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)

        protected void MostarVentanaModal(Boolean valor, String mensaje = "")
        {
            if (valor)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Script", "ShowModal()", true);
            }
            else
            {
                String script = string.Empty;
                script = String.Format("CloseModal('{0}');", mensaje);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Script", script, true);
            }
        } // protected void MostarVentanaModal(Boolean valor, String mensaje = "")

        protected void TraerInfoBitacora(Int32 bitacoraId)
        {
            BitacoraCargasBusiness bitacoraBusiness = new BitacoraCargasBusiness();
            BitacoraCargas bitacoraCarga = bitacoraBusiness.Cargar(bitacoraId);

            this.BitacoraCargaIdHiddenField.Value = bitacoraCarga.BitacoraCargaId.ToString();

            LimpiarVentanaModal();
        } // protected void TraerInfoBitacora(Int32 bitacoraId)

        protected void GuardarEvidencia()
        {
            var evidencia = new Models.Evidencias();

            evidencia.Empresa = new Empresas()
            {
                EmpresaId = Convert.ToInt32(EmpresaDropDownList.SelectedValue)
            };

            evidencia.Banco = new Bancos()
            {
                BancoId = Convert.ToInt32(BancoDropDownList.SelectedValue)
            };

            evidencia.TipoTransaccion = new TiposTransacciones()
            {
                TipoTransaccionId = Convert.ToInt32(TipoTransaccionDropDownList.SelectedValue)
            };

            evidencia.NumeroTransferencia = NumeroTransferenciaTextBox.Text.Trim();
            evidencia.FechaPago = DateTime.ParseExact(FechaPagoTextBox.Text.Trim(), "dd/MM/yyyy", null);
            evidencia.MontoPago = Convert.ToDecimal(AdsertiVS2013ClassLibrary.AdsertiFunciones.FormatearNumero(this.MontoPagoTextBox.Text));
            //evidencia.BitacoraCargaId = Convert.ToInt32(FacturaPagadaDropDownList.SelectedValue);
            evidencia.Comprobante = new Comprobantes(){
                ComprobanteId = Convert.ToInt32(FacturaSeleccionadaHiddenField.Value)
            };

            evidencia.BitacoraCargaId = Convert.ToInt32(BitacoraCargaIdHiddenField.Value);
            evidencia.UsuarioAltaId = 1;

            EvidenciasBusiness evidenciasBusiness = new EvidenciasBusiness();
            evidenciasBusiness.Agregar(evidencia);
        } // protected void GuardarEvidencia()

        protected void LimpiarVentanaModal()
        {
            EmpresaDropDownList.Text = string.Empty;
            BancoDropDownList.Text = string.Empty;
            TipoTransaccionDropDownList.Text = string.Empty;
            NumeroTransferenciaTextBox.Text = string.Empty;
            FechaPagoTextBox.Text = string.Empty;
            MontoPagoTextBox.Text = string.Empty;
            //NoFacturaPagadaTextBox.Text = string.Empty;
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();
            String id = string.Empty;

            for (int i = 0; i < EvidenciasSinClasificarGridView.Rows.Count; i++)
            {
                CheckBox cs = (CheckBox) EvidenciasSinClasificarGridView.Rows[i].Cells[2].FindControl("chkEliminarCheckBox");
                if (cs == null) continue;
                if (!cs.Checked) continue;
                HiddenField hf = (HiddenField) EvidenciasSinClasificarGridView.Rows[i].Cells[2].FindControl("BitacoraCargaIdHiddenField");
                id = hf.Value;
                sc.Add(id);
            }

            if (sc.Count > 0)
            {
                foreach (var item in sc)
                {
                    BorrarEntradaBitacoraCarga(item);
                }
                CargarEvidenciaSinClasificar();
            }
        } // protected void btnDelete_OnClick(object sender, EventArgs e)

        protected void BorrarEntradaBitacoraCarga(string bitacoraCargaId)
        {
            Int32 usuarioCambioId = 1;
            BitacoraCargasBusiness bitacoraCargasBusiness = new BitacoraCargasBusiness();
            bitacoraCargasBusiness.Eliminar(Convert.ToInt32(bitacoraCargaId), usuarioCambioId);
        } // protected void BorrarComprobranteSinClasificar(string bitacoraCargaId)


        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            GuardarEvidencia();
            CargarEvidenciaSinClasificar();

        } // protected void btnSave_OnClick(object sender, EventArgs e)
    }
}