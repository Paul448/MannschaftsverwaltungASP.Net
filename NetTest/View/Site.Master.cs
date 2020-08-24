// Autor: Paul Jansen
// Letzte Änderung: 31.05.2020
// Beschreibung + Änderungen siehte GitHub
// https://github.com/Paul448/MannschaftsverwaltungASP.Net

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTest
{
    public partial class SiteMaster : MasterPage
    {
        Controller Verwalter = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
            }
            else
            {

            }
            if(this.Verwalter.SQL_Verbindung.State == System.Data.ConnectionState.Open)
            {
                SQL_STATUS.Text = "SQL Online";
                SQL_STATUS.BackColor = System.Drawing.Color.Green;
            } else
            {
                SQL_STATUS.Text = "SQL Offline";
                SQL_STATUS.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}