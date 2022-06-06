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
            if (!Page.IsPostBack) {
                fillItems();
                fillColors();
            }

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
            String item = ItemDD.Text;
            String color = ColorDD.Text;
            int item_id;
            int pallet_id;
            int row, x, y;

            // item results
            SqlDataAdapter SqlAdapterResults = new SqlDataAdapter("select id from dbo.items where name = '" + item + "' and color = '" + color + "'", con);
            DataTable dtResults = new DataTable();
            SqlAdapterResults.Fill(dtResults);

            // grabbed available location 
            SqlDataAdapter SqlAdapterLocation = new SqlDataAdapter("select top 1 row, x, y from locations where occupied = 0", con);
            DataTable dtLocation = new DataTable();
            SqlAdapterLocation.Fill(dtLocation);

            // unholy location parsing
            row = int.Parse(dtLocation.Rows[0]["row"].ToString());
            x = int.Parse(dtLocation.Rows[0]["x"].ToString());
            y = int.Parse(dtLocation.Rows[0]["y"].ToString());


            // TODO later (temporary fix to warn user of non-existant item/color pair)
            // case when item/color combo doesnt exist yet
            if (dtResults.Rows.Count == 0) {
                ErrorLabel.Text = item + "  does not exist in " + color;
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // unholy parsing...
            item_id = int.Parse(dtResults.Rows[0]["id"].ToString());

            // case when just creating a new pallet and throwing it in a location
            SqlCommand cmd = new SqlCommand("INSERT INTO Pallets (item_id, item_name, item_color, max_per_pallet, qty, user_stamp, time_stamp)" +
                    "VALUES(@ItemId, @ItemName, @ItemColor, @Max, @Quantity, @UserStamp, @TimeStamp)", con);

            // instantiating and setting variables for new pallet
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
            cmd.Parameters["@Max"].Value = 1; // TODO temporary values
            cmd.Parameters["@Quantity"].Value = 1; // TODO temporary values
            cmd.Parameters["@UserStamp"].Value = GlobalVariables.user;
            cmd.Parameters["@TimeStamp"].Value = DateTime.Now;

            // opening connection calls
            con.Open();

            // creating new pallet
            cmd.ExecuteNonQuery();

            // gets id of last inserted row
            SqlDataAdapter SqlAdapterScope = new SqlDataAdapter("select top 1 id from Pallets order by id desc", con);
            DataTable dtScope = new DataTable();
            SqlAdapterScope.Fill(dtScope);

            // getting pallet_id from global scope identity
            pallet_id = int.Parse(dtScope.Rows[0]["id"].ToString());

            // updating free location with newly made pallet
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Locations set occupied = 1, pallet_id = " + pallet_id + " " +
                "where row = " + row + " and x = " + x + " and y = " + y, con);

            cmdUpdate.ExecuteNonQuery();

            // closing connection calls
            con.Close();

            ErrorLabel.Text = "You have successfully created a pallet of " + color + " " + item + "'s" + "<br />";
            ErrorLabel.Text += "This pallet has been place in Row:" + row + " X:" + x + " Y:" + y;
            ErrorLabel.ForeColor = System.Drawing.Color.Blue;
        }
    }
}