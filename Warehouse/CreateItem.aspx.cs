using System;
using System.Data;
using System.Data.SqlClient;
using Warehouse.Objects;
using Warehouse.Variables;

namespace Warehouse {
    public partial class CreateItem : System.Web.UI.Page {
        SqlConnection con = new SqlConnection(GlobalVariables.connectionString);
        public string user = GlobalVariables.user;
        protected void Page_Load(object sender, EventArgs e) {
            if (ColorDD.Items.Count == 0) {
                ColorDD.Items.Add("Red");
                ColorDD.Items.Add("Blue");
                ColorDD.Items.Add("Green");
                ColorDD.Items.Add("Yellow");
                ColorDD.Items.Add("Pink");
                ColorDD.Items.Add("Purple");
                ColorDD.Items.Add("Orange");
                ColorDD.Items.Add("Brown");
                ColorDD.Items.Add("Black");
                ColorDD.Items.Add("White");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {

            Item item = new Item();

            // validation for item name
            if (ItemTextBox.Text == "" || ItemTextBox.Text == null) {
                ErrorLabel.Text = "Item name cannot be empty";
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // validation for other fields
            try {
                item.name = ItemTextBox.Text;
                item.color = ColorDD.Text;
                item.description = DescTextBox.Text;
                item.max_per_pallet = int.Parse(MaxTextBox.Text);
                item.price = float.Parse(PriceTextBox.Text);
            } catch(FormatException ex) {
                ErrorLabel.Text = ex.Message;
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlDataAdapter SqlAdapter = new SqlDataAdapter("select * from dbo.items where name = '" + item.name + 
                                                                        "' and color = '" + item.color + "'", con);
            DataTable dt = new DataTable();

            SqlAdapter.Fill(dt);
            if (dt.Rows.Count > 0) {
                ErrorLabel.Text = "Error, that item name and color is already used.";
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
            } else {
                SqlCommand cmd = new SqlCommand("INSERT INTO Items (name, color, description, max_per_pallet, price, user_stamp, time_stamp)" +
                    "VALUES(@Name, @Color, @Description, @Max, @Price, @UserStamp, @TimeStamp)", con);

                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters.Add("@Color", SqlDbType.VarChar);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar);
                cmd.Parameters.Add("@Max", SqlDbType.Int);
                cmd.Parameters.Add("@Price", SqlDbType.Float);
                cmd.Parameters.Add("@UserStamp", SqlDbType.VarChar);
                cmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                cmd.Parameters["@Name"].Value = item.name;
                cmd.Parameters["@Color"].Value = item.color;
                cmd.Parameters["@Description"].Value = item.description;
                cmd.Parameters["@Max"].Value = item.max_per_pallet;
                cmd.Parameters["@Price"].Value = item.price;
                cmd.Parameters["@UserStamp"].Value = user;
                cmd.Parameters["@TimeStamp"].Value = DateTime.Now;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ErrorLabel.Text = "You have successfully added " + item.color + " " + item.name + "'s to the item list!";
                ErrorLabel.ForeColor = System.Drawing.Color.Blue;
            }
        }
    }
}