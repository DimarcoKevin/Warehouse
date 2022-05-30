using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse {
    public partial class Signup : System.Web.UI.Page {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void signup_button_Click(object sender, EventArgs e) {
            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select * from dbo.users where username = '" + username.Text + "'", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);
            if (dt.Rows.Count > 0) {
                signup_message.Text = "Error, that user name is already used.";
            } else {

                SqlCommand cmd = new SqlCommand("INSERT INTO USERS(username, password, role) VALUES(@Username, @Password, @Role)", con);

                cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar);
                cmd.Parameters.Add("@Role", SqlDbType.VarChar);

                cmd.Parameters["@Username"].Value = username.Text;
                cmd.Parameters["@Password"].Value = password.Text;
                cmd.Parameters["@Role"].Value = "user";

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                signup_message.Text = "You have successfully signed up! Welcome " + username.Text + "!";
            }
        }
    }
}