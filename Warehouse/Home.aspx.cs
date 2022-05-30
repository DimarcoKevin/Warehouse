using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Variables;

namespace Warehouse {
    public partial class Home : System.Web.UI.Page {
        public string user = GlobalVariables.user;
        
        protected void Page_Load(object sender, EventArgs e) {
            
        }
    }
}