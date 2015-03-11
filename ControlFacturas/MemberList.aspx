<%@ Page Title="" Language="C#" MasterPageFile="~/ControlFacturas.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="ControlFacturas.MemberList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <link href="Content/footable.core.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="page-header">
        <h3>Member List</h3>
    </div>
    <div>
        <table id="gvMembers">
            <thead>
                <tr>
                    <th data-toggle="true">Member Id</th>
                    <th data-hide="phone">First Name</th>
                    <th data-hide="tablet,phone">Middle Name</th>
                    <th data-hide="phone">Last Name</th>
                    <th data-hide="tablet,phone">Email Id</th>
                    <th>Nickname</th>
                    <th data-hide="tablet,phone">Age</th>
                    <th data-hide="tablet,phone">Status</th>
                    <th data-hide="tablet,phone">Created On</th>
                    <th>Company</th>
                    <th data-hide="tablet,phone">Action</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="11" class="label-warning">No records found!</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="11"></td>
                </tr>
            </tfoot>
        </table>
    </div>
    <div id="BodyStructure" style="display: none;">
        <table>
            <tr>
                <td class="memberid"></td>
                <td class="firstname"></td>
                <td class="middlename"></td>
                <td class="lastname"></td>
                <td class="emailid"></td>
                <td class="nickname"></td>
                <td class="age"></td>
                <td class="isactive"></td>
                <td class="createdon"></td>
                <td class="company"></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script src="Scripts/footable.js"></script>
    <script type="text/javascript">
        var MembersList = {
            serviceAPI: '<%=ConfigurationManager.AppSettings["ApiPath"]%>',
            getMembers: function () {
                try {
                    $.ajax({
                        url: this.serviceAPI + "Member/getMembers",
                        type: "GET",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        data: [],
                        async: true,
                        success: function (response) { MembersList.getMembersSuccess(response); },
                        error: function (error) { MembersList.getMembersError(error); },
                    });
                } catch (ex) { alert('Something went wrong!'); }
            }, getMembersSuccess: function (response) {
                var data = $.parseJSON(response);
                var table = $("#gvMembers");
                // Remove tbody within the table
                table.find("tbody").html("");
                // LOOP through each member record to appeand to the tbody
                $.each(data, function (index, item) {
                    // Get the ROW structure from the hidden table
                    var row = $("#BodyStructure tr").eq(0).clone(true);
                    $(".memberid", row).html(item.MemberId);
                    $(".firstname", row).html(item.FirstName);
                    $(".middlename", row).html(item.MiddleName);
                    $(".lastname", row).html(item.LastName);
                    $(".emailid", row).html(item.EmailId);
                    $(".nickname", row).html(item.NickName);
                    $(".age", row).html(item.Age);
                    $(".isactive", row).html(item.IsActive);
                    $(".createddate", row).html(item.CreatedDate);
                    $(".company", row).html(item.Company);
                    table.find("tbody").append(row);
                });
            }, getMembersError: function (error) {
                var err = $.parseJSON(error.responseText);
                alert(err.ExceptionMessage);
            }
        };
    </script>
    <script type="text/javascript">
        $(function () {
            $('#gvMembers').footable();
            MembersList.getMembers();
            $("#gvMembers").trigger('footable_redraw');
        });
    </script>
</asp:Content>
