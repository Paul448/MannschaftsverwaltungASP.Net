using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTest.View
{
    public partial class SQLview : System.Web.UI.Page
    {
        private Controller _verwalter;
        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_init(object sender, EventArgs e)
        {
            //this.Verwalter = Global.Verwalter;
        }

        void TabellenErstellen()
        {

        }

        void TabellenFüllen()
        {

        }
    }
}