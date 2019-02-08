<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="Login_SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        Email:
        <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
        </br>
        Password:
        <asp:TextBox ID="txt_password" TextMode="Password" runat="server"></asp:TextBox>
        </br>
        <asp:Button ID="btn_signIn" runat="server" Text="SignIn" OnClick="btn_signIn_Click" />
        <br />
        <asp:Button ID="btn_signup" runat="server" Text="SignUp" OnClick="btn_signup_click" />

    </form>
</body>
</html>
