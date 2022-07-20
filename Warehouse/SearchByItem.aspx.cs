using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Variables;

namespace Warehouse {
    public partial class SearchByItem : System.Web.UI.Page {
        SqlConnection con = new SqlConnection(GlobalVariables.connectionString);

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void SearchButton_Click(object sender, EventArgs e) {

            // grabbing the location values for all pallets in existence 
            String select = "select loc.row, loc.x, loc.y, loc.pallet_id, pal.item_name, pal.item_color " +
                            "from locations loc join pallets pal on loc.pallet_id = pal.id " +
                            "where loc.occupied = 1 " +
                            "and pal.item_name like '%" + SearchBox.Text + "%'";

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);

            GridViewItems.DataSource = dt;
            GridViewItems.DataBind();

            SearchBox.Text = "";
        }
    }
}