<%@ Page Title="Facturas Pagadas" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="FacturasPagadas.aspx.cs" Inherits="FacturaSite.Facturas.FacturasPagadas" %>

<asp:Content ID="EstilosContent" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="PrincipalContent" ContentPlaceHolderID="ContentSection" runat="server">
    <form runat="server" id="PrincipalForm">
        <div class="jumbotron">
            <h2>Facturas Pagadas</h2>
            <asp:ScriptManager ID="FacturasPagadasScriptManager" runat="server"></asp:ScriptManager>
            <div class="container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="FacturasPagadasGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron Facturas Pagadas."
                            class="table table-striped table-bordered" AllowPaging="True">
                            <Columns>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Identificador" HeaderText="Folio y Serie" />
                                <asp:BoundField DataField="Identificador" HeaderText="Folio y Serie" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>

</asp:Content>
<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
