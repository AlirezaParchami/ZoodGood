using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddGood : System.Web.UI.Page
{
    List<List<string>> categories;
    public static class globals
    {
        public static List<string> categories;
    }
    void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_ID"] == null || !Session["User_ID"].Equals("Admin"))
        {
            Response.Redirect("../SignIn.aspx");
        }

        categories = new List<List<string>>();

        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select ID , Name from Category";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            globals.categories = new List<string>();
            while (reader.Read())
            {
                List<string> row = new List<string>();
                row.Add(reader[0].ToString());
                row.Add(reader[1].ToString());

                categories.Add(row);
                ddl_category.Items.Add(reader[1].ToString());
            }
            conn.Close();
        }


    }


    protected void btn_back_click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }



    protected void btn_addGood_Click(object sender, EventArgs e)
    {
        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            int ddlSelectedNum = 0;
            string ddlSelected = ddl_category.Text.ToString();
            for (int i = 0; i < categories.Count; i++)
                if (categories[i][1].Equals(ddlSelected))
                {
                    ddlSelectedNum = Convert.ToInt32(categories[i][0].ToString());
                    break;
                }
            if (ddlSelectedNum.Equals(0))
                ShowMessage("You Should Select One Category");
            else
            {

                string queryIns = "insert into Goods values ("
                    + txt_goodId.Text.ToString() + ", "
                    + "'" + txt_goodName.Text.ToString() + "'" + ", "
                    + "'" + Request.Form["txt_shortDes"].ToString() + "'" + ", "
                    + "'" + Request.Form["txt_longDes"].ToString() + "'" + ", "
                    + txt_goodPrice.Text.ToString() + ", "
                    + txt_remainingNo.Text.ToString() + ", "
                    + 0 + ", "
                    + 0 + ", "
                    + ddlSelectedNum + ", "
                    + "'" + txt_companyName.Text.ToString() + "'" + ", "
                    + "'" + txt_calendar.Text.ToString() + "'"
                    + ')';
                //ShowMessage(queryIns);
                cmd.CommandText = queryIns;
                cmd.ExecuteNonQuery();
            }

        }
    }
}