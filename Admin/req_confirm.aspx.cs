using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_req_confirm : System.Web.UI.Page
{

    void ShowMessage(string text)
    {
        string script = "alert(\"" + text + "!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
    }
	
	protected void btn_back_click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
	
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        List<List<String>> data = new List<List<string>>();
        int count = 0;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "select * from Cart inner join Users on Cart.u_id = Users.ID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TableRow row = new TableRow();
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 2 || i == 3)
                            continue;
                        TableCell tc = new TableCell();
                        tc.Text = reader[i].ToString();
                        row.Cells.Add(tc);
                    }

                    if (reader[2].ToString().Equals("True") && reader[3].ToString().Equals("False"))
                    {


                        // Show Detail
                        TableCell cell_detail = new TableCell();
                        Button btn_detail = new Button();
                        btn_detail.ID = "btn_detail_" + (count );
                        btn_detail.Text = "Show Detail";
                        btn_detail.Click += (s, ee) =>
                        {
                            Response.Redirect("Cart_info.aspx?ID=" + row.Cells[0].Text.ToString());
                        };
                        cell_detail.Controls.Add(btn_detail);
                        row.Cells.Add(cell_detail);



                        //Accept
                        count++;
                        TableCell cell = new TableCell();
                        Button btn = new Button();
                        btn.ID = "btn_" + (count);
                        btn.Text = "Accept";
                        btn.Click += new EventHandler(Accept);
                        cell.Controls.Add(btn);
                        row.Cells.Add(cell);

                        
                        
                        tb_req.Rows.Add(row);
                    }
                }

                conn.Close();
                reader.Close();
            }
        }
    }


    private void Accept(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string buttonId = button.ID;
        int selectedRow = Convert.ToInt32(buttonId.Split('_')[1].ToString()); //get the selected row number that has written in button id
        


        string id_row = tb_req.Rows[selectedRow].Cells[0].Text.ToString();
        string connectionString = "Server=localhost;Database=ZoodGood;Trusted_Connection=true";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string queryUpdate = "Update cart Set is_confirmed = 'True' where id = " + id_row + ";";
            cmd.CommandText = queryUpdate;
            cmd.ExecuteNonQuery();
        }
        tb_req.Rows.Remove(tb_req.Rows[selectedRow]);
        
        
    }
}