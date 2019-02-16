<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="User_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        User's main page<br />Select one of the following:<br />
        <asp:Button ID="btn_goods_list" runat="server" Text="Goods List" onclick="btn_goods_list_click"/>
        <asp:Button ID="btn_my_cart" runat="server" Text="My cart"       onclick="btn_my_cart_click"/>
        <asp:Button ID="btn_logout" runat="server" Text="LogOut"         onclick="btn_logout_click"/>
    </div>
    </form>
</body>
</html>
