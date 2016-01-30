<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="UI.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery.keyboard.extension-typing.js"></script>
    <script src="Scripts/jquery.keyboard.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="css/Custom.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link href="css/keyboard.css" type="text/css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <tr class="spacerRowBig"></tr>
        <tr>
            <td colspan="2">
                <h2 style="text-align: center">Welcome to <b>SBS !</b></h2>
                <h4 style="text-align: center; color: gray">The most secure bank.</h4>
            </td>
        </tr>
        <%--<tr class="spacerRowBig"></tr>--%>
        <tr>
            <td style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img style="margin-top: 10px" src="images/logo.png" />
            </td>
        </tr>
        <br />
        <br />
        <h4>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Reset User Password</h4>

        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        <br /><br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Enter UserName" CssClass="label label-primary"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SendOTPBtn" runat="server" Text="Send One-Time Password" CssClass="btn btn-primary" OnClick="SendOTPBtn_Click" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Enter OTP" CssClass="label label-primary"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="OTPTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Enter New Password" CssClass="label label-primary"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="pwdTextBox" runat="server" TextMode="Password"></asp:TextBox>&nbsp;&nbsp;
        <asp:Label ID="Label20" runat="server" Text="at least 8 char, 1 cap, 1 lower, 1 num, 1 spec (!@#$-_')"></asp:Label>

        <asp:HiddenField ID="hashPwdHiddenField" runat="server"></asp:HiddenField>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Confirm New Password" CssClass="label label-primary"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="cpwdTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:HiddenField ID="hashCpwdHiddenField" runat="server"></asp:HiddenField>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ChangePwdBtn" runat="server" Text="Change Password" CssClass="btn btn-primary" OnClick="ChangePwdBtn_Click" />
        <br />
        <span>
            <input type="checkbox" id="VirtualKeyboardCheckBox" />
            Use Virtual Keyboard
        </span>
    </form>

</body>
<script>
    $('#ChangePwdBtn').click(function () {
        //alert(hashCode($('#PasswordTextBox').val()));
        $('#hashPwdHiddenField').val(hashCode($('#pwdTextBox').val()));
        $('#hashCpwdHiddenField').val(hashCode($('#cpwdTextBox').val()));
    });

    $('#VirtualKeyboardCheckBox').change(function () {
        if ($('#VirtualKeyboardCheckBox').is(':checked') == true) {
            $('#OTPTextBox').keyboard({
                autoAccept: true
            }).addTyping();
        }
        else {
            window.location.reload();
        }
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

</html>
