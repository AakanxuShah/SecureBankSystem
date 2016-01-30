<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustProfileUpdate.aspx.cs" Inherits="UI.CustProfileUpdate" %>

<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .labelControl {
            padding: 5px;
            text-align: right;
        }

        .valueControl {
            padding: 5px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4>Update Profile</h4>

    <div style="margin-left: 360px">
        <br />
        <table>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="label7" runat="server" Text="First Name"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label2" runat="server" Text="Middle Name"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="MiddleNameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label8" runat="server" Text="Last Name"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label1" runat="server" Text="Address 1"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Addrs1TextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label6" runat="server" Text="Address 2"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Addrs2TextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label3" runat="server" Text="City"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label4" runat="server" Text="State"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label5" runat="server" Text="Zip"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="ZipTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label9" runat="server" Text="Phone Number"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="PhNumTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateButton_Click" Text="Update" CssClass="btn btn-default" /></td>
            </tr>

        </table>
    </div>
</asp:Content>
