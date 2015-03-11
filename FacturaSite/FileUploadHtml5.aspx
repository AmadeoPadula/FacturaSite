<%@ Page Title="" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="FileUploadHtml5.aspx.cs" Inherits="FacturaSite.FileUploadHtml5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <style>
        .verde:first-letter {
            color: green;
        }

        .rojo:first-letter {
            color: red;
        }

        #uploadControls li.glyphicon {
            display: block;
        }

        #box {
            margin: 10px;
            width: 300px;
            height: 100px;
            text-align: center;
            vertical-align: middle;
            border: 2px dashed #808080;
            background-color: #FAFAFA;
            padding: 15px;
            color: #808080;
            font-family: Arial;
            font-size: 1em;
            margin-top: 35px;
        }

        /*Paginador*/
        .Pager span {
            text-align: center;
            color: #999;
            display: inline-block;
            width: 20px;
            background-color: #A1DCF2;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #3AC0F2;
        }

        .Pager a {
            text-align: center;
            display: inline-block;
            width: 20px;
            background-color: #3AC0F2;
            color: #fff;
            border: 1px solid #3AC0F2;
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="form1" runat="server">
        <div id="uploadControls">
            <div id="box">Arrastrar archivos aquí.</div>
            <input id="btnUpload" type="button" value="Cargar" class="btn btn-primary btn-sm active" />
            <ul id="uploadResults">
            </ul>
        </div>
        <div id="uploadProgress" class="hidden">
            <img src="/images/ajaxSpinner.gif" alt="" />
        </div>
        <div>
            <asp:GridView ID="FacturasGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered">
                <Columns>
                    <asp:BoundField DataField="EmisoresId" HeaderText="Emisores" />
                    <asp:BoundField DataField="ReceptoresId" HeaderText="Receptores" />
                    <asp:BoundField DataField="TotalImpuestosRetenidos" HeaderText="Total Impuestos Retenidos" />
                    <asp:BoundField DataField="TotalImpuestosTrasladados" HeaderText="Total Impuestos Trasladados" />
                </Columns>
            </asp:GridView>
            <br />
            <div class="Pager"></div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script type="text/javascript" src="Scripts/modernizr-2.8.3.js"></script>
    <script src="Scripts/ASPSnippets_Pager.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var selectedFiles;

        $(document).ready(function () {

            if (!Modernizr.draganddrop) {
                alert("Este navegador no soporta caracteristicas Drag & Drop de HTML5!");
                return;
            }

            CargarComprobantes(1);

            $("#btnUpload").click(OnUpload);

            var box;
            box = document.getElementById("box");
            box.addEventListener("dragenter", OnDragEnter, false);
            box.addEventListener("dragover", OnDragOver, false);
            box.addEventListener("drop", OnDrop, false);
        });

        function OnUpload(evt) {
            ShowUploadProgress();

            var data = new FormData();
            for (var i = 0; i < selectedFiles.length; i++) {
                data.append(selectedFiles[i].name, selectedFiles[i]);
            }
            $.ajax({
                type: "POST",
                url: "Handler/FileHandler.ashx",
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    ShowUploadControls();
                    $("#uploadResults").empty();
                    var resultados = JSON.stringify(result);

                    $(result).each(function (i) {
                        var icono = (result[i].Correcto) ? 'glyphicon glyphicon-ok correcto verde' : 'glyphicon glyphicon-remove incorrecto rojo';
                        $("#uploadResults").append($("<li class='" + icono + "' aria-hidden='false'/>").text(result[i].NombreArchivo + ' ' + result[i].Mensaje));
                    });

                   //Recargar Grid Facturas
                    CargarComprobantes(1);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    ShowUploadControls();
                    alert(xhr.responseText);
                }
            });
        }

        function OnDragEnter(e) {
            e.stopPropagation();
            e.preventDefault();
        }

        function OnDragOver(e) {
            e.stopPropagation();
            e.preventDefault();
        }

        function OnDrop(e) {
            e.stopPropagation();
            e.preventDefault();
            selectedFiles = e.dataTransfer.files;
            $("#box").text(selectedFiles.length + " Archivos(s) seleccionado(s) para cargar!");
        }

        function ShowUploadControls() {
            $("#uploadControls").show();
            $("#uploadProgress").hide();
        }
        function ShowUploadProgress() {
            $("#uploadControls").hide();
            $("#uploadProgress").show();
        }


        //$(".Pager .page").on("click", function () {
        //    CargarComprobantes(parseInt($(this).attr('page')));
        //});


        function CargarComprobantes(pageIndex) {
            $.ajax({
                type: "POST",
                url: "FileUploadHtml5.aspx/CargarComprobantes",
                data: '{pageIndex: ' + pageIndex + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            var responseArray = $.parseJSON(response.d);

            if (responseArray != null) {
                var row = $("[id*=FacturasGridView] tr:last-child").clone(true);
                $("[id*=FacturasGridView] tr").not($("[id*=FacturasGridView] tr:first-child")).remove();

                $.each(responseArray, function(idx, obj) {
                    $("td", row).eq(0).html(obj.Emisor.Persona.Nombre);
                    $("td", row).eq(1).html(obj.Receptor.Persona.Nombre);
                    $("td", row).eq(2).html(obj.TotalImpuestosRetenidos);
                    $("td", row).eq(3).html(obj.TotalImpuestosTrasladados);

                    $("[id*=FacturasGridView]").append(row);
                    row = $("[id*=FacturasGridView] tr:last-child").clone(true);
                });

                //var pager = xml.find("Pager");
                //$(".Pager").ASPSnippets_Pager({
                //    ActiveCssClass: "current",
                //    PagerCssClass: "pager",
                //    PageIndex: parseInt(pager.find("PageIndex").text()),
                //    PageSize: parseInt(pager.find("PageSize").text()),
                //    RecordCount: parseInt(pager.find("RecordCount").text())
                //});
            }
        }
    </script>
</asp:Content>
