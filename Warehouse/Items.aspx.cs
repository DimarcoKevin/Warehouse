using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse {
    public partial class Items : System.Web.UI.Page {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void SearchButton_Click(object sender, EventArgs e) {
            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select * from dbo.items where name like ('%" + SearchBox.Text + "%')", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);

            GridViewItems.DataSource = dt;
            GridViewItems.DataBind();

            SearchBox.Text = "";
        }

        protected void ShowAllButton_Click(object sender, EventArgs e) {
            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select * from dbo.items where name like ('%%')", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);
            dt.Columns.Add("modify", typeof(char));
            dt.Columns.Add("delete", typeof(char));
            
            for(int i = 0; i < dt.Rows.Count; i++) {
                dt.Rows[i]["modify"] = "y";
                dt.Rows[i]["delete"] = "x";
            }


            GridViewItems.DataSource = dt;
            GridViewItems.DataBind();

            SearchBox.Text = "";
        }
    }
}