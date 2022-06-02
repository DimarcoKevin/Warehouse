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
    public partial class Home : System.Web.UI.Page {
        public string user = GlobalVariables.user;

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e) {

            // grabbing the users role right away
            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select role from dbo.users where username = '" + user + "'", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);

            Object data = dt.Rows[0][0];

            GlobalVariables.user = data.ToString();

        }
    }
}