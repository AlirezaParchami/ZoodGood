using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["User_ID"]==null || Session["User_ID"].Equals("") || Session["User_ID"].Equals("Admin"))
            Response.Redirect("../SignIn.aspx");
    }
    protected void btn_goods_list_click(object sender, EventArgs e)
    {
        Response.Redirect("../Products_list.aspx");
    }
    protected void btn_my_cart_click(object sender, EventArgs e)
    {
        Response.Redirect("MyCart.aspx");
    }
    protected void btn_logout_click(object sender, EventArgs e)
    {
        Session["User_ID"] = "";
        Response.Redirect("../SignIn.aspx");
    }
}