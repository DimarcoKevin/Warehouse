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
using Warehouse.Variables;

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
            String output;
            int item_id;

            SqlDataAdapter SqlAdapterResults = new SqlDataAdapter("select id from dbo.items where name = '" + item + "' and color = '" + color + "'", con);
            DataTable dtResults = new DataTable();

            SqlAdapterResults.Fill(dtResults);

            // TODO later
            // case when item/color combo doesnt exist yet
            if (dtResults.Rows.Count == 0) {
                return;
            }
            // unholy parsing...
            item_id = int.Parse(dtResults.Rows[0]["id"].ToString());

            // case when just creating a new pallet and throwing it in a location
            SqlCommand cmd = new SqlCommand("INSERT INTO Pallets (item_id, item_name, item_color, max_per_pallet, qty, user_stamp, time_stamp)" +
                    "VALUES(@ItemId, @ItemName, @ItemColor, @Max, @Quantity, @UserStamp, @TimeStamp)", con);

            cmd.Parameters.Add("@ItemId", SqlDbType.Int);
            cmd.Parameters.Add("@ItemName", SqlDbType.VarChar);
            cmd.Parameters.Add("@ItemColor", SqlDbType.VarChar);
            cmd.Parameters.Add("@Max", SqlDbType.Int);
            cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            cmd.Parameters.Add("@UserStamp", SqlDbType.VarChar);
            cmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

            cmd.Parameters["@ItemId"].Value = item_id;
            cmd.Parameters["@ItemName"].Value = item;
            cmd.Parameters["@ItemColor"].Value = color;
            cmd.Parameters["@Max"].Value = 1;
            cmd.Parameters["@Quantity"].Value = 1;
            cmd.Parameters["@UserStamp"].Value = GlobalVariables.user;
            cmd.Parameters["@TimeStamp"].Value = DateTime.Now;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            ErrorLabel.Text = "You have successfully created a pallet of " + color + " " + item + "'s";
            ErrorLabel.ForeColor = System.Drawing.Color.Blue;
        }
    }
}