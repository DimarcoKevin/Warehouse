﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Warehouse {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");
        }

        protected void login_button_Click(object sender, EventArgs e) {
            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select * from dbo.users where username = '" + username.Text + "' and password = '" + password.Text + "'", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);

            if (dt.Rows.Count > 0) {
                login_message.Text = "You have successfully logged in! Welcome " + username.Text + "!";
            } else {
                login_message.Text = "Error, cannot sign you in...";
            }

            username.Text = "";
            password.Text = "";
        }
    }
}