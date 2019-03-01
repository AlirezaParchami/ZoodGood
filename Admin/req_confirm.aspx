<%@ Page Language="C#" AutoEventWireup="true" CodeFile="req_confirm.aspx.cs" Inherits="Admin_req_confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tb_req" runat="server"  BackColor="White" BorderColor="Black" 
    BorderWidth="1" ForeColor="Black" GridLines="Both" BorderStyle="Solid">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Cart ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>User ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Email</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="btn_back" runat="server" Text="Back" onclick="btn_back_click"/>

    </div>
    </form>
</body>
</html>
