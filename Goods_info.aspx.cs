    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Goods_info : System.Web.UI.Page
{
    int Goods_id;
    void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }

    List<string> goods_pictures = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {

        Session["image_indx"] = 0;

        Goods_id = int.Parse(Request.QueryString["ID"]);

        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select *  from Goods where ID = " + Goods_id + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            double SumRate = 0;
            double NumRate = 0;
            while (reader.Read())
            {
                TableRow row = new TableRow();

                for (int i = 0; i < 11; i++)
                {
                    if (i == 6)
                    {
                        SumRate = Convert.ToDouble(reader[i].ToString());
                    }
                    else if (i == 7)
                    {
                        NumRate = Convert.ToDouble(reader[i].ToString());
                        TableCell tc = new TableCell();
                        if (NumRate == 0)
                            tc.Text = "0";
                        else
                            tc.Text = (SumRate / NumRate).ToString();
                        row.Cells.Add(tc);
                    }
                    else
                    {
                        TableCell tc = new TableCell();
                        tc.HorizontalAlign = HorizontalAlign.Center;
                        tc.Text = reader[i].ToString();
                        row.Cells.Add(tc);
                    }
                }
                tb_good_info.Rows.Add(row);
            }
            conn.Close();
        }

        //Putting the comments to the tbl_comments
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            string Query = "SELECT Users.FullName, Comment._date, Comment._text " +
                           "FROM Comment join Users on (Comment.u_id = Users.ID) " +
                           "WHERE is_confirmed = 1 and g_id = " + Goods_id;


            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TableRow tr = new TableRow();

                    TableCell tc_fullname = new TableCell();
                    TableCell tc_date = new TableCell();
                    TableCell tc_comment = new TableCell();

                    tc_fullname.Text = reader[0].ToString();
                    tc_date.Text = reader[1].ToString();
                    tc_comment.Text = reader[2].ToString();

                    tr.Cells.Add(tc_fullname);
                    tr.Cells.Add(tc_date);
                    tr.Cells.Add(tc_comment);

                    tbl_comments.Rows.Add(tr);
                }
            }
        }

        //finding pictures url
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select photo from Goods_Photo where g_id = " + Goods_id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                goods_pictures.Add(reader[0].ToString());
            }
        }
        //ShowMessage(goods_pictures.Count.ToString());
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int indx=0;
        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select * from slide_show_image_id";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                indx = int.Parse(reader[0].ToString());
            }
        }

        indx %= goods_pictures.Count;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "update slide_show_image_id set no = no+1";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

        }


        //ShowMessage("salam" + image_indx);
        img_goods.ImageUrl = goods_pictures[indx];

    }

    protected void btn_save_rate(object sender, EventArgs e)
    {
        string rate = rdblst_rate.SelectedItem.ToString();
        //ShowMessage(rate);

        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();
            string Query = "Update Goods set SumRates = SumRates + " + rate + 
                           " Update Goods set NumRates = NumRates + 1 ";

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                cmd.ExecuteNonQuery();

            }
        }

    }

    protected void btn_back_click(object sender, EventArgs e)
    {
        Response.Redirect("Products_list.aspx");
    }

    protected void btn_sub_comment_click(object sender, EventArgs e)
    {
        if(Session["User_ID"].Equals(""))
        {
            ShowMessage("You haven't login yet!");
            return;
        }

        string comment = Request.Form["txt_comment"].ToString();

        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            string Query = "INSERT INTO Comment (u_id, g_id, _text, is_confirmed, _date) VALUES (" +
                Session["User_ID"] + ", " +
                Goods_id + ", '" +
                comment + "', " +
                0 + ", '" +
                DateTime.Now.ToString() + "')";




            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                cmd.ExecuteNonQuery();

            }

        }
    }
}