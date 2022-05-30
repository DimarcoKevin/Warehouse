using System;
using System.Data;
using System.Data.SqlClient;
using Warehouse.Variables;

namespace Warehouse {
    public partial class Login : System.Web.UI.Page {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void login_button_Click(object sender, EventArgs e) {
            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select * from dbo.users where username = '" + username.Text + "' and password = '" + password.Text + "'", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);

            if (dt.Rows.Count == 0) {
                login_message.Text = "Error, cannot sign you in...";
                username.Text = "";
                password.Text = "";
                return;
            }

            GlobalVariables.user = username.Text;
            Response.Redirect("Home.aspx");
      
        }
    }
}