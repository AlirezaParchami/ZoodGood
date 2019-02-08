<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Login_SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            
            <asp:TableCell>
                <asp:Label ID="lbl_name" runat="server" Text="Label">Name</asp:Label>
            </asp:TableCell>     
            <asp:TableCell>
                <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>
            <asp:TableRow>
            
            <asp:TableCell>
                <asp:Label ID="lbl_email" runat="server" Text="Label">Email</asp:Label>
            </asp:TableCell>     
            <asp:TableCell>
                <asp:TextBox ID="txt_email" TextMode="Email" runat="server"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            
            <asp:TableCell>
                <asp:Label ID="lbl_password" runat="server" Text="Label">Password</asp:Label>
            </asp:TableCell>     
            <asp:TableCell>
                <asp:TextBox ID="txt_password" TextMode="Password" runat="server">
                    
                </asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            
            <asp:TableCell>
                <asp:Label ID="lbl_gender" runat="server" Text="Label">Gender</asp:Label>
            </asp:TableCell>     
            <asp:TableCell>
                <asp:DropDownList ID="ddl_gender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            
            <asp:TableCell>
                <asp:Label ID="lbl_address" runat="server" Text="Label">Address</asp:Label>
            </asp:TableCell>     
            <asp:TableCell>
                <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
            </asp:TableCell>
            
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lbl_phone" runat="server" Text="Label">Phone</asp:Label>
            </asp:TableCell>     
            <asp:TableCell>
                <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:Button runat="server" ID="btn_signup" Text="Sign Up" onclick="btn_signup_click"/>

    </div>
    </form>
</body>
</html>
