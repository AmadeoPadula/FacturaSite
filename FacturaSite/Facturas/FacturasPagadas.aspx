<%@ Page Title="Facturas Pagadas" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="FacturasPagadas.aspx.cs" Inherits="FacturaSite.Facturas.FacturasPagadas" %>

<asp:Content ID="EstilosContent" ContentPlaceHolderID="StyleSection" runat="server">
    <style>
        .container {
            font-size: 0.9em;
        }
        .centrado {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="PrincipalContent" ContentPlaceHolderID="ContentSection" runat="server">
    <form runat="server" id="PrincipalForm">
        <div class="jumbotron">
            <h2>Facturas Pagadas</h2>
            <asp:ScriptManager ID="FacturasPagadasScriptManager" runat="server"></asp:ScriptManager>
            <div class="container">
                <asp:UpdatePanel ID="FacturasPagadasUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="FacturasPagadasGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron Facturas Pagadas."
                            class="table table-striped table-bordered" AllowPaging="True" OnRowCommand="FacturasPagadasGridView_OnRowCommand" OnRowCreated="FacturasPagadasGridView_OnRowCreated">
                            <HeaderStyle CssClass="Centrado"></HeaderStyle>
                            <Columns>
                                <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Factura" />
                                <asp:BoundField DataField="Evidencia.FechaPago" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Pago" />
                                <asp:BoundField DataField="Identificador" HeaderText="Folio y Serie" />
                                <asp:BoundField DataField="Emisores.Personas.Rfc" HeaderText="RFC" />
                                <asp:BoundField DataField="Emisores.Personas.Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Receptores.Personas.Rfc" HeaderText="RFC" />
                                <asp:BoundField DataField="Receptores.Personas.Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Total" DataFormatString="{0:c}" HeaderText="Total" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="DownloadXMLLinkButton" CommandArgument='<%# Eval("BitacoraCargasXml.BitacoraCargaId") %>' CommandName="dwlXml">
                                            <i aria-hidden="true" class="glyphicon glyphicon-remove"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="DownloadPDFLinkButton" CommandArgument='<%# Eval("BitacoraCargasPdf.BitacoraCargaId") %>' CommandName="dwlPdf">
                                            <i aria-hidden="true" class="glyphicon glyphicon-remove"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="DownloadEvidenciaLinkButton" CommandArgument='<%# Eval("Evidencia.BitacoraCarga.BitacoraCargaId") %>' CommandName="dwlEvidencia">
                                            <i aria-hidden="true" class="glyphicon glyphicon-remove"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="FacturasPagadasGridView" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <asp:Label runat="server" ID="msjLabel"></asp:Label>
        </div>
    </form>

</asp:Content>
<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
