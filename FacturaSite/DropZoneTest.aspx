<%@ Page Title="" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="DropZoneTest.aspx.cs" Inherits="FacturaSite.DropZoneTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <style type="text/css">
        .verde {
            color: #00B85C;
        }

        .rojo {
            color: #FF1919;
        }

        .dz-max-files-reached {
            background-color: red;
        }

        .btn-drop-zone {
            margin-top: 5px;
        }

        .dz-error-message {
            font-size: .8em !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="form1" runat="server">
        <div class="jumbotron">
            <div class="dropzone" id="dropzonediv">
                <div class="fallback">
                    <input name="file" type="file" multiple />
                    <input type="submit" value="Upload" />
                </div>
            </div>
        </div>
        <div id="divResults">
            <ul id="uploadResults">
            </ul>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script type="text/javascript">
        //File Upload response from the server
        Dropzone.options.dropzonediv = {
            url: "Handler/FileHandler.ashx",
            maxFiles: 6,
            dictDefaultMessage: "Arrastre aquí los archivos a cargar",
            dictFallbackMessage: "Su navegador no soporta la propiedad 'Arrastrar archivos' para cargar",
            accept: function (file, done) {
                var re = /(?:\.([^.]+))?$/;
                var ext = re.exec(file.name)[1];
                ext = ext.toUpperCase();

                if (ext == "PDF" || ext == "XML") {
                    done();
                } else {
                    done("Solo son permitidos los archivos PDF y XML");
                }
            },
            init: function () {
                this.on("maxfilesexceeded", function (data) {
                    var res = eval('(' + data.xhr.responseText + ')');
                });
                this.on("addedfile", function (file) {

                    // Create the remove button
                    var removeButton = Dropzone.createElement("<button type='button' class='btn btn-default btn-sm btn-drop-zone'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span> Eliminar Archivos</button>");

                    // Capture the Dropzone instance as closure.
                    var _this = this;

                    // Listen to the click event
                    removeButton.addEventListener("click", function (e) {
                        // Make sure the button click doesn't submit the form:
                        e.preventDefault();
                        e.stopPropagation();
                        // Remove the file preview.
                        _this.removeFile(file);
                        // If you want to the delete the file on the server as well,
                        // you can do the AJAX request here.
                    });

                    // Add the button to the file preview element.
                    file.previewElement.appendChild(removeButton);
                });
            },
            success: function (result) {
                // $("#uploadResults").empty();
                var resultados = JSON.parse(result.xhr.response);

                $(resultados).each(function (i) {
                    var fecha = new Date(resultados[i].Fecha);

                    var icono = (resultados[i].Correcto) ? 'glyphicon glyphicon-ok verde' : 'glyphicon glyphicon-remove rojo';
                    $("#uploadResults").append($("<li class='" + icono + "' aria-hidden='false'/>").text(" " + "[" + formatDate(fecha) + "] " + resultados[i].NombreArchivo + ' ' + resultados[i].Mensaje));
                });

                //Recargar Grid Facturas
                //CargarComprobantes(1);
            },
        };


        function formatDate(date) {
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var seconds = date.getSeconds();

            var ampm = hours >= 12 ? 'PM' : 'AM';
            hours = hours % 12;
            hours = hours ? hours : 12; // the hour '0' should be '12'


            hours = hours < 10 ? '0' + hours : hours;
            minutes = minutes < 10 ? '0' + minutes : minutes;
            seconds = seconds < 10 ? '0' + seconds : seconds;
            var strTime = hours + ':' + minutes + ':' + seconds + ' ' + ampm;

            //return date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getFullYear() + "  " + strTime;
            return zeroFill(date.getDate(), 2) + "/" + zeroFill(date.getMonth() + 1, 2) + "/" + date.getFullYear() + "  " + strTime;
        }

        function zeroFill(number, width) {
            width -= number.toString().length;
            if (width > 0) {
                return new Array(width + (/\./.test(number) ? 2 : 1)).join('0') + number;
            }
            return number + ""; // always return a string
        }

    </script>
</asp:Content>
