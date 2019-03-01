using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Products_list : System.Web.UI.Page
{
    //public Image byteArrayToImage(byte[] byteArrayIn)
    //{
    //    MemoryStream ms = new MemoryStream(byteArrayIn);
    //    Image returnImage = Image.FromStream(ms);
    //    return returnImage;
    //}
    public void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }

    protected void btn_AddToCard(object sender, EventArgs e)
    {
        int row_indx = int.Parse(((Button)(sender)).ID.Split('_')[2]);

        string goods_id = tbl_products.Rows[row_indx].Cells[4].Controls[0].ID.Split('_')[1];
        string amount = ((TextBox)(tbl_products.Rows[row_indx].Cells[5].Controls[0])).Text;
        if (Session["User_ID"] == null || Session["User_ID"].Equals("Admin"))
        {
            ShowMessage("SignIn first");
            return;
        }
        string user_id = Session["User_ID"].ToString();

        //ShowMessage("goods_id: " + goods_id + " amount: " + amount);


        
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

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();
            Query = "INSERT INTO Cart_Good VALUES (" + cart_id + ", " + goods_id + ", " + amount + ")";
            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                cmd.ExecuteNonQuery();
                ShowMessage("Added to cart");
            }
        }

    }
    public void fill_product_table(string id)
    {
        tbl_products.Rows.Clear();

        String connectionString = null;
        String Query = null;

        connectionString = "Server=localhost;" +
                       "DataBase=ZoodGood;" +
                       "Trusted_Connection=Yes;";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            Query = "select ID, name, ShortDescription, price, photo " +
                    "from Goods left join Goods_Photo as T1 on (Goods.ID = T1.g_id) " +
                    "where RemainingNo > 0 and T1.image_id <= all(select T2.image_id from Goods_Photo as T2 where T2.g_id = T1.g_id)";

            if (id != "0")
                Query += (" and CategoryID=" + id);

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                int indx = 0; //row counter
                while (reader.Read())
                {
                    Button btn_show = new Button();
                    btn_show.Text = "Show";
                    btn_show.ID = "btn_" + reader[0].ToString();
                    btn_show.Click += (s, ee) => //redirect to show a good page
                    {
                        Response.Redirect("Goods_info.aspx?ID=" + btn_show.ID.Split('_')[1]);
                    };
                    //btn_show.Click += new EventHandler(btn_show_click);

                    //TextReader txt_amount = new TextReader();
                    TextBox txt_amount = new TextBox();
                    txt_amount.Text = "0";
                    Button btn_add = new Button();
                    btn_add.Text = "add to cart";
                    btn_add.ID = "btn_add_" + indx;
                    indx++;
                    btn_add.Click += new EventHandler(btn_AddToCard);



                    Image img = new Image();
                    img.Width = 75;
                    img.Height = 75;

                    TableRow tr = new TableRow();
                    
                    TableCell tc_GN = new TableCell(); // Good's Name
                    TableCell tc_GD = new TableCell(); // Good's Description
                    TableCell tc_GPr = new TableCell();// Good's Price
                    TableCell tc_GPh = new TableCell();// Good's main Photo
                    TableCell tc_btn_show = new TableCell(); //show details
                    TableCell tc_txt_amount = new TableCell();
                    TableCell tc_btn_add = new TableCell();// add to card

                    tc_GN.Text = reader[1].ToString();
                    tc_GD.Text = reader[2].ToString();
                    tc_GPr.Text = reader[3].ToString();


                    //@TODO
                    if (reader[4].ToString() != "")
                    {
                        //img.ImageUrl = "" + (byte[])reader[4];
                        img.ImageUrl = reader[4].ToString();
                    }
                    tc_GPh.Controls.Add(img);
                    tc_btn_show.Controls.Add(btn_show);
                    tc_txt_amount.Controls.Add(txt_amount);
                    tc_btn_add.Controls.Add(btn_add);


                    tr.Cells.Add(tc_GN);
                    tr.Cells.Add(tc_GD);
                    tr.Cells.Add(tc_GPr);
                    tr.Cells.Add(tc_GPh);
                    tr.Cells.Add(tc_btn_show);
                    tr.Cells.Add(tc_txt_amount);
                    tr.Cells.Add(tc_btn_add);

                    tbl_products.Rows.Add(tr);
                }
            }
        }
    }
    public void fill_category_table()

    {
        String connectionString = null;
        String Query = null;

        connectionString = "Server=localhost;" +
                           "DataBase=ZoodGood;" +
                           "Trusted_Connection=Yes;";

        //filing the category table:

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            Query = "select ID, Name from Category";

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RadioButton rdb = new RadioButton();
                    rdb.GroupName = "category";
                    rdb.Checked = false;
                    rdb.ID = "rdb_" + reader[0].ToString();
                    TableRow tr = new TableRow();
                    TableCell tc_CN = new TableCell(); // Category's Name
                    TableCell tc_rdb = new TableCell(); // radio button

                    tc_CN.Text = reader[1].ToString();
                    tc_rdb.Controls.Add(rdb);

                    tr.Cells.Add(tc_CN);
                    tr.Cells.Add(tc_rdb);

                    tbl_categories.Rows.Add(tr);
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        fill_product_table("0"); //0 means none category. So first the table is filling without category
        fill_category_table();
    }

    protected void btn_cat_click(object sender, EventArgs e)
    {
        string selected_cat_ID = "";
        int r = 0;
        foreach (TableRow row in tbl_categories.Rows)
        {
            if(r==0) // for skiping the header!
            {
                r = 1;
                continue;
            }
            RadioButton rdb = ((RadioButton)(row.Cells[1].Controls[0]));
            if (rdb.Checked)
            {
                selected_cat_ID = rdb.ID.Split('_')[1];
                break;
            }
        }
        fill_product_table(selected_cat_ID);
    }

    protected void btn_back_click(object sender, EventArgs e)
    {
        Response.Redirect("/User/Main.aspx");
    }

}