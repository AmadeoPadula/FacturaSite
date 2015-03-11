using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }


        protected void CargarEvidenciaSinClasificar()
        {
            BitacoraCargasBusiness bitacoraCargasBusiness = new BitacoraCargasBusiness();
            EvidenciasSinClasificarGridView.DataSource = bitacoraCargasBusiness.CargasSinClasificar();
            EvidenciasSinClasificarGridView.DataBind();
        }

        protected void EvidenciasSinClasificarGridView_OnPageIndexChanged(object sender, EventArgs e)
        {
            CargarEvidenciaSinClasificar();
        }

        protected void EvidenciasSinClasificarGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EvidenciasSinClasificarGridView.PageIndex = e.NewPageIndex;
            EvidenciasSinClasificarGridView.DataBind();
        }

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
        }

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
        }

        protected void TraerInfoBitacora(Int32 bitacoraId)
        {
            BitacoraCargasBusiness bitacoraBusiness = new BitacoraCargasBusiness();
            BitacoraCargas bitacoraCarga = bitacoraBusiness.Cargar(bitacoraId);
            LimpiarVentanaModal();



        }

        protected void GuardarEvidencia()
        {
            
        }


        protected void LimpiarVentanaModal()
        {
            EmpresaDropDownList.Text = string.Empty;
            BancoDropDownList.Text = string.Empty;
            TipoTransaccionDropDownList.Text = string.Empty;
            NumeroTransferenciaTextBox.Text = string.Empty;
            FechaPagoTextBox.Text = string.Empty;
            MontoPagoTextBox.Text = string.Empty;
            NoFacturaPagadaTextBox.Text = string.Empty;
        }

    }
}