using System;
using Warehouse.Objects;

namespace Warehouse {
    public partial class CreateItem : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
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

        protected void SubmitButton_Click(object sender, EventArgs e) {
            Item item = new Item();

       
            String name;
            String color;
            String desc;
            int max;
            float price;

            item.name = ItemTextBox.Text;
            item.color = ColorDD.Text;
            item.description = ItemTextBox.Text;

            try {
                item.max_per_pallet = int.Parse(MaxTextBox.Text);
                item.price = float.Parse(PriceTextBox.Text);
            } catch(FormatException ex) {
                ErrorLabel.Text = ex.Message;
            }
            

            // validation
            // 1) all fields must be filled 
            // 2) max and price must be correct type
            // 3) cannot exist with same name/color (Those are sort of primary keys here)

        }
    }
}