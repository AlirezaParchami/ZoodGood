<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products_list.aspx.cs" Inherits="Admin_Products_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tbl_products" runat="server" Border="3">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Description</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                <asp:TableHeaderCell>Photo</asp:TableHeaderCell>
                <asp:TableHeaderCell>Show details</asp:TableHeaderCell>
                <asp:TableHeaderCell>Add to card</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br /><br />
        <asp:Table ID="tbl_categories" runat="server" Border="1">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>select</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>None</asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButton ID="rdb_0" GroupName="category" Checked="true" runat="server" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btn_cat" runat="server" Text="Select Category" OnClick="btn_cat_click" />
    </div>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="btn_back_click" />
    </form>
</body>
</html>

