<%@ Page Title="" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EvidenciasSinClasificar.aspx.cs" Inherits="FacturaSite.Evidencias.EvidenciasSinClasificar" %>

<asp:Content ID="StyleContent" ContentPlaceHolderID="StyleSection" runat="server">
    <link href="../Content/themes/bootstrap/easyui.css" rel="stylesheet" />
    <style>
        .ui-widget-content .ui-icon {
            background-image: url("../Content/themes/base/images/ui-icons_222222_256x240.png") /*{iconsContent}*/;
        }

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

        .error {
            border: 1px solid #b94a48 !important;
            background-color: #fee !important;
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
                                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" class="btn btn-primary" OnClientClick="return confirm('¿Realmente desea eliminar la entrada?');" OnClick="btnDelete_OnClick" />&nbsp;
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
                                                        <asp:HiddenField ID="BitacoraCargaIdHiddenField" runat="server" Value='<%# Eval("BitacoraCargaId") %>' />
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

                                            <%--NÚMERO FACTURA PAGADA--%>
                                            <div class="form-group">
                                                <label>Factura Pagada: </label>
                                                <br />
                                                <asp:DropDownList ID="FacturaPagadaDropDownList" runat="server" class="form-control" Height="34px" Width="190px" />
                                            </div>

                                            <%--MONTO PAGO--%>
                                            <div class="form-group">
                                                <label>Monto Pago: </label>
                                                <asp:TextBox ID="MontoPagoTextBox" runat="server" SkinID="NumerosMoneda"></asp:TextBox>
                                            </div>

                                            <%--FACTURA PAGADA--%>
                                            <asp:HiddenField runat="server" ID="BitacoraCargaIdHiddenField" />
                                            <asp:HiddenField runat="server" ID="FacturaSeleccionadaHiddenField" />

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
                                <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnSave_OnClick" />
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
    <script src="../Scripts/jquery.easyui.min-1.4.1.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/autoNumeric/autoNumeric-1.9.25.min.js"></script>
    <script src="../Scripts/autoNumericCfg.min.js"></script>
    <script src="../Scripts/datepickerCfg.min.js"></script>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
        function InIEvent() {
            ConfiguraAutoNumeric();
            ActualizaFacturasPendientes();
            $.datepicker.setDefaults($.datepicker.regional['es']);

            //Cancelar la validacion por default del formulario
            $("#form1").validate({
                onsubmit: false
            });
        }

        $(document).ready(InIEvent);

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

        //NUMERO DE FACTURA PAGADA
        var ActualizaFacturasPendientes =
        (function () {
            var jsonData = [];
            $.ajax({
                type: "POST",
                async: false,
                mode: 'remote',
                contentType: "application/json; charset=utf-8",
                url: "EvidenciasSinClasificar.aspx/AutoArrayList",
                dataType: "json",
                success: function (data) {
                    jsonData = data.d;
                },
                error: function (result) {
                    alert("Error");
                }

            });

            if (jsonData != null) {
                $('[id$=FacturaPagadaDropDownList]').combogrid({
                    panelWidth: 500,
                    //value: '006',
                    idField: 'ComprobanteId',
                    textField: 'Identificador',
                    editable: false,
                    //url: '/combogrid/GetStudentsInfo',
                    //source:jsonData,
                    columns: [
                        [
                            {
                                field: 'Fecha.Formateada',
                                title: 'Fecha',
                                width: 120,
                                formatter: function (value, row) {
                                    var date = new Date(parseInt(row.Fecha.substr(6)));

                                    var dformat = [
                                        date.getDate().padLeft(),
                                        (date.getMonth() + 1).padLeft(),
                                        date.getFullYear()
                                    ].join('/') + ' ' +
                                    [
                                        date.getHours().padLeft(),
                                        date.getMinutes().padLeft(),
                                        date.getSeconds().padLeft()
                                    ].join(':');
                                    return dformat;
                                }
                            },
                            { field: 'Serie', title: 'Serie', width: 70 },
                            { field: 'Folio', title: 'Folio', width: 70 },
                            { field: 'Emisor.Rfc', title: 'Emisor RFC', width: 100, formatter: function (value, row) { return row.Emisores.Personas.Rfc; } },
                            { field: 'Emisor.Nombre', title: 'Emisor', width: 300, formatter: function (value, row) { return row.Emisores.Personas.Nombre; } },
                            { field: 'Receptor.Rfc', title: 'Receptor RFC', width: 100, formatter: function (value, row) { return row.Receptores.Personas.Rfc; } },
                            { field: 'Receptor.Nombre', title: 'Receptor', width: 300, formatter: function (value, row) { return row.Receptores.Personas.Nombre; } },
                            { field: 'Total.Formateado', title: 'Total', width: 90, formatter: function (value, row) { return '$' + row.Total.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"); }, sortable: true }
                        ]
                    ],
                    onSelect: function (index, row) {
                        var comprobante = row.ComprobanteId;
                        $('#' + '<%= FacturaSeleccionadaHiddenField.ClientID%>').val(comprobante);

                        //Si el input correspondiente al monto del pago esta vacio, asigna el Total de la Factura Seleccionada
                        <%--var monto = $('#' + '<%= MontoPagoTextBox.ClientID%>').val();
                    if (!monto) {--%>
                        $('#' + '<%= MontoPagoTextBox.ClientID%>').autoNumeric('set', row.Total);
                        //}
                    }
                });

                // get the datagrid object
                var g = $('[id$=FacturaPagadaDropDownList]').combogrid('grid');
                //assign the data to datagrid
                g.datagrid('loadData', jsonData);
            }
        });
        Number.prototype.padLeft = function (base, chr) {
            var len = (String(base || 10).length - String(this).length) + 1;
            return len > 0 ? new Array(len).join(chr || '0') + this : this;
        }

        // Validación cuadro de dialogo
        //$('#btnSave').click(function() {
            
        //});

        $('#' + '<%= form1.ClientID%>').validate({
            ignore:'',
            rules: {
                <%=EmpresaDropDownList.UniqueID%>: {
                    required: true
                },
                <%=BancoDropDownList.UniqueID%>: {
                    required: true
                },
                <%=TipoTransaccionDropDownList.UniqueID%>: {
                    required: true
                },
                <%=NumeroTransferenciaTextBox.UniqueID%>: {
                    required: true
                },
                <%=FechaPagoTextBox.UniqueID %>: {
                    required: true
                },
                <%=FacturaPagadaDropDownList.UniqueID %>: {
                    required: true
                },
                <%=MontoPagoTextBox.UniqueID %>: {
                    required: true
                }
            },
            errorPlacement: function(error, element) {
                if (element.hasClass('combo-value')) 
                {
                    element.closest("span.combo").after(error);
                } 
                else {
                    element.after(error);
                }
            },       
            messages: {
                <%=EmpresaDropDownList.UniqueID%>: {
                    required: "La Empresa es obligatoria"
                },
                <%=BancoDropDownList.UniqueID%>: {
                    required: "El Banco es obligatorio"
                },
                <%=TipoTransaccionDropDownList.UniqueID%>: {
                    required: "El Tipo de Transacción es obligatorio"
                },
                <%=NumeroTransferenciaTextBox.UniqueID%>: {
                    required: "El Número de Transaferencia obligatorio"
                },
                <%=FechaPagoTextBox.UniqueID %>: {
                    required: "La Fecha de Pago es obligatoria"
                },
                <%=FacturaPagadaDropDownList.UniqueID %>: {
                    required: "El Número de Factura Pagada es obligatoria"
                },
                <%=MontoPagoTextBox.UniqueID %>: {
                    required: "El Monto Pagado es obligatorio"
                }
            }
        });

        $("input[id$=btnSave]").click(function(evt) {
            var isValid = $('#' + '<%= form1.ClientID%>').valid();

            if (!isValid)
                evt.preventDefault();
        });


    </script>
</asp:Content>
