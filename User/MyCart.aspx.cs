using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MyCart : System.Web.UI.Page
{
    public void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }
    public string get_cart_id(string user_id)
    {
        String Query;
        String connectionString = "Server=localhost;" +
                       "DataBase=ZoodGood;" +
                       "Trusted_Connection=Yes;";
        string cart_id = "";
        while (cart_id.Equals(""))
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                Query = "SELECT id FROM Cart WHERE is_finished=0 and u_id=" + user_id;

                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cart_id = reader[0].ToString();
                    }
                    reader.Close();
                }

                if (cart_id.Equals(""))
                {
                    Query = "INSERT INTO Cart (u_id, is_finished, is_confirmed, date) VALUES (" + user_id + ", 0, 0, '" + DateTime.Now.ToString() + "')";
                    using (SqlCommand cmd2 = new SqlCommand(Query, cnn))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
        }
        return cart_id;
    }

    protected void btn_finish_click(object sender, EventArgs e)
    {
        string connectionString = "Server=localhost;" +
                      "DataBase=ZoodGood;" +
                      "Trusted_Connection=Yes;";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            string Query = "UPDATE Cart set is_finished = 1 where id = " + get_cart_id(Session["User_ID"].ToString());

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        ShowMessage("Cart saved");
        Response.Redirect(Request.RawUrl);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["User_ID"]==null || Session["User_ID"].Equals("") || Session["User_ID"].ToString().Equals("Admin"))
        {
            Response.Redirect("../SignIn.aspx");
        }


        string u_id = Session["User_ID"].ToString();
        string cart_id = get_cart_id(u_id);

        string connectionString = "Server=localhost;" +
                      "DataBase=ZoodGood;" +
                      "Trusted_Connection=Yes;";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            string Query = "SELECT Goods.Name, Cart_Good.amount " + 
                           "FROM Cart_Good join Goods on (Goods.ID = Cart_Good.g_id) " +
                           "WHERE c_id = " + cart_id;

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TableRow tr = new TableRow();

                    TableCell tc_GoodsName = new TableCell();
                    TableCell tc_GoodsAmount = new TableCell();

                    tc_GoodsName.Text = reader[0].ToString();
                    tc_GoodsAmount.Text = reader[1].ToString();

                    tr.Cells.Add(tc_GoodsName);
                    tr.Cells.Add(tc_GoodsAmount);

                    tbl_goods.Rows.Add(tr);
                }
            }
        }
    }
    protected void btn_back_click(object sender, EventArgs e)
    {
        Response.Redirect("../User/Main.aspx");
    }
}