using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ConfirmComment : System.Web.UI.Page
{
    protected void btn_back_click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_ID"] == null || !Session["User_ID"].Equals("Admin"))
        {
            Response.Redirect("../SignIn.aspx");
        }

        String connectionString = null;
        String Query = null;

        connectionString = "Server=localhost;" +
                       "DataBase=ZoodGood;" +
                       "Trusted_Connection=Yes;";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();

            Query = "select Comment.ID, FullName, Goods.Name, _text, _date " +
                    "from Comment join Users on (u_id = Users.ID) join Goods on (g_id = Goods.ID) " +
                    "where is_confirmed=0;";

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc_CI = new TableCell(); //Comment ID
                    TableCell tc_FN = new TableCell(); //FullName
                    TableCell tc_GN = new TableCell(); //GoodName
                    TableCell tc_txt = new TableCell();//coment text
                    TableCell tc_DT = new TableCell(); //Date
                    TableCell tc_ch = new TableCell(); // CheckBox
                    tc_CI.Text = reader[0].ToString();
                    tc_FN.Text = reader[1].ToString();
                    tc_GN.Text = reader[2].ToString();
                    tc_txt.Text = reader[3].ToString();
                    tc_DT.Text = reader[4].ToString();
                    CheckBox chb = new CheckBox();
                    chb.Checked = false;
                    tc_ch.Controls.Add(chb);

                    tr.Cells.Add(tc_CI);
                    tr.Cells.Add(tc_FN);
                    tr.Cells.Add(tc_GN);
                    tr.Cells.Add(tc_txt);
                    tr.Cells.Add(tc_DT);
                    tr.Cells.Add(tc_ch);

                    tbl_comments.Rows.Add(tr);
                }
            }
        }
        
    }
    public void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }

    protected void btn_save_click(object sender, EventArgs e)
    {
        String connectionString = "Server=localhost;" +
                                  "DataBase=ZoodGood;" +
                                  "Trusted_Connection=Yes;";

        SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

        bool header = true;
        foreach (TableRow tr in tbl_comments.Rows)
        {
            if (header)
            {
                header = false;
                continue;
            }
            if (((CheckBox)(tr.Cells[5].Controls[0])).Checked)
            {
                string Query = "Update Comment " + "set is_confirmed = 1 " + "where Comment.ID = " + tr.Cells[0].Text + ";";
                SqlCommand cmd = new SqlCommand(Query, cnn);

                cmd.ExecuteNonQuery();

            }
        }
        Response.Redirect(Request.RawUrl);
    }

}