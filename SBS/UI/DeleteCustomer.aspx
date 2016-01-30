<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeleteCustomer.aspx.cs" Inherits="UI.DeleteCustomer" %>
<%@ MasterType VirtualPath="~/Site1.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Delete Customer</h3>
    <br />
    <br />
    <div runat="server" id="FromCustomerDiv" class="input-group">
        <span class="input-group-addon">&nbsp;From Customer</span>
        <asp:DropDownList ID="CustomerDropDown" runat="server" Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>
    <br />
    <br />
    <asp:Button ID="DeleteCustomerButton" runat="server" Text="Delete Customer" OnClick="DeleteCustomer_Click" CssClass="btn btn-default" />
</asp:Content>
