<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExternalTransfer.aspx.cs" Inherits="UI.TransferMoney" %>
<%@ MasterType VirtualPath="~/Site1.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>External Transfer</h3>

    <br />
    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From Account</span>
        <asp:DropDownList ID="FromDropDown" runat="server" 
            Width="250px" Height="35px" CssClass="form-control"></asp:DropDownList>
    </div>

    <br />

    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To Account</span>
        <asp:TextBox ID="ToTextBox" runat="server" 
            Width="250px" Height="35px" CssClass="form-control"></asp:TextBox>
    </div>

    <br />
    <div class="input-group">
        <span class="input-group-addon">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount ($)</span>
        <asp:TextBox ID="AmountTransfer" runat="server" class="form-control" Width="250px"></asp:TextBox>
    </div>
    <br />
    <div class="input-group">
        <span class="input-group-addon">Confirm Amount ($)</span>
        <asp:TextBox ID="ConfirmAmount" runat="server" class="form-control" Width="250px"></asp:TextBox>
    </div>

    <br />
    <br />

    <asp:Button ID="Transfer" runat="server" Text="Transfer Amount" OnClick="Transfer_Click" CssClass="btn btn-default" />
</asp:Content>
