<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeleteEmployee.aspx.cs" Inherits="UI.DeleteEmployee" %>
<%@ MasterType VirtualPath="~/Site1.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Delete Employee</h3>
    <br />
    <br />
    <div runat="server" id="FromEmployeeDiv" class="input-group">
        <span class="input-group-addon">&nbsp;From Employee</span>
        <asp:DropDownList ID="EmployeeDropDown" runat="server" Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>
    <br />
    <br />
    <asp:Button ID="DeleteEmployeeButton" runat="server" Text="Delete Employee" OnClick="DeleteEmployee_Click" CssClass="btn btn-default" />
</asp:Content>