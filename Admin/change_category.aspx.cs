using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_change_category : System.Web.UI.Page
{

    void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }


    List<Pair> lists;
    protected void Page_Load(object sender, EventArgs e)
    {
       // ddl_first.Items.Clear();
        lists = new List<Pair>();
        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            
            string query = "select  id , Name from Category order by id";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            //reader.Read();
            while (reader.Read())
            {
                
                Pair p = new Pair(reader[0] , reader[1]);
                lists.Add(p);
                ddl_first.Items.Add(reader[1].ToString());
            }
            
            conn.Close();
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        
        string x="6";
        ShowMessage(ddl_first.Text.ToString());
        for (int i = 0; i < lists.Count(); i++)
            if (lists[i].Second.ToString() == (ddl_first.Text.ToString()))
            {
                x = lists[i].First.ToString();
            }

        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "Update Goods set CategoryID = 6 " +  " where CategoryID = " + x ;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            
        }
        
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "Delete from Category where ID = " + x;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        
    }
}