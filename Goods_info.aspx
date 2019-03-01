<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_info.aspx.cs" Inherits="User_Goods_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        

    <div>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Image ID="img_goods" runat="server" Width="200" Height="200" ImageAlign="Right"/>
                <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
            
        <br /><br /><br />
        <asp:Table ID="tb_good_info" runat="server" BackColor="White" BorderColor="Black" 
    BorderWidth="4" ForeColor="Black" GridLines="Both" BorderStyle="Solid">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Short Description</asp:TableHeaderCell>
                <asp:TableHeaderCell>Full Description</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                <asp:TableHeaderCell>Remaining Number</asp:TableHeaderCell>
                <asp:TableHeaderCell> Rate</asp:TableHeaderCell>
                <asp:TableHeaderCell>Category ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Companany Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <br />
        




        <br />

        <br />
        
        <asp:Table ID="tbl_comments" runat="server" Border="1">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>User</asp:TableHeaderCell>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Comment</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter your comment here:"></asp:Label>
        <br />
        <textarea id="txt_comment" name="txt_comment"></textarea>
        <br />
        <asp:Button ID="btn_sub_comment" runat="server" Text="submit" OnClick="btn_sub_comment_click"/>
            <asp:Button ID="btn_back" runat="server" Text="Back" onclick="btn_back_click"/>

        <asp:RadioButtonList ID="rdblst_rate" runat="server" >
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="Button1" runat="server" Text="Save rate" onclick="btn_save_rate"/>

    </div>
    </form>
</body>
</html>
