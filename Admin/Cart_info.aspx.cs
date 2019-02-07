using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Cart_info : System.Web.UI.Page
{

    int count = 0;

    void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        int req_id = int.Parse(Request.QueryString["ID"]);
        

        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        string query = "select Cart.id , Cart.u_id , Goods.ID , Goods.Name , Goods.CompanyName ,  Goods.ShortDescription , Goods.FullDescription , Goods.Price , Goods.RemainingNo , Cart_Good.amount , Goods.CategoryID , Category.Name , Goods.Date  , Cart.is_finished , Cart.is_confirmed from Cart inner join Cart_Good on Cart.id = Cart_Good.c_id inner join Goods on Goods.ID = Cart_Good.g_id inner join Category on Goods.CategoryID = Category.ID where Cart.id = " + req_id;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if( reader[13].ToString().Equals("True") && reader[14].ToString().Equals("False") )
                    {

                    
                    TableRow row = new TableRow();
                    for (int i = 0; i < 13; i++)
                    {
                        TableCell tc = new TableCell();
                        tc.Text = reader[i].ToString();
                        row.Cells.Add(tc);
                    }

                    count++;
                    tb_cart.Rows.Add(row);
                    }
                }
            }
        }
    }


    protected void btn_accept_Click(object sender, EventArgs e)
    {
        if (count != 0)
        {
            string Cart_id = tb_cart.Rows[1].Cells[0].Text.ToString();  //All of IDs are same

            string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string queryUpdate = "Update Cart Set is_confirmed = 'True' where id = " + Cart_id + ";";
                //ShowMessage(queryUpdate);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = queryUpdate;
                cmd.ExecuteNonQuery();
            }
        }
        tb_cart.Rows.Clear();
        Response.Redirect("req_confirm.aspx");

    }
}