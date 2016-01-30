<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Home" %>

<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home</h3>


    <div class="panel panel-default">
        <div class="panel-heading">Linked Accounts</div>
        <div class="panel-body">
            <ul id="AccountList" runat="server" class="list-group">
                <li class="list-group-item"><span class="badge">$14</span> Sample format </li>
            </ul>
        </div>
    </div>

    <%-- <div class="panel panel-default">
        <div class="panel-heading">Recent Activity</div>
        <div class="panel-body">
            No recent Activity
        </div>
    </div>--%>
    <script src="Scripts/Custom/Master.js"></script>
    <script type="text/javascript">
        var doneTheStuff;
        $(document).ready(function () {
            if (!doneTheStuff) {
                doneTheStuff = true;
                var dataValue = "";
                setPublicKey();
                setKey();
            }
        });

        function setKey() {
            $.ajax({
                type: "POST",
                url: "Home.aspx/GetKey",
                data: {},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Something went wrong. Could not generate the key for encrypting data !");
                },
                success: function (result) {
                    window.localStorage.setItem("key", result.d);
                }
            });
        }

        function setPublicKey() {
            $.ajax({
                type: "POST",
                url: "Home.aspx/GetPublicKey",
                data: {},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Something went wrong. Could not generate the key for encrypting data !");
                },
                success: function (result) {
                    window.localStorage.setItem("publickey", result.d);
                }
            });
        }
    </script>
</asp:Content>
