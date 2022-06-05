using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Objects;

namespace Warehouse {
public partial class CreatePallet : System.Web.UI.Page {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=Warehouse; Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e) {

            fillItems();
            fillColors();


        }

        protected void fillItems() {
            SqlDataAdapter SqlAdapterItem = new SqlDataAdapter("select distinct name from dbo.items", con);
            DataTable dtItem = new DataTable();

            SqlAdapterItem.Fill(dtItem);

            ItemDD.DataSource = dtItem;
            ItemDD.DataTextField = "name";
            ItemDD.DataValueField = "name";
            ItemDD.DataBind();
        }

        protected void fillColors() {
            SqlDataAdapter SqlAdapterColor = new SqlDataAdapter("select distinct color from dbo.items", con);
            DataTable dtColor = new DataTable();

            SqlAdapterColor.Fill(dtColor);

            ColorDD.DataSource = dtColor;
            ColorDD.DataTextField = "color";
            ColorDD.DataValueField = "color";
            ColorDD.DataBind();
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            String item = ItemDD.SelectedValue;
            String color = ColorDD.SelectedValue;



        }
    }
}