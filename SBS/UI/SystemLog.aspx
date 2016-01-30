<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SystemLog.aspx.cs" Inherits="UI.SystemLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="panel panel-default">
         <div class="panel-heading">System Log</div>
         <asp:GridView ID="NonFinHistoryGridView" runat="server" CssClass="table gridview" BorderWidth="0px" BorderColor="Transparent">
            <RowStyle BackColor="#EFEFEF"
                ForeColor="#333333" />
            <AlternatingRowStyle BackColor="#FEFEFE"
                ForeColor="#333333" />
        </asp:GridView>

    </div>
</asp:Content>
