// Autor: Paul Jansen
// Letzte Änderung: 31.05.2020
// Session Tabelle 
// Beschreibung + Änderungen siehte GitHub
// https://github.com/Paul448/MannschaftsverwaltungASP.Net
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTest.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            TabelleErzeugen();
            TabelleDaten();
        }

        private void TabelleDaten()
        {
            string Name = "";
            string vorname = "";
            DateTime Geburtsdatum = DateTime.Now;
            string string1 = "";
            string string2 = "";
            string string3 = "";
            int ID = 0;

            for (int i = 0; i < Verwalter.Personen.Count; i++)
            {
                Name = "";
                vorname = "";
                Geburtsdatum = DateTime.Now;
                string1 = "";
                string2 = "";
                string3 = "";

                Verwalter.Personen[i].GetPersonData(ref ID, ref Name,ref vorname,ref Geburtsdatum,ref string1,ref string2,ref string3);
                TableDB.Rows[i].Cells[0].Text = vorname;
                TableDB.Rows[i].Cells[1].Text = Name;
                TableDB.Rows[i].Cells[2].Text = Verwalter.Personen[i].GetPosition();
                TableDB.Rows[i].Cells[3].Text = Geburtsdatum.ToString("dd/MM/yyyy");
                TableDB.Rows[i].Cells[4].Text = string1;
                TableDB.Rows[i].Cells[5].Text = string2;
                TableDB.Rows[i].Cells[6].Text = string3;
            }
        }

        private void TabelleErzeugen()
        {
            int Zeile = Verwalter.Personen.Count();
            int Spalten = 7;
            TableCell Cell1 = new TableCell();
            TableRow Row1 = new TableRow();
            TableDB.BorderColor = System.Drawing.Color.Black;
            TableDB.BorderStyle = BorderStyle.Solid;
            TableDB.BorderWidth = 2;
            TableDB.CellPadding = 50;


            for (int i = 0; i < Zeile; i++)
            {
                Row1 = new TableRow();
                for(int index = 0; index < Spalten; index++)
                {
                    Cell1 = new TableCell();
                    Cell1.BorderColor = System.Drawing.Color.Black;
                    Cell1.BorderStyle = BorderStyle.Solid;
                    Cell1.BorderWidth = 1;
                    Cell1.Font.Size = 15;
                    Row1.Cells.Add(Cell1);
                }
                TableDB.Rows.Add(Row1);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
            }
            else
            {
                this.Response.Redirect(@"~\Default.aspx");
            }
        }
    }
}