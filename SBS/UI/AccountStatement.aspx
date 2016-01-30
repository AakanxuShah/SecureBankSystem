<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AccountStatement.aspx.cs" Inherits="UI.AccountStatement" %>
<%@ MasterType VirtualPath="~/Site1.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Financial Account Statement</div>
        <br />
        <br />
        <asp:Button ID="CreatePdfButton" runat="server" OnClick="CreatePdfButton_Click" Text=" Export To PDF" Cssclass="btn btn-default"></asp:Button>
        <br />
        <br />
        <asp:GridView ID="FinHistoryGridView" runat="server" CssClass="table gridview" BorderWidth="0px" BorderColor="Transparent">
            <RowStyle BackColor="#EFEFEF"
                ForeColor="#333333" />
            <AlternatingRowStyle BackColor="#FEFEFE"
                ForeColor="#333333" />
        </asp:GridView>

        <br />
        <br />

         <%--<div class="panel-heading">Non-Financial Account Statement</div>
        <br />
        <asp:GridView ID="NonFinHistoryGridView" runat="server" CssClass="table gridview" BorderWidth="0px" BorderColor="Transparent">
            <RowStyle BackColor="#EFEFEF"
                ForeColor="#333333" />
            <AlternatingRowStyle BackColor="#FEFEFE"
                ForeColor="#333333" />
        </asp:GridView>
    </div>--%>
</asp:Content>
