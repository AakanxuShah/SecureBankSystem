<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="UI.AdminHome" %>
<%@ MasterType VirtualPath="~/Site1.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home</h3>
    <div class="panel panel-default">
        <div class="panel-heading">Pending Transactions</div>
        <br />
         <asp:GridView ID="PendingTransactionGridView" runat="server" CssClass="table gridview" BorderWidth="0px" BorderColor="Transparent"
            OnRowDataBound="PendingTransactionGridView_RowDataBound" OnRowCommand="PendingTransactionGridView_RowCommand">

            <RowStyle BackColor="#EFEFEF"
                ForeColor="#333333" />

            <AlternatingRowStyle BackColor="#FEFEFE"
                ForeColor="#333333" />
            
        </asp:GridView>
    </div>

    <%--<div class="panel panel-default">
        <div class="panel-heading">Recent Activity</div>
        <div class="panel-body">
            No recent Activity
        </div>
    </div>--%>
</asp:Content>
