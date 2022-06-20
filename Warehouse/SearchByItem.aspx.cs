﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse {
    public partial class SearchByItem : System.Web.UI.Page {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void SearchButton_Click(object sender, EventArgs e) {

            // grabbing the location values for all pallets in existence 
            String select = "select loc.row, loc.x, loc.y, loc.pallet_id, pal.item_name, pal.item_color" +
                            "from locations loc join pallets pal on loc.pallet_id = pal.id" +
                            "where loc.occupied = 1";

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(select, con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);
        }
    }
}