using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Variables {
    public class GlobalVariables {

        // making a singleton class of Global Variables
        private GlobalVariables() { }
        private static GlobalVariables instance = null;
        public static GlobalVariables Instance {
            get {
                if (instance == null) {
                    instance = new GlobalVariables();
                }
                return instance;
            }
        }



        public static string user { get; set; }

        public static string role { get; set; }

    }
}