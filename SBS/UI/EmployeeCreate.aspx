<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeCreate.aspx.cs" Inherits="UI.EmployeeCreate" %>--%>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="EmployeeCreate.aspx.cs" Inherits="UI.EmployeeCreate" %>

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
    <h3>Create Employee</h3>

    <table>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label13" runat="server" Text="Employee Type"> </asp:Label></td>
            <td class="valueControl">
                <asp:DropDownList ID="EmpTypeDropList" runat="server">
                    <asp:ListItem Value="3">Employee</asp:ListItem>
                    <asp:ListItem Value="4">Manager</asp:ListItem>
                    <asp:ListItem Value="5">Administrator</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label1" runat="server" Text="FirstName"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label2" runat="server" Text="MiddleName"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="MiddleNameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label8" runat="server" Text="LastName"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label11" runat="server" Text="Address 1"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="Addrs1TextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label12" runat="server" Text="Address 2"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="Addrs2TextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label3" runat="server" Text="City"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label4" runat="server" Text="State"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label5" runat="server" Text="Zip"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="ZipTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label14" runat="server" Text="Password"></asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="pwdTextBox" ClientIDMode="Static" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="Label20" runat="server" Text="at least 8 char, 1 cap, 1 lower, 1 num, 1 spec (!@#$-_')"></asp:Label>
                <asp:HiddenField ID="hashPwdHiddenField" runat="server" ClientIDMode="Static" />

            </td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label15" runat="server" Text="Confirm Password"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="cpwdTextBox" ClientIDMode="Static" runat="server" TextMode="Password"></asp:TextBox>
                <asp:HiddenField ID="hashCpwdHiddenField" ClientIDMode="Static" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label6" runat="server" Text="Branch"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="BranchTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label9" runat="server" Text="PhoneNumber"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="PhNumTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label10" runat="server" Text="Email"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label7" runat="server" Text="Security Question 1"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="Question1TextBox" runat="server" Width="283px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label16" runat="server" Text="Answer 1"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="Answer1TextBox" runat="server" Width="283px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label17" runat="server" Text="Security Question 2"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="Question2TextBox" runat="server" Width="283px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelControl">
                <asp:Label ID="Label18" runat="server" Text="Answer 2"> </asp:Label></td>
            <td class="valueControl">
                <asp:TextBox ID="Answer2TextBox" runat="server" Width="283px"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="CreateBtn" runat="server" OnClick="CreateBtn_Click" Text="Create" CssClass="btn btn-default" /></td>
        </tr>
    </table>
    <script>
        $('#CreateBtn').click(function () {
            //alert(hashCode($('#PasswordTextBox').val()));
            $('#hashCpwdHiddenField').val(hashCode($('#cpwdTextBox').val()));
            $('#hashPwdHiddenField').val(hashCode($('#pwdTextBox').val()));
        });

        function hashCode(str) {
            var hash = 0;
            if (str.length < 8) return 0;
            for (i = 0; i < str.length; i++) {
                char = str.charCodeAt(i);
                hash = ((hash << 5) - hash) + char;
                hash = hash & hash; // Convert to 32bit integer
            }
            return hash;
        }
    </script>
</asp:Content>
