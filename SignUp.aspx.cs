using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_SignUp : System.Web.UI.Page
{
    public void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }

    protected void btn_signup_click(object sender, EventArgs e)
    {
        String connectionString = null;
        String Query = null;

        connectionString = "Server=localhost;" +
                       "DataBase=ZoodGood;" +
                       "Trusted_Connection=Yes;";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            Query = "insert into Users values ('" +
                txt_name.Text + "', '" +
                txt_email.Text + "', '" +
                txt_password.Text + "', '" + ddl_gender.SelectedItem.Text + "', '" + txt_address.Text + "', '" + txt_phone.Text + "')";

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                cmd.ExecuteNonQuery();
                ShowMessage("you have signed up successully!!!");
                Session["name"] = txt_name.Text;
                Response.Redirect("SignIn.aspx");
            }
        }
    }

}