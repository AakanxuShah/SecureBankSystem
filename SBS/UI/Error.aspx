<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="UI.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SBS - Error</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <a class="navbar-brand" href="#">
                    SBS</a>
                </div>
            </nav>
    </div>
        <div class="errorContent">
            Something Happened! <br /> If you were logged in, we have logged you out. <br />
            <a href="UserLogin.aspx"> Click here</a> to login again.
        </div>
    </form>
</body>
</html>
