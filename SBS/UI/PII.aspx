<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="PII.aspx.cs" Inherits="UI.PII" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="input-group" id="userdiv">
        <span class="input-group-addon">Select User</span>
         <asp:DropDownList ID="Userlist" runat="server" 
            Width="245px" Height="35px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Userlist_SelectedIndexChanged">
            
         </asp:DropDownList> 
    
   </div>
   <br />
   <br />
   <div runat="server" id="OTPDiv" visible="false">
        <p>To proceed please enter the OTP that was sent to the Government mail ID</p>
        <div class="input-group" style="width: 300px">
            <span class="input-group-addon" id="basic-addon3">OTP Secret</span>
            <asp:TextBox runat="server" type="text" class="form-control" ID="OTPTextBox" aria-describedby="basic-addon3"></asp:TextBox>
            <span class="input-group-btn">
                <asp:Button ID="VerifyButton" runat="server" class="btn btn-default" Text="Verify" Onclick="VerifyButton_Click"></asp:Button>
            </span>
        </div>
       <div style="text-align: left">
            &nbsp;&nbsp;<asp:LinkButton ID="ResendOTPLink" runat="server" Text="Resend OTP" OnClick="ResendOTPLink_Click"></asp:LinkButton></div>
       </div>
        
        <div  style="width: 300px" id="UserDetails" runat="server" visible="false">
        <span class="input-group-addon" id="First name">First Name</span>
            <asp:TextBox runat="server" type="text"  class="form-control" ReadOnly="true" ID="FirstNamebox" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
             <span class="input-group-addon" id="MiddleName">Middle Name</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="MiddleNamebox" aria-describedby="basic-addon3"></asp:TextBox>               
            <br />
            <span class="input-group-addon" id="Last Name">Last Name</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="LastNamebox" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
            <span class="input-group-addon" id="Addr1">Address Line 1</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="Address1box" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
            <span class="input-group-addon" id="Addrs2">Address Line 2</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="Address2box" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
            <span class="input-group-addon" id="city">City</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="Citybox" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
            <span class="input-group-addon" id="state">State</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="Statebox" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
            <span class="input-group-addon" id="zip">Zip Code</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="Zipbox" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
            <span class="input-group-addon" id="phno">Contact Number</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="Phnobox" aria-describedby="basic-addon3"></asp:TextBox> 
            <br />
            <span class="input-group-addon" id="emailid">Email ID</span>
            <asp:TextBox runat="server" type="text" class="form-control" ReadOnly="true" ID="Mailidbox" aria-describedby="basic-addon3"></asp:TextBox>
            <br />
        
        </div>

    <br />
    <br />
    

</asp:Content> 

