<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="UI.CreateAccount" %>
<%@ MasterType VirtualPath="~/Site1.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Request Create New Account</h4>
    <br />
    <asp:DropDownList ID="AccountTypeDropDownList" runat="server">
        <asp:ListItem Selected="True">SavingsAccount</asp:ListItem>
        <asp:ListItem>Checking Account</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="AccountCreateBtn" runat="server" Text="Create" CssClass="btn btn-default" OnClick="AccountCreate_click" />
</asp:Content>
