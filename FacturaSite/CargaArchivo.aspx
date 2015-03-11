<%@ Page Title="" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="CargaArchivo.aspx.cs" Inherits="FacturaSite.CargaArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="AdsertiCreditToolkitScriptManager" CombineScripts="True" ScriptMode="Release" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            <ControlBundles>
                <ajaxToolkit:ControlBundle Name="AjaxFileUploadBundle" />
            </ControlBundles>
        </ajaxToolkit:ToolkitScriptManager>
        <%--UPDATE PANEL--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <ajaxToolkit:AjaxFileUpload
                    runat="server"
                    ID="CargaArchivoAjaxFileUpload"
                    AllowedFileTypes="xml,pdf"
                    ThrobberID="MyThrobber"
                    OnUploadComplete="CargaArchivoAjaxFileUpload_OnUploadComplete" />
                <asp:Image
                    ID="MyThrobber"
                    ImageUrl="images/ajaxSpinner.gif"
                    Style="display: None"
                    runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
