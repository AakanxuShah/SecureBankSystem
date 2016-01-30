<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerEmployeeDelete.aspx.cs" Inherits="UI.CustomerEmployeeDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Delete Customer/Employee</h4>
    <div style="width:">
    <asp:DropDownList ID="AccountTypeDropDownList" runat="server" Height="22px" Width="234px">
        <asp:ListItem Selected="True">Customer</asp:ListItem>
        <asp:ListItem>Employee</asp:ListItem>
    </asp:DropDownList>
    </div>
</asp:Content>
