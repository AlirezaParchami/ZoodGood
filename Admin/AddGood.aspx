<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGood.aspx.cs" Inherits="Admin_AddGood" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #txt_longDescription {
            height: 75px;
            width: 568px;
        }
        #txt_shortDescription {
            height: 56px;
            width: 233px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Title" runat="server" Text="Add Good"></asp:Label>
        </br>
        <asp:Label ID="lbl_goodId" runat="server" Text="Good ID: "></asp:Label>
        <asp:TextBox ID="txt_goodId" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="lbl_goodName" runat="server" Text="Good Name:"></asp:Label>
        <asp:TextBox ID="txt_goodName" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="lbl_goodPrice" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="txt_goodPrice" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_toman" runat="server" Text="Toman"></asp:Label>
        </br>
        <asp:Label ID="lbl_remainingNo" runat="server" Text="Number Of Remaining:"></asp:Label>
        <asp:TextBox ID="txt_remainingNo" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="lbl_companyName" runat="server" Text="Company: "></asp:Label>
        <asp:TextBox ID="txt_companyName" runat="server" ></asp:TextBox>
        </br>
         <asp:Label ID="lbl_category" runat="server" Text="Category: "></asp:Label>
        <asp:DropDownList ID="ddl_category" runat="server" ></asp:DropDownList>
        </br>
        <asp:Label ID="lbl_shortDes" runat="server" Text="Short Description: "></asp:Label>
        <textarea id="txt_shortDes" name="txt_shortDes"></textarea>
        </br>
        <asp:Label ID="lbl_longDes" runat="server" Text="Long Description: "></asp:Label>
        <textarea id="txt_longDes" name="txt_longDes"></textarea>
        </br>

        <asp:Label ID="lbl_date" runat="server" Text="Date: "></asp:Label>
        <asp:TextBox ID="txt_calendar" TextMode="Date" runat="server"></asp:TextBox>
        </br>
        <asp:Button ID="btn_addGood" runat="server" Text="Add Good" Height="56px" Width="110px" OnClick="btn_addGood_Click" />
        </br>

        <asp:Button ID="btn_back" runat="server" Text="Back" onclick="btn_back_click"/>


    </div>
    </form>
</body>
</html>
