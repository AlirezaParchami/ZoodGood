<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Admin_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Admin main page
        <br />
        <asp:Button onclick="btn_add_goods" runat="server" Text="Add Goods" />
        <asp:Button onclick="btn_add_category" runat="server" Text="Add Category" />
        <asp:Button onclick="btn_confirm_cart" runat="server" Text="Confirm Cart" />
        <asp:Button onclick="btn_confirm_comment" runat="server" Text="Confirm Comment" />
        <asp:Button ID="btn_change_cat" runat="server" Text="Change category" OnClick="btn_change_cat_click" />
        <asp:Button ID="btn_logout" runat="server" Text="LogOut" OnClick="btn_logout_click" />
    </div>
    </form>
</body>
</html>
