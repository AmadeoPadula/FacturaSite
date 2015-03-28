<%@ Page Title="" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="EvidenciaContable.aspx.cs" Inherits="FacturaSite.Resumen.EvidenciaContable" %>

<asp:Content ID="StyleContent" ContentPlaceHolderID="StyleSection" runat="server">
    <style>
        .ui-widget-content .ui-icon {
            background-image: url("../Content/themes/base/images/ui-icons_222222_256x240.png") /*{iconsContent}*/;
        }

        .error {
            border: 1px solid #b94a48 !important;
            background-color: #fee !important;
        }
    </style>
</asp:Content>
<asp:Content ID="PrincipalContent" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="form1" runat="server" class="form-inline">
        <h3>Módulo de Evidencia Contable</h3>
        <div class="form-group">
            <label class="control-label">Fecha Inicial:</label>
            <asp:TextBox runat="server" ID="FechaInicioTextBox" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="control-label">Fecha Final:</label>
            <asp:TextBox runat="server" ID="FechaFinTextBox" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button runat="server" ID="BuscarButton" CssClass="form-control" Text="Buscar" OnClick="BuscarButton_OnClick" />
            <%-- <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-default btn-group-sm" runat="server">
                <span class="glyphicon glyphicon-search"></span> &nbsp;Buscar
            </asp:LinkButton>--%>
        </div>

        <div class="container">
            <asp:GridView ID="EvidenciaContableGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontraron Evidencias Contables."
                class="table table-striped table-bordered" AllowPaging="True" >
                <Columns>
                    <asp:BoundField DataField="TipoTransaccion" HeaderText="Tipo de Transacción" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptSection" runat="server">
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../Scripts/datepickerCfg.min.js"></script>
    <script type="text/javascript">
        $(function() {
            $.datepicker.setDefaults($.datepicker.regional['es']);

            //Setea Fecha de Inicio Minima
            $('#' + '<%= FechaInicioTextBox.ClientID%>').datepicker({
                onSelect: function(selected) {
                    $('#' + '<%= FechaFinTextBox.ClientID%>').datepicker("option", "minDate", selected);
                }
            });
            
            //Setea Fecha Fin Maxima
            $('#' + '<%= FechaFinTextBox.ClientID%>').datepicker({
                onSelect: function(selected) {
                    $('#' + '<%= FechaInicioTextBox.ClientID%>').datepicker("option", "maxDate", selected);
                }
            });


            $('#' + '<%= form1.ClientID%>').validate({
                rules: {
                    <%=FechaInicioTextBox.UniqueID %>: {
                        required: true
                    },
                    <%=FechaFinTextBox.UniqueID %>: {
                        required: true
                    }
                },
                messages: {
                    <%=FechaInicioTextBox.UniqueID %>:
                    {
                        required: "La fecha de inicio es obligatoria"
                    },
                    <%=FechaFinTextBox.UniqueID %>:
                    {
                        required: "La fecha final es obligatoria"
                    }
                },
                tooltip_options: {
                    thefield: { placement: 'left' }
                },
                showErrors: function(errorMap, errorList) {
                    //Limpiar cualquier toooltip para elementos validos
                    $.each(this.validElements(), function(index, element) {
                        var $element = $(element);
                        $element.data("title", "") //Limpiar el titulo
                            .removeClass("error")
                            .tooltip("destroy");
                    });
                    // Crear nuevos tooltips para elemementos invalidos
                    $.each(errorList, function(index, error) {
                        var $element = $(error.element);
                        $element.tooltip("destroy") //Eliminar tooltips preexistentes, asi podemos rellenar el contenido con un nuevo tooltip
                            .data("title", error.message)
                            .addClass("error")
                            .tooltip(); // Crear un nuevo tooltip en base al mensaje de error, entonces  seteamos el titulo 
                    });
                }
            });
        });
    </script>
</asp:Content>
