<%@ Page Title="" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EvidenciasSinClasificar.aspx.cs" Inherits="FacturaSite.Evidencias.EvidenciasSinClasificar" %>

<asp:Content ID="StyleContent" ContentPlaceHolderID="StyleSection" runat="server">
    <style>
        .headerDiv {
            background: #3abb73;
            margin: 0;
            /*height: 80px;*/
            text-align: left;
        }

        .title {
            color: #F7FAFA;
            padding: 20px 0 0 10px;
        }

        .wrapperDiv {
            /*max-width: 860px;*/
            border: 1px solid #D9D4D6;
            margin: auto;
            /* margin-top: 40px;*/
            background-color: #E1E3E3;
            padding: 0 8px 0 8px;
            border-radius: 6px;
        }

        .contentDiv {
            height: 500px;
        }

        .gridWrapper {
            height: 490px;
            background-color: White;
        }

        .gridContainer {
            overflow: auto;
        }
    </style>
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

                    <div class="contentDiv">
                        <div class="gridWrapper">
                            <div>
                                <asp:Button ID="btnAdd" runat="server" Text="Agregar" class="btn btn-primary" />&nbsp;
                                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" class="btn btn-primary" OnClientClick="return confirm('¿Realmente desea eliminar la entrada?');" />&nbsp;
                                <asp:Label ID="BuscarLabel" runat="server" Text="Buscar por Nombre : "></asp:Label>
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
                </div>
                <%--INICIO MODAL--%>

                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="myModalLabel">Clasificar Evidencia</h4>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <%--EMPRESA--%>
                                            <div class="form-group">
                                                <label>Empresa:</label>
                                                <asp:DropDownList ID="EmpresaDropDownList" runat="server" class="form-control"></asp:DropDownList>
                                            </div>
                                            <%--BANCO--%>
                                            <div class="form-group">
                                                <label>Banco: </label>
                                                <asp:DropDownList ID="BancoDropDownList" runat="server" class="form-control"></asp:DropDownList>
                                            </div>
                                            <%--TIPO TRANSACCION--%>
                                            <div class="form-group">
                                                <label>Tipo Transacción: </label>
                                                <asp:DropDownList ID="TipoTransaccionDropDownList" runat="server" class="form-control"></asp:DropDownList>
                                            </div>
                                            <%--NUMERO TRANSFERENCIA--%>
                                            <div class="form-group">
                                                <label>Número Transferencia: </label>
                                                <asp:TextBox ID="NumeroTransferenciaTextBox" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <%--FECHA PAGO--%>
                                            <div class="form-group">
                                                <label>Fecha Pago: </label>
                                                <asp:TextBox ID="FechaPagoTextBox" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <%--MONTO PAGO--%>
                                            <div class="form-group">
                                                <label>Monto Pago: </label>
                                                <asp:TextBox ID="MontoPagoTextBox" runat="server" SkinID="NumerosMoneda"></asp:TextBox>
                                            </div>
                                            <%--NÚMERO FACTURA PAGADA--%>

                                            <div>
                                                <asp:UpdatePanel runat="server" ID="ComprobantesSinEvidenciasUpdatePanel">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="ComprobanteSeleccionadoTextBox" ReadOnly="True" />
                                                        <asp:Panel runat="server" ID="ComprobantesDropDownListPanel" Style="max-height: 150px; overflow: scroll; display: none; visibility: hidden;">
                                                            <asp:GridView runat="server" ID="ComprobantesSinEvidenciaGridView" AutoGenerateColumns="False"
                                                                OnRowDataBound="ComprobantesSinEvidenciaGridView_OnRowDataBound"
                                                                OnSelectedIndexChanged="ComprobantesSinEvidenciaGridView_OnSelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ComprobanteId" HeaderText="ComprobanteId" />
                                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                                    <asp:BoundField DataField="Total" DataFormatString="{0:c}" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                        <ajaxToolkit:DropDownExtender ID="FacturaSinEvidenciasDropDownExtender"
                                                            runat="server"
                                                            DropDownControlID="ComprobantesDropDownListPanel"
                                                            TargetControlID="ComprobanteSeleccionadoTextBox">
                                                        </ajaxToolkit:DropDownExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>


                                            <%--CLAVE EVIDENCIA--%>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="EvidenciasSinClasificarGridView" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal" id="btnClose">Cerrar</button>
                                <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-primary" />
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
    <script src="../Scripts/autoNumeric/autoNumeric-1.9.25.min.js"></script>
   <%-- <script src="../Scripts/autoNumericCfg.min.js"></script>--%>
    <script type="text/javascript">
        //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
        //function InIEvent() {
        //    ConfiguraAutoNumeric();
        //}

        //$(document).ready(InIEvent);

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $('#' + '<%= FechaPagoTextBox.ClientID%>').datepicker();
            }
        }

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
