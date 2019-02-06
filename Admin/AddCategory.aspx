<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="Admin_AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btn_add_click" />
        <br />
        <asp:Label ID="lbl_result" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btn_back" runat="server" Text="Back" onclick="btn_back_click"/>

    </div>
    </form>
</body>
</html>
