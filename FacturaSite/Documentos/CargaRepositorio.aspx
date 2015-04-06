<%@ Page Title="Repositorio" Language="C#" MasterPageFile="~/FacturaSite.Master" AutoEventWireup="true" CodeBehind="CargaRepositorio.aspx.cs" Inherits="FacturaSite.Documentos.CargaRepositorio" %>

<asp:Content ID="EstilosContent" ContentPlaceHolderID="StyleSection" runat="server">
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

        .dropzone .dz-preview .dz-error-message {
            top: -25px;
        }
        
        .dropzone .dz-preview .dz-error-message:after {
            top: auto;
            bottom:-6px;
            border-bottom: 0;
            border-top: 6px solid #a92222;
        }
    </style>
</asp:Content>
<asp:Content ID="PrincipalContent" ContentPlaceHolderID="ContentSection" runat="server">
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
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptSection" runat="server">
    <script type="text/javascript">
        //File Upload response from the server
        Dropzone.options.dropzonediv = {
            url: "/Handler/FileHandler.ashx",
            maxFiles: 6,
            dictMaxFilesExceeded: "Se ha alcanzado el numero máximo de archivos permitidos",
            dictDefaultMessage: "Arrastre aquí los archivos a cargar",
            dictFallbackMessage: "Su navegador no soporta la propiedad 'Arrastrar archivos' para cargar",
            accept: function(file, done) {
                var re = /(?:\.([^.]+))?$/;
                var ext = re.exec(file.name)[1];
                ext = ext.toUpperCase();

                if (ext == "PDF" || ext == "XML") {
                    done();
                } else {
                    done("Solo son permitidos los archivos PDF y XML");
                }
            },
            init: function() {
                //this.on("maxfilesexceeded", function(data) {
                //    var res = eval('(' + data.xhr.responseText + ')');
                //});
                this.on("addedfile", function(file) {

                    // Creacion del boton Eliminar
                    var removeButton = Dropzone.createElement("<button type='button' class='btn btn-default btn-sm btn-drop-zone'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span> Eliminar Archivo</button>");


                    //Captura la Instancia DropZone como Closure
                    var _this = this;

                    //Bind al evento Click
                    removeButton.addEventListener("click", function(e) {
                        //Evitar que el boton haga submit
                        e.preventDefault();
                        e.stopPropagation();
                        // Remove the file preview.
                        //Quitar el preeeliminar del archivo
                        _this.removeFile(file);

                        //Si fuera requerido eliminar el archivo del servidor, tendria que hacerse aqui usando una petición AJAX
                    });

                    // Add the button to the file preview element.
                    file.previewElement.appendChild(removeButton);
                });
            },
            success: function(file, result) {
                var existe = ('xhr' in file) ? (('response' in file.xhr) ? true : false) : false;
                if (existe) {
                    var resultados = JSON.parse(file.xhr.response);
                    AgregarItemBitacoraError(resultados);

                    //Marcar como correcto
                    return file.previewElement.classList.add("dz-success");
                } else {
                    return result;
                }
            },
            error: function(file, result) {
                var existe = ('xhr' in file) ? (('response' in file.xhr) ? true : false) : false;
                var message;
                if (existe) {
                    var resultados = JSON.parse(file.xhr.response);
                    AgregarItemBitacoraError(resultados);
                    message = resultados.Mensaje; // Mensaje de Error

                } else {
                    message = result; // Mensaje de Error
                }

                //Marcar como archivo con error
                var node, _i, _len, _ref, _results;
                file.previewElement.classList.add("dz-error");
                _ref = file.previewElement.querySelectorAll("[data-dz-errormessage]");
                _results = [];
                for (_i = 0, _len = _ref.length; _i < _len; _i++) {
                    node = _ref[_i];
                    _results.push(node.textContent = message);
                }
                return _results;
            }
        };

        function AgregarItemBitacoraError(item) {
            var fecha = new Date(item.Fecha);
            var icono = '<i class=\'' + ((item.Correcto) ? 'glyphicon glyphicon-ok verde' : 'glyphicon glyphicon-remove rojo') + '\'></i>';
            var mensaje = ' ' + '[' + formatDate(fecha) + '] ' + '<b>' + item.NombreArchivo + '</b> ' + item.Mensaje;
            $("#uploadResults").append("<li>" + icono + mensaje + '</li>');
        }


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
