using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_SignIn : System.Web.UI.Page
{

    void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_signup_click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }

    protected void btn_signIn_Click(object sender, EventArgs e)
    {

        if (txt_username.Text.Equals("admin") && txt_password.Text.Equals("admin"))
        {
            Session["User_ID"] = "Admin";
            Response.Redirect("Admin/Main.aspx");
        }

        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select password, ID from users where email= '" + txt_username.Text + "'";
            SqlCommand cmd = new SqlCommand(query , conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string correct_pass = null;

            while(reader.Read())
            {
                correct_pass = reader[0].ToString();
                if (correct_pass.Equals(txt_password.Text))
                {
                    Session["User_ID"] = reader[1].ToString();
                    Response.Redirect("User/Main.aspx");
                }
                else
                    ShowMessage("Your Password or Username is wrong");
            }
            ShowMessage("Your Username is wrong");
        }
        
    }
}