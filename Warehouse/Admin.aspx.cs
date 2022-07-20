using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using Warehouse.Variables;

namespace Warehouse {
    public partial class Admin : System.Web.UI.Page {
        SqlConnection con = new SqlConnection(GlobalVariables.connectionString);
        public string user = GlobalVariables.user;
        public string role = GlobalVariables.role;  
        protected void Page_Load(object sender, EventArgs e) {

            // checking if role is anything but admin
            if (!role.Equals("admin")) {
                Response.Redirect("Home.aspx");
            }
        }

    }
}