using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_ID"] == null || !Session["User_ID"].Equals("Admin"))
        {
            Response.Redirect("../SignIn.aspx");
        }
    }
    protected void btn_back_click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
    protected void btn_add_click(object sender, EventArgs e)
    {
        String connectionString = null;
        String Query = null;

        connectionString = "Server=localhost;" +
                       "DataBase=ZoodGood;" +
                       "Trusted_Connection=Yes;";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            Query = "insert into Category (Name) values ('"  + txt_name.Text +  "')";

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                cmd.ExecuteNonQuery();
                lbl_result.Text = txt_name.Text + " Category has been added.";
                txt_name.Text = "";
            }
        }
    }
}