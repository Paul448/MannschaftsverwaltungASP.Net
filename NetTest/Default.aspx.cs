// Mannschaftsverwaltung ASP.Net
// Autor: Paul Jansen


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTest
{
    public partial class _Default : Page
    {
        Controller Verwalter = new Controller();
       protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
            }
            else
            {
                this.Session["Verwalter"] = new Controller();
                Verwalter = (Controller)this.Session["Verwalter"];
                Verwalter.run();
            }
        }
    }
}