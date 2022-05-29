using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}