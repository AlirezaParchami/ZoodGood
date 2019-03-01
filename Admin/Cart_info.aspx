<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart_info.aspx.cs" Inherits="Admin_Cart_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tb_cart" runat="server"  BackColor="White" BorderColor="Black" 
    BorderWidth="1" ForeColor="Black" GridLines="Both" BorderStyle="Solid">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Cart ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>User ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Product ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Product Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Company Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Short Description</asp:TableHeaderCell>
                <asp:TableHeaderCell>Long Description</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                <asp:TableHeaderCell>Product Remaining</asp:TableHeaderCell>
                <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                <asp:TableHeaderCell>Category ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Category</asp:TableHeaderCell>
                <asp:TableHeaderCell>Product Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Condition</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
        <asp:Button ID="btn_accept" runat="server" Text="Accept Request" OnClick="btn_accept_Click" />
    </form>
</body>
</html>
