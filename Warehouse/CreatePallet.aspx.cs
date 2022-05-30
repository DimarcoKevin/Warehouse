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
            SqlDataAdapter SqlAdapterItem = new SqlDataAdapter("select distinct name from dbo.items", con);
            DataTable dtItem = new DataTable();

            SqlAdapterItem.Fill(dtItem);

            ItemDD.DataSource = dtItem;
            ItemDD.DataTextField = "name";
            ItemDD.DataValueField = "name";
            ItemDD.DataBind();
            Page.Response.Write("<script>console.log('Load:');</script>");
            Page.Response.Write("<script>console.log('" + ItemDD.SelectedValue + "');</script>");
        }

        protected void ItemDD_SelectedIndexChanged(object sender, EventArgs e) {
            SqlDataAdapter SqlAdapterColor = new SqlDataAdapter("select distinct color from dbo.items where name = '" + ItemDD.SelectedValue + "'", con);
            DataTable dtColor = new DataTable();

            SqlAdapterColor.Fill(dtColor);

            ColorDD.DataSource = dtColor;
            ColorDD.DataTextField = "name";
            ColorDD.DataValueField = "name";
            ColorDD.DataBind();

            Page.Response.Write("<script>console.log('ItemChanged:');</script>");
            Page.Response.Write("<script>console.log('" + ItemDD.SelectedValue + "');</script>");


        }
    }
}