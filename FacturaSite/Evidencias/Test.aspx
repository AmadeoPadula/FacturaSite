<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="FacturaSite.Evidencias.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Titulo agregado desde casa</title>
    <link href="../Content/themes/bootstrap/easyui.css" rel="stylesheet" />
    <script src="../Scripts/jquery-2.1.3.js"></script>
    <script src="../Scripts/jquery.easyui.min-1.4.1.js"></script>
    <script src="../Scripts/locale/easyui-lang-es.js"></script>
    <script>
        $(function() {
            var jsonData = [];
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "Test.aspx/AutoArrayList",
                dataType: "json",
                success: function(data) {
                    jsonData = data.d;
                },
                error: function(result) {
                    alert("Error");
                }

            });


            if (jsonData != null) {

                $('#drpSelectStudents').combogrid({
                    panelWidth: 450,
                    //value: '006',
                    idField: 'ComprobanteId',
                    textField: 'ComprobanteId',
                    //url: '/combogrid/GetStudentsInfo',
                    //source:jsonData,
                    columns: [
                        [
                            {
                                field: 'Fecha.Formateada',
                                title: 'Fecha',
                                width: 120,
                                formatter: function(value, row) {
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
                            { field: 'Emisor.Rfc', title: 'Emisor RFC', width: 100, formatter: function(value, row) { return row.Emisores.Personas.Rfc; } },
                            { field: 'Emisor.Nombre', title: 'Emisor', width: 300, formatter: function(value, row) { return row.Emisores.Personas.Nombre; } },
                            { field: 'Receptor.Rfc', title: 'Receptor RFC', width: 100, formatter: function(value, row) { return row.Receptores.Personas.Rfc; } },
                            { field: 'Receptor.Nombre', title: 'Receptor', width: 300, formatter: function(value, row) { return row.Receptores.Personas.Nombre; } },
                            { field: 'Total.Formateado', title: 'Total', width: 90, formatter: function(value, row) { return '$' + row.Total.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"); }, sortable: true }
                        ]
                    ]
                });
                // get the datagrid object
                var g = $('#drpSelectStudents').combogrid('grid');
                //assign the data to datagrid
                g.datagrid('loadData', jsonData);
            }
        });


        Number.prototype.padLeft = function(base, chr) {
            var len = (String(base || 10).length - String(this).length) + 1;
            return len > 0 ? new Array(len).join(chr || '0') + this : this;
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <select id="drpSelectStudents" name="Students" style="width: 290px;"></select>
    </form>
</body>
</html>
