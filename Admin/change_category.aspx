<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change_category.aspx.cs" Inherits="Admin_change_category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_change" runat="server" Text="Delete Category"></asp:Label>
        <asp:DropDownList ID="ddl_first" runat="server" ></asp:DropDownList>
       
       
        <br />
        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
    </div>
    </form>
</body>
</html>
