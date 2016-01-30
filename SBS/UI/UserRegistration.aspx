<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="UI.UserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="css/Custom.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
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

</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2">
                    <h2 style="text-align: center">Welcome to <b>SBS !</b></h2>
                </td>
            </tr>
            <tr>
                <td>
                    <h4 style="text-align: center; color: gray">The most secure bank.</h4>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MessageLabel" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td>
                    <h4 style="text-align: center; color: gray">Create New User Account</h4>
                </td>
            </tr>

        </table>


        <table runat="server" visible="true">
            <tr>
                <td></td>
                <td>
                    <asp:CheckBox ID="MerchantCheckBox" runat="server" Text="Merchant" /></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label2" runat="server" Text="MiddleName"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="MiddleNameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label3" runat="server" Text="LastName"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label14" runat="server" Text="Password"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="pwdTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label20" runat="server" Text="at least 8 char, 1 cap, 1 lower, 1 num, 1 spec (!@#$-_')"></asp:Label>
                    <asp:HiddenField ID="hashPwdHiddenField" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label15" runat="server" Text="Confirm Password"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="cpwdTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:HiddenField ID="hashCpwdHiddenField" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label5" runat="server" Text="Address 1"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Addrs1TextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label6" runat="server" Text="Address 2"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Addrs2TextBox" runat="server" Width="123px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label16" runat="server" Text="City"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label17" runat="server" Text="State"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label18" runat="server" Text="Zip Code"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="ZipTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label7" runat="server" Text="Phone Number"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="PhNumTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label8" runat="server" Text="EmailID"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="EmailTextBox" runat="server" Width="245px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label9" runat="server" Text="Security Question 1"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Question1TextBox" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label11" runat="server" Text="Answer 1"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Answer1TextBox" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label4" runat="server" Text="Security Question 2"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Question2TextBox" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label12" runat="server" Text="Answer 2"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Answer2TextBox" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label10" runat="server" Text="Security Question 3"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Question3TextBox" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="labelControl">
                    <asp:Label ID="Label13" runat="server" Text="Answer 3"></asp:Label></td>
                <td class="valueControl">
                    <asp:TextBox ID="Answer3TextBox" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="CustCreateBtn" runat="server" Text="Create" CssClass="btn btn-default" OnClick="CustCreate_Click" /></td>
            </tr>
        </table>
    </form>

    <script>
        //$('#CustCreateBtn').click(function () {
        //    //alert(hashCode($('#PasswordTextBox').val()));
        //    //$('#hashPwdHiddenField').val(hashCode($('#pwdTextBox').val()));
        //    $('#pwdTextBox').val(hashCode($('#pwdTextBox').val()));
        //    $('#cpwdTextBox').val(hashCode($('#cpwdTextBox').val()));
        //    //$('#hashCpwdHiddenField').val(hashCode($('#cpwdTextBox').val()));
        //});

        //function hashCode(str) {
        //    var hash = 0;
        //    if (str.length < 8) return 0;
        //    for (i = 0; i < str.length; i++) {
        //        char = str.charCodeAt(i);
        //        hash = ((hash << 5) - hash) + char;
        //        hash = hash & hash; // Convert to 32bit integer
        //    }
        //    return hash;
        //}
    </script>

</body>

</html>
