<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyCart.aspx.cs" Inherits="User_MyCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tbl_goods" runat="server" Border="3">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Goods name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="btn_finish" runat="server" Text="Finish cart" OnClick="btn_finish_click" />
        <asp:Button ID="btn_back" runat="server" Text="Back" onclick="btn_back_click"/>
    </div>
    </form>
</body>
</html>
