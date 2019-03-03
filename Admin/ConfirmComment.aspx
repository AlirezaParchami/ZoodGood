<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmComment.aspx.cs" Inherits="Admin_ConfirmComment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tbl_comments" runat="server" BorderWidth="1" border="1">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>U_Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>G_Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Comment</asp:TableHeaderCell>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Confirmed</asp:TableHeaderCell>

            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_click" />
            <asp:Button ID="btn_back" runat="server" Text="Back" onclick="btn_back_click"/>

    </div>
    </form>
</body>
</html>
