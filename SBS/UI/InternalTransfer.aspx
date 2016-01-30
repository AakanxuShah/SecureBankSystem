<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InternalTransfer.aspx.cs" Inherits="UI.InternalTransfer" %>
<%@ MasterType VirtualPath="~/Site1.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<h3>Transfer</h3>
    <h4>
        <asp:Label ID="fromLabel" runat="server" Text="From" CssClass="label label-primary"></asp:Label></h4>
    <asp:DropDownList ID="FromDropDown" AutoPostBack="true" OnSelectedIndexChanged="FromDropDown_SelectedIndexChanged" runat="server" Width="280px" CssClass="dropdown-toggle">
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <h4>
        <asp:Label ID="ToLabel" runat="server" Text="To" CssClass="label label-primary"></asp:Label></h4>
    <asp:DropDownList ID="ToDropDown" runat="server" Width="280px" CssClass="dropdown-toggle">
    </asp:DropDownList>
    <br />
    <br />
    <h4>
        <asp:Label ID="amountLabel" runat="server" Text="Amount" CssClass="label label-primary"></asp:Label></h4>
    <asp:TextBox ID="AmountTransfer" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <h4>
        <asp:Label ID="ConfirmLabel" runat="server" Text="ConfirmAmount" CssClass="label label-primary"></asp:Label></h4>
    <asp:TextBox ID="ConfirmAmount" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Button ID="Transfer" runat="server" Text="ContinueTransfer" CssClass="btn btn-primary" OnClick="Transfer_Click" />--%>




    <h3>Internal Transfer</h3>

    <br />
    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From Account</span>
        <asp:DropDownList ID="FromDropDown" runat="server" 
            AutoPostBack="true" OnSelectedIndexChanged="FromDropDown_SelectedIndexChanged"
            Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>

    <br />

    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To Account</span>
        <asp:DropDownList ID="ToDropDown" runat="server" 
            Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>

    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount ($)</span>
        <asp:TextBox ID="AmountTransfer" runat="server" class="form-control" Width="250px" ></asp:TextBox>
    </div>
    <br />
    <div class="input-group">
        <span class="input-group-addon">Confirm Amount ($)</span>
        <asp:TextBox ID="ConfirmAmount" runat="server" class="form-control" Width="250px" ></asp:TextBox>
    </div>

    <br />
    <br />

    <asp:Button ID="Transfer" runat="server" Text="Transfer Amount" OnClick="Transfer_Click" CssClass="btn btn-default" />






</asp:Content>
