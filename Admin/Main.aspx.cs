using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Main : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_ID"] == null || !Session["User_ID"].Equals("Admin")) // If it is not admin, go to SignIn page
        {
            Response.Redirect("../SignIn.aspx");
        }
    }

    protected void btn_add_goods(object sender, EventArgs e)
    {
        Response.Redirect("AddGood.aspx");
    }
    protected void btn_add_category(object sender, EventArgs e)
    {
        Response.Redirect("AddCategory.aspx");
    }
    protected void btn_confirm_cart(object sender, EventArgs e)
    {
        Response.Redirect("req_confirm.aspx");
    }
    protected void btn_confirm_comment(object sender, EventArgs e)
    {
        Response.Redirect("ConfirmComment.aspx");
    }

    protected void btn_logout_click(object sender, EventArgs e)
    {
        Session["User_ID"] = "";
        Response.Redirect("../SignIn.aspx");
    }

    protected void btn_change_cat_click(object sender, EventArgs e)
    {
        Response.Redirect("change_category.aspx");
    }

}