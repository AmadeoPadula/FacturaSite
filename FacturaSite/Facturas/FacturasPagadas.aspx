<%@ Page Title="Facturas Pagadas" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="FacturasPagadas.aspx.cs" Inherits="FacturaSite.Facturas.FacturasPagadas" %>

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
        <h3>Facturas Pagadas</h3>
        <asp:ScriptManager ID="FacturasPagadasScriptManager" runat="server"></asp:ScriptManager>
        <div class="container">
            <asp:UpdatePanel ID="FacturasPagadasUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="FacturasPagadasGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron Facturas Pagadas."
                        class="table table-striped table-bordered" AllowPaging="True" OnRowCommand="FacturasPagadasGridView_OnRowCommand" OnRowCreated="FacturasPagadasGridView_OnRowCreated" OnRowDataBound="FacturasPagadasGridView_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Factura" />
                            <asp:BoundField DataField="Evidencia.FechaPago" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Pago" />
                            <asp:BoundField DataField="Identificador" HeaderText="Folio y Serie" />
                            <asp:BoundField DataField="Emisores.Personas.Rfc" HeaderText="RFC" />
                            <asp:BoundField DataField="Emisores.Personas.Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Receptores.Personas.Rfc" HeaderText="RFC" />
                            <asp:BoundField DataField="Receptores.Personas.Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Evidencia.Banco.Banco" HeaderText="Banco" />
                            <asp:BoundField DataField="Evidencia.TipoTransaccion.TipoTransaccion" HeaderText="Tipo Transacción" />
                            <asp:BoundField DataField="Total" DataFormatString="{0:c}" HeaderText="Total Factura" />
                            <asp:BoundField DataField="Evidencia.MontoPago" DataFormatString="{0:c}" HeaderText="Total Evidencia" />
                            <asp:TemplateField HeaderText="Diferencia">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="DiferenciaLabel" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="DownloadEvidenciaLinkButton" CommandArgument='<%# Eval("Evidencia.BitacoraCarga.BitacoraCargaId") %>' CommandName="dwlEvidencia">
                                            <%--<i aria-hidden="true" class="glyphicon glyphicon-remove"></i>--%>
                                            <img src="http://cdn.icons8.com/windows8/PNG/26/Very_Basic/document-26.png" title="Evidencia" width="26">
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
            
            
            <table>
                <tr>
                    <td class="azul" style="width: 20px;"></td>
                    <td>&nbsp; FACTURA</td>
                </tr>
                <tr>
                    <td class="verde"></td>
                    <td>&nbsp; EVIDENCIA</td>
                </tr>
            </table>

        </div>
    </form>

</asp:Content>
<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
