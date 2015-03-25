<%@ Page Title="Facturas Pendientes" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="FacturasPendientes.aspx.cs" Inherits="FacturaSite.Facturas.FacturasPendientes" %>

<asp:Content ID="EstilosContent" ContentPlaceHolderID="StyleSection" runat="server">
    <style>
        .HeaderStyle {
            border: solid 1px white;
            /*font-weight: bold;*/
            text-align: center;
        }

        .azul {
            background-color: #DDEBF7;
        }

        .verde {
            background-color: #E2EFDA;
        }

        table {
            font-size: 0.8em;
        }

        th {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="PrincipalContent" ContentPlaceHolderID="ContentSection" runat="server">
    <form runat="server" id="PrincipalForm">
        <h3>Facturas Pendientes</h3>
        <asp:ScriptManager ID="FacturasPendientesScriptManager" runat="server"></asp:ScriptManager>
        <div class="container">
            <asp:UpdatePanel ID="FacturasPendientesUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="FacturasPendientesGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron Facturas Pendientes."
                        class="table table-striped table-bordered" AllowPaging="True" OnRowCommand="FacturasPendientesGridView_OnRowCommand" OnRowCreated="FacturasPendientesGridView_OnRowCreated" OnRowDataBound="FacturasPendientesGridView_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" />
                            <asp:BoundField DataField="Identificador" HeaderText="Folio y Serie" />
                            <asp:BoundField DataField="Emisores.Personas.Rfc" HeaderText="RFC" />
                            <asp:BoundField DataField="Emisores.Personas.Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Receptores.Personas.Rfc" HeaderText="RFC" />
                            <asp:BoundField DataField="Receptores.Personas.Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Total" DataFormatString="{0:c}" HeaderText="Total" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="DownloadXMLLinkButton" CommandArgument='<%# Eval("BitacoraCargasXml.BitacoraCargaId") %>' CommandName="dwlXml">
                                            <%--<i aria-hidden="true" class="glyphicon glyphicon-remove"></i>--%>
                                            <img src="http://cdn.icons8.com/Android_L/PNG/24/Files/XML-24.png" title="XML" width="24">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="DownloadPDFLinkButton" CommandArgument='<%# Eval("BitacoraCargasPdf.BitacoraCargaId") %>' CommandName="dwlPdf">
                                            <%--<i aria-hidden="true" class="glyphicon glyphicon-remove"></i>--%>
                                            <img src="http://cdn.icons8.com/Android_L/PNG/24/Files/PDF-24.png" title="PDF" width="24">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="FacturasPendientesGridView" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>

</asp:Content>
<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
