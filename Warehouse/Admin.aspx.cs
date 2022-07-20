using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Variables;

namespace Warehouse {
    public partial class Admin : System.Web.UI.Page {
        SqlConnection con = new SqlConnection(GlobalVariables.connectionString);
        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}