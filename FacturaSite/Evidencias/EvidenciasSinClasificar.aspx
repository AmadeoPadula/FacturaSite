<%@ Page Title="" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="EvidenciasSinClasificar.aspx.cs" Inherits="FacturaSite.Evidencias.EvidenciasSinClasificar" %>

<asp:Content ID="StyleContent" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="EvidenciasSinClasificarScriptManager" runat="server"></asp:ScriptManager>
        <div>
            <div>
                <div class="wrapperDiv">
                    <div class="headerDiv">
                        <h3 class="title">Evidencias Sin Clasificar</h3>
                    </div>
                </div>
                <div class="contentDiv">
                    <div class="gridWrapper">
                        <div>
                            <asp:Button ID="btnAdd" runat="server" Text="Agregar" class="btn btn-primary" />&nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" class="btn btn-primary" OnClientClick="return confirm('¿Realmente desea eliminar la entrada?');" />&nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Buscar por Nombre : "></asp:Label>
                            <asp:TextBox ID="txtSearch" runat="server" class="form-control" Style="margin-top: 5px;"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Ir!" class="btn btn-primary" />
                        </div>
                        <%--INICIO GRIDVIEW--%>
                        <div class="gridContainer">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="EvidenciasSinClasificarGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron Evidencias sin Clasificar."
                                        class="table table-striped table-bordered table-condensed" AllowPaging="True" OnPageIndexChanged="EvidenciasSinClasificarGridView_OnPageIndexChanged"
                                        OnPageIndexChanging="EvidenciasSinClasificarGridView_OnPageIndexChanging" OnRowCommand="EvidenciasSinClasificarGridView_OnRowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre Archivos" SortExpression="NombreArchivos" />
                                            <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
                                            <asp:TemplateField HeaderText="Clasificar | Eliminar">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ClasificarLinkButton" runat="server" CommandName="select" CommandArgument='<%# Eval("BitacoraCargaId") %>'>Clasificar</asp:LinkButton>&nbsp;&nbsp;|&nbsp;
                                                    <asp:CheckBox ID="chkEliminarCheckBox" runat="server" AutoPostBack="True" />
                                                    <asp:HiddenField ID="BitacoraCargaId" runat="server" Value='<%# Eval("BitacoraCargaId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <%--FIN GRIDVIEW--%>
                    </div>
                </div>
                <%--INICIO MODAL--%>

                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="myModalLabel">Employee Details</h4>
                            </div>
                            <div class="modal-body">
                                <div style="float: left; display: inline; padding-right: 80px;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <%--BITACORA CARGA ID--%>
                                                

                                                <%--EMPRESA--%>
                                                <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">Empresa:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="EmpresaDropDownList" runat="server" class="form-control" Style="max-width: 50px;" Enabled="False"></asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <%--BANCO--%>
                                                <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">Banco: </label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="BancoDropDownList" runat="server" class="form-control"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <%--TIPO TRANSACCION--%>
                                                <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">Transacción: </label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="TipoTransaccionDropDownList" runat="server" class="form-control"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <%--NÚMERO TRANSFERENCIA--%>
                                                <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">Número Transferencia: </label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="NumeroTransferenciaTextBox" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--FECHA PAGO--%>
                                                 <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">Fecha Pago: </label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="FechaPagoTextBox" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <%--MONTO PAGO--%>
                                                <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">Monto Pago: </label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="MontoPagoTextBox" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <%--NÚMERO FACTURA PAGADA--%>
                                                <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">No. Factura Pagada: </label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="NoFacturaPagadaTextBox" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <%--CLAVE EVIDENCIA--%>
                                                <tr>
                                                    <td style="text-align: right;">
                                                        <label class="col-sm-2 control-label">Clave Evidencia: </label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="ClaveEvidenciaTextBox" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="EvidenciasSinClasificarGridView" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal" id="btnClose">Cerrar</button>
                                <asp:Button ID="btnSave" runat="server" Text="Save change" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>

                <%--FIN MODAL--%>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptSection" runat="server">
    <script type="text/javascript">
        
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $('#' + '<%= FechaPagoTextBox.ClientID%>').datepicker();
            }
        }


        $(document).ready(function () {
            
        });


        function LimpiarCampos() {
            $("[id$=EmpresaDropDownList]").val('');
            $("[id$=BancoDropDownList]").val('');
            $("[id$=TipoTransaccionDropDownList]").val('');
            $("[id$=NumeroTransferenciaTextBox]").val('');
            $('#FechaPagoTextBox').datepicker("update", new Date());
            $("[id$=MontoPagoTextBox]").val('');
            $("[id$=NoFacturaPagadaTextBox]").val('');
        };

        function CloseModal(msg) {
            $('#myModal').modal('hide');
            if (msg.length > 0) {
                alert(msg);
            }
        }

        function ShowModal() {
            $('#myModal').modal('show');
        }


    </script>
</asp:Content>
