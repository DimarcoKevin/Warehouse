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

            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select name, color from dbo.items", con);
            DataTable dtItem = new DataTable();

            SqlAdapter.Fill(dtItem);

            DataRow[] rows = dtItem.Select("Unique name");

            ItemDD.DataSource = dtItem;
            ItemDD.DataTextField = "name";
            ItemDD.DataValueField = "name";
            ItemDD.DataBind();



         
            Page.Response.Write("<script>console.log('Load:');</script>");
            Page.Response.Write("<script>console.log('" + ItemDD.SelectedValue + "');</script>");

            //SqlDataAdapter SqlAdapterColor = new SqlDataAdapter("select color from dbo.items where name = '" + ItemDD.SelectedValue + "'", con);
            //DataTable dtColor = new DataTable();

            //SqlAdapterColor.Fill(dtColor);

            //ColorDD.DataSource = dtColor;
            //ColorDD.DataTextField = "color";
            //ColorDD.DataValueField = "color";
            //ColorDD.DataBind();
        }

        protected void ItemDD_SelectedIndexChanged(object sender, EventArgs e) {
            //SqlDataAdapter SqlAdapterColor = new SqlDataAdapter("select distinct color from dbo.items where name = '" + ItemDD.SelectedValue + "'", con);
            //DataTable dtColor = new DataTable();

            //SqlAdapterColor.Fill(dtColor);

            //ColorDD.DataSource = dtColor;
            //ColorDD.DataTextField = "name";
            //ColorDD.DataValueField = "name";
            //ColorDD.DataBind();

            Page.Response.Write("<script>console.log('ItemChanged:');</script>");
            //Page.Response.Write("<script>console.log('" + ItemDD.SelectedValue + "');</script>");


        }
    }
}