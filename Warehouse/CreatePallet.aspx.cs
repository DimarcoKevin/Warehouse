using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse {
public partial class CreatePallet : System.Web.UI.Page {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");

        
        protected void Page_Load(object sender, EventArgs e) {
            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select item from dbo.items", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);
            ItemDD.DataBind();
        }
    }
}