// Autor: Paul Jansen
// Letzte Änderung: 31.05.2020
// Personenverwaltung
// Beschreibung + Änderungen siehte GitHub
// https://github.com/Paul448/MannschaftsverwaltungASP.Net

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NetTest.View
{
    public partial class Add : System.Web.UI.Page
    {
        private Controller _verwalter;
        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
            }
            else
            {
                this.Response.Redirect(@"~\View\LoginView.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                LoadFelder();
            }
            else
            {
                LoadFelder();
                var ListMain = this.Verwalter.Personen;
                SortList(ref ListMain, true, true);
                this.Verwalter.Personen = ListMain;
            }
            TabellenErstellen();
            TabellenAktualisieren();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //Fussballspieler(string v_name, string v_vorname, int v_tore, int v_siege, int v_nummer)
            //Trainer(string v_name, string v_vorname, int v_Siege)
            //Physiotherapeut(string v_name, string v_vorname, int Bewertung)
            //Handballspieler(string v_name, string v_vorname, int v_siege)
            //Tennisspieler(string v_name, string v_vorname, int v_treffer, int v_siege)

            if (DropDownList1.Text == "Fussballspieler")
            {
                int txtTore = 0;
                int txtSiege = 0;
                int txtNummer = 0;
                try
                {
                    txtTore = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Tore"]);
                    txtSiege = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Siege"]);
                    txtNummer = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Nummer"]);
                    lbl_Info.ForeColor = System.Drawing.Color.Green;
                    lbl_Info.Text = "Person " + txtNachname.Text + " wurde Hinzugefügt!";
                }
                catch
                {
                    txtTore = 0;
                    txtSiege = 0;
                    txtNummer = 0;
                    lbl_Info.ForeColor = System.Drawing.Color.Red;
                    lbl_Info.Text = "FEHLER: Convertierung in Int nicht mögich! Benutzen sie in den Entsprechenden Textboxen nur Zahlen!";
                }
                Verwalter.Personen.Add(new Fussballspieler(txtNachname.Text, txtVorname.Text, txtTore, txtSiege, txtNummer));
            }
            else if (DropDownList1.Text == "Handballspieler")
            {
                int txtSiege = 0;
                try
                {
                    txtSiege = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Tore"]);
                    lbl_Info.ForeColor = System.Drawing.Color.Green;
                    lbl_Info.Text = "Person " + txtNachname.Text + " wurde Hinzugefügt!";
                }
                catch
                {
                    txtSiege = 0;
                    lbl_Info.ForeColor = System.Drawing.Color.Red;
                    lbl_Info.Text = "FEHLER: Convertierung in Int nicht mögich! Benutzen sie in den Entsprechenden Textboxen nur Zahlen!";
                }
                Verwalter.Personen.Add(new Handballspieler(txtVorname.Text, txtNachname.Text, txtSiege));
            }
            else if (DropDownList1.Text == "Physiotherapeut")
            {
                int txtBewertung = 0;
                try
                {
                    txtBewertung = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Tore"]);
                    lbl_Info.ForeColor = System.Drawing.Color.Green;
                    lbl_Info.Text = "Person " + txtNachname.Text + " wurde Hinzugefügt!";
                }
                catch
                {
                    txtBewertung = 0;
                    lbl_Info.ForeColor = System.Drawing.Color.Red;
                    lbl_Info.Text = "FEHLER: Convertierung in Int nicht mögich! Benutzen sie in den Entsprechenden Textboxen nur Zahlen!";
                }
                Verwalter.Personen.Add(new Physiotherapeut(txtNachname.Text, txtVorname.Text, txtBewertung));
            }
            else if (DropDownList1.Text == "Trainer")
            {
                int txtSiege = 0;
                try
                {
                    txtSiege = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Tore"]);
                    lbl_Info.ForeColor = System.Drawing.Color.Green;
                    lbl_Info.Text = "Person " + txtNachname.Text + " wurde Hinzugefügt!";
                }
                catch
                {
                    txtSiege = 0;
                    lbl_Info.ForeColor = System.Drawing.Color.Red;
                    lbl_Info.Text = "FEHLER: Convertierung in Int nicht mögich! Benutzen sie in den Entsprechenden Textboxen nur Zahlen!";
                }
                Verwalter.Personen.Add(new Trainer(txtNachname.Text, txtVorname.Text, txtSiege));
            }
            else if (DropDownList1.Text == "Tennisspieler")
            {
                int txtSiege = 0;
                int txtTreffer = 0;
                try
                {
                    txtTreffer = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Tore"]);
                    txtSiege = Convert.ToInt32(this.Request.Form["ctl00$MainContent$txt_Siege"]);
                    lbl_Info.ForeColor = System.Drawing.Color.Green;
                    lbl_Info.Text = "Person " + txtNachname.Text + " wurde Hinzugefügt!";
                }
                catch
                {
                    txtSiege = 0;
                    txtTreffer = 0;
                    lbl_Info.ForeColor = System.Drawing.Color.Red;
                    lbl_Info.Text = "FEHLER: Convertierung in Int nicht mögich! Benutzen sie in den Entsprechenden Textboxen nur Zahlen!";
                }
                Verwalter.Personen.Add(new Tennisspieler(txtNachname.Text, txtVorname.Text, txtTreffer, txtSiege));
            }
            //Global.Verwalter = this.Verwalter;
            TabellenLöschen();
            TabellenErstellen();
            TabellenAktualisieren();
        }

        private void LoadFelder()
        {
            TableRow neueRow = new TableRow();
            TextBox neuTextbox_1 = new TextBox
            {
                ID = "txt_Tore",
                Width = 200,
                Height = 25,
                AutoPostBack = false
            };
            TextBox neuTextbox_2 = new TextBox
            {
                ID = "txt_Siege",
                Width = 200,
                Height = 25,
                AutoPostBack = false
            };
            TextBox neuTextbox_3 = new TextBox
            {
                ID = "txt_Nummer",
                Width = 200,
                Height = 25,
                AutoPostBack = false
            };
            TableCell neueCelle = new TableCell
            {
                Text = "Error!_Cell",
                Width = 80,
                HorizontalAlign = HorizontalAlign.Left
            };

            if (DropDownList1.Text == "Fussballspieler")
            {
                // Erste Zeile
                neueCelle.Text = "Tore:";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_1);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();

                // Zwischenzeile
                TableCell neueCell_1 = new TableCell();
                neueCell_1.Text = "";
                neueCell_1.Height = 15;
                neueRow.Cells.Add(neueCell_1);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();

                // Dritte Zeile
                neueCelle = newCell();
                neueCelle.Text = "Siege:";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_2);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();

                // Zwischenzeile
                TableCell neueCell_4 = new TableCell();
                neueCell_4.Text = "";
                neueCell_4.Height = 15;
                neueRow.Cells.Add(neueCell_4);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();

                // Fünfte Zeile
                neueCelle = newCell();
                neueCelle.Text = "Nummer:";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_3);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();
            }
            else if (DropDownList1.Text == "Handballspieler")
            {
                // Erste Zeile
                neueCelle.Text = "Siege:";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_1);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();
            }
            else if (DropDownList1.Text == "Physiotherapeut")
            {
                // Erste Zeile
                neueCelle.Text = "Bewertung:";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_1);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();
            }
            else if (DropDownList1.Text == "Trainer")
            {
                // Erste Zeile
                neueCelle.Text = "Siege: ";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_1);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();
            }
            else if (DropDownList1.Text == "Tennisspieler")
            {
                // Erste Zeile
                neueCelle.Text = "Treffer:";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_1);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();

                // Zwischenzeile
                TableCell neueCell_1 = new TableCell();
                neueCell_1.Text = "";
                neueCell_1.Height = 15;
                neueRow.Cells.Add(neueCell_1);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();

                // Dritte Zeile
                neueCelle = newCell();
                neueCelle.Text = "Siege:";
                neueRow.Cells.Add(neueCelle);
                neueCelle = newCell();
                neueCelle.Controls.Add(neuTextbox_2);
                neueRow.Cells.Add(neueCelle);
                Table1.Rows.Add(neueRow);
                neueRow = new TableRow();
            }
            else
            {

            }
        }

        private TableCell newCell()
        {
            TableCell newCell_Out = new TableCell
            {
                Text = "Error!_Cell",
                Width = 80,
                HorizontalAlign = HorizontalAlign.Left
            };
            return newCell_Out;
        }

        public void TabellenErstellen()
        {
            int FussballCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Fussballspieler").Count();
            int HandballCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Handballspieler").Count();
            int TennisCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Tennisspieler").Count();
            int TrainerCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Trainer").Count();
            int PhysioCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Physiotherapeut").Count();

            TableRow Row = new TableRow();
            TableCell Cell = new TableCell();
            TableFussball.Font.Size = 15;
            TableHandball.Font.Size = 15;
            TableTennis.Font.Size = 15;
            TablePhysio.Font.Size = 15;
            TableTrainer.Font.Size = 15;
            TableFussball.BorderStyle = BorderStyle.Solid;
            TableFussball.CellPadding = 50;
            TableTennis.BorderStyle = BorderStyle.Solid;
            TableTennis.CellPadding = 50;
            TableHandball.BorderStyle = BorderStyle.Solid;
            TableHandball.CellPadding = 50;
            TablePhysio.BorderStyle = BorderStyle.Solid;
            TablePhysio.CellPadding = 50;
            TableTrainer.BorderStyle = BorderStyle.Solid;
            TableTrainer.CellPadding = 50;

            for (int index = 0; index < FussballCount; index++)
            {
                Row = new TableRow();
                for (int index1 = 0; index1 < 8; index1++)
                {
                    Cell = new TableCell();
                    Cell.BorderWidth = 1;
                    Cell.BorderColor = System.Drawing.Color.Black;
                    Cell.Text = " - ";
                    Row.Cells.Add(Cell);
                }
                TableFussball.Rows.Add(Row);
            }

            for (int index = 0; index < HandballCount; index++)
            {
                Row = new TableRow();
                for (int index1 = 0; index1 < 6; index1++)
                {
                    Cell = new TableCell();
                    Cell.BorderWidth = 1;
                    Cell.BorderColor = System.Drawing.Color.Black;
                    Cell.Text = " - ";
                    Row.Cells.Add(Cell);
                }
                TableHandball.Rows.Add(Row);
            }

            for (int index = 0; index < TennisCount; index++)
            {
                Row = new TableRow();
                for (int index1 = 0; index1 < 7; index1++)
                {
                    Cell = new TableCell();
                    Cell.BorderWidth = 1;
                    Cell.BorderColor = System.Drawing.Color.Black;
                    Cell.Text = " - ";
                    Row.Cells.Add(Cell);
                }
                TableTennis.Rows.Add(Row);
            }

            for (int index = 0; index < TrainerCount; index++)
            {
                Row = new TableRow();
                for (int index1 = 0; index1 < 6; index1++)
                {
                    Cell = new TableCell();
                    Cell.BorderWidth = 1;
                    Cell.BorderColor = System.Drawing.Color.Black;
                    Cell.Text = " - ";
                    Row.Cells.Add(Cell);
                }
                TableTrainer.Rows.Add(Row);
            }

            for (int index = 0; index < PhysioCount; index++)
            {
                Row = new TableRow();
                for (int index1 = 0; index1 < 6; index1++)
                {
                    Cell = new TableCell();
                    Cell.BorderWidth = 1;
                    Cell.BorderColor = System.Drawing.Color.Black;
                    Cell.Text = " - ";
                    Row.Cells.Add(Cell);
                }
                TablePhysio.Rows.Add(Row);
            }
        }

        public void TabellenAktualisieren()
        {

            int FussballCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Fussballspieler").Count();
            int HandballCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Handballspieler").Count();
            int TennisCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Tennisspieler").Count();
            int TrainerCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Trainer").Count();
            int PhysioCount = this.Verwalter.Personen.Where(o => o.GetPosition() == "Physiotherapeut").Count();

            int ID = 0;
            string Name = "";
            string vorname = "";
            DateTime Geburtsdatum = DateTime.Now;
            string string1 = "";
            string string2 = "";
            string string3 = "";
            List<Person> Listx = new List<Person>();

            for (int i1 = 0; i1 < FussballCount; i1++)
            {
                Listx = Verwalter.Personen.Where(o => o.GetPosition() == "Fussballspieler").ToList();
                Listx[i1].GetPersonData(ref ID, ref Name, ref vorname, ref Geburtsdatum, ref string1, ref string2, ref string3);
                TableFussball.Rows[i1].Cells[0].Text = vorname;
                TableFussball.Rows[i1].Cells[1].Text = Name;
                TableFussball.Rows[i1].Cells[2].Text = Geburtsdatum.ToString("dd/MM/yyyy"); ;
                TableFussball.Rows[i1].Cells[3].Text = string1;
                TableFussball.Rows[i1].Cells[4].Text = string2;
                TableFussball.Rows[i1].Cells[5].Text = string3;

                Button Btn_OK = new Button();
                Button BtnDel = CreateButtonDel();
                BtnDel.Click += (s, e) =>
                {
                    int IDvar = Convert.ToInt32(BtnDel.Attributes["ID"]);
                    PersonDel(IDvar);

                };
                Button BtnUpdate = CreateButtonUpdate();
                BtnUpdate.Click += (s, e) =>
                {
                    int Zeile = Convert.ToInt32(BtnUpdate.Attributes["Zeile"]);
                    UpdateBar(ref TableFussball, Zeile, ref Btn_OK);
                };
                // Button Del Eigenschaften
                BtnDel.Attributes.Add("ID", ID.ToString());

                // Cell Delete Eigenschaften
                TableFussball.Rows[i1].Cells[6].HorizontalAlign = HorizontalAlign.Center;
                TableFussball.Rows[i1].Cells[6].Width = 40;
                TableFussball.Rows[i1].Cells[6].BackColor = System.Drawing.Color.Red;
                TableFussball.Rows[i1].Cells[6].BorderWidth = 2;
                TableFussball.Rows[i1].Cells[6].Controls.Add(BtnDel);
                // Button Update Eigenschaften
                BtnUpdate.Attributes.Add("Zeile", i1.ToString());

                // Update Buttons
                Btn_OK.Text = "Bestätigen";
                Btn_OK.Visible = false;

                //Cell Update Eigenschaften
                TableFussball.Rows[i1].Cells[7].BackColor = System.Drawing.Color.Green;
                TableFussball.Rows[i1].Cells[7].HorizontalAlign = HorizontalAlign.Center;
                TableFussball.Rows[i1].Cells[7].Width = 0;
                TableFussball.Rows[i1].Cells[7].BorderWidth = 2;
                TableFussball.Rows[i1].Cells[7].Controls.Add(BtnUpdate);
            }

            for (int i2 = 0; i2 < TennisCount; i2++)
            {
                Listx = Verwalter.Personen.Where(o => o.GetPosition() == "Tennisspieler").ToList();
                Listx[i2].GetPersonData(ref ID, ref Name, ref vorname, ref Geburtsdatum, ref string1, ref string2, ref string3);
                TableTennis.Rows[i2].Cells[0].Text = vorname;
                TableTennis.Rows[i2].Cells[1].Text = Name;
                TableTennis.Rows[i2].Cells[2].Text = Geburtsdatum.ToString("dd/MM/yyyy"); ;
                TableTennis.Rows[i2].Cells[3].Text = string1;
                TableTennis.Rows[i2].Cells[4].Text = string2;

                Button Btn_OK = new Button();
                Button BtnDel = CreateButtonDel();
                BtnDel.Click += (s, e) =>
                {
                    int IDvar = Convert.ToInt32(BtnDel.Attributes["ID"]);
                    PersonDel(IDvar);
                };
                Button BtnUpdate = CreateButtonUpdate();
                BtnUpdate.Click += (s, e) =>
                {
                    int Zeile = Convert.ToInt32(BtnUpdate.Attributes["Zeile"]);
                    UpdateBar(ref TableFussball, Zeile, ref Btn_OK);
                };
                // Button Del Eigenschaften
                BtnDel.Attributes.Add("ID", ID.ToString());

                // Cell Delete Eigenschaften
                TableTennis.Rows[i2].Cells[5].HorizontalAlign = HorizontalAlign.Center;
                TableTennis.Rows[i2].Cells[5].Width = 40;
                TableTennis.Rows[i2].Cells[5].BackColor = System.Drawing.Color.Red;
                TableTennis.Rows[i2].Cells[5].BorderWidth = 2;
                TableTennis.Rows[i2].Cells[5].Controls.Add(BtnDel);
                // Button Update Eigenschaften
                BtnUpdate.Attributes.Add("Zeile", i2.ToString());

                // Update Buttons
                Btn_OK.Text = "Bestätigen";
                Btn_OK.Visible = false;

                //Cell Update Eigenschaften
                TableTennis.Rows[i2].Cells[6].BackColor = System.Drawing.Color.Green;
                TableTennis.Rows[i2].Cells[6].HorizontalAlign = HorizontalAlign.Center;
                TableTennis.Rows[i2].Cells[6].Width = 0;
                TableTennis.Rows[i2].Cells[6].BorderWidth = 2;
                TableTennis.Rows[i2].Cells[6].Controls.Add(BtnUpdate);
            }

            for (int i3 = 0; i3 < HandballCount; i3++)
            {
                Listx = Verwalter.Personen.Where(o => o.GetPosition() == "Handballspieler").ToList();
                Listx[i3].GetPersonData(ref ID, ref Name, ref vorname, ref Geburtsdatum, ref string1, ref string2, ref string3);
                TableHandball.Rows[i3].Cells[0].Text = vorname;
                TableHandball.Rows[i3].Cells[1].Text = Name;
                TableHandball.Rows[i3].Cells[2].Text = Geburtsdatum.ToString("dd/MM/yyyy"); ;
                TableHandball.Rows[i3].Cells[3].Text = string1;

                Button Btn_OK = new Button();
                Button BtnDel = CreateButtonDel();
                BtnDel.Click += (s, e) =>
                {
                    int IDvar = Convert.ToInt32(BtnDel.Attributes["ID"]);
                    PersonDel(IDvar);
                };
                Button BtnUpdate = CreateButtonUpdate();
                BtnUpdate.Click += (s, e) =>
                {
                    int Zeile = Convert.ToInt32(BtnUpdate.Attributes["Zeile"]);
                    UpdateBar(ref TableFussball, Zeile, ref Btn_OK);
                };
                // Button Del Eigenschaften
                BtnDel.Attributes.Add("ID", ID.ToString());

                // Cell Delete Eigenschaften
                TableHandball.Rows[i3].Cells[4].HorizontalAlign = HorizontalAlign.Center;
                TableHandball.Rows[i3].Cells[4].Width = 40;
                TableHandball.Rows[i3].Cells[4].BackColor = System.Drawing.Color.Red;
                TableHandball.Rows[i3].Cells[4].BorderWidth = 2;
                TableHandball.Rows[i3].Cells[4].Controls.Add(BtnDel);
                // Button Update Eigenschaften
                BtnUpdate.Attributes.Add("Zeile", i3.ToString());

                // Update Buttons
                Btn_OK.Text = "Bestätigen";
                Btn_OK.Visible = false;

                //Cell Update Eigenschaften
                TableHandball.Rows[i3].Cells[5].BackColor = System.Drawing.Color.Green;
                TableHandball.Rows[i3].Cells[5].HorizontalAlign = HorizontalAlign.Center;
                TableHandball.Rows[i3].Cells[5].Width = 0;
                TableHandball.Rows[i3].Cells[5].BorderWidth = 2;
                TableHandball.Rows[i3].Cells[5].Controls.Add(BtnUpdate);
            }

            for (int i4 = 0; i4 < PhysioCount; i4++)
            {
                Listx = Verwalter.Personen.Where(o => o.GetPosition() == "Physiotherapeut").ToList();
                Listx[i4].GetPersonData(ref ID, ref Name, ref vorname, ref Geburtsdatum, ref string1, ref string2, ref string3);
                TablePhysio.Rows[i4].Cells[0].Text = vorname;
                TablePhysio.Rows[i4].Cells[1].Text = Name;
                TablePhysio.Rows[i4].Cells[2].Text = Geburtsdatum.ToString("dd/MM/yyyy"); ;
                TablePhysio.Rows[i4].Cells[3].Text = string1;

                Button Btn_OK = new Button();
                Button BtnDel = CreateButtonDel();
                BtnDel.Click += (s, e) =>
                {
                    int IDvar = Convert.ToInt32(BtnDel.Attributes["ID"]);
                    PersonDel(IDvar);
                };
                Button BtnUpdate = CreateButtonUpdate();
                BtnUpdate.Click += (s, e) =>
                {
                    int Zeile = Convert.ToInt32(BtnUpdate.Attributes["Zeile"]);
                    UpdateBar(ref TableFussball, Zeile, ref Btn_OK);
                };
                // Button Del Eigenschaften
                BtnDel.Attributes.Add("ID", ID.ToString());

                // Cell Delete Eigenschaften
                TablePhysio.Rows[i4].Cells[4].HorizontalAlign = HorizontalAlign.Center;
                TablePhysio.Rows[i4].Cells[4].Width = 40;
                TablePhysio.Rows[i4].Cells[4].BackColor = System.Drawing.Color.Red;
                TablePhysio.Rows[i4].Cells[4].BorderWidth = 2;
                TablePhysio.Rows[i4].Cells[4].Controls.Add(BtnDel);
                // Button Update Eigenschaften
                BtnUpdate.Attributes.Add("Zeile", i4.ToString());

                // Update Buttons
                Btn_OK.Text = "Bestätigen";
                Btn_OK.Visible = false;

                //Cell Update Eigenschaften
                TablePhysio.Rows[i4].Cells[5].BackColor = System.Drawing.Color.Green;
                TablePhysio.Rows[i4].Cells[5].HorizontalAlign = HorizontalAlign.Center;
                TablePhysio.Rows[i4].Cells[5].Width = 0;
                TablePhysio.Rows[i4].Cells[5].BorderWidth = 2;
                TablePhysio.Rows[i4].Cells[5].Controls.Add(BtnUpdate);
            }

            for (int i5 = 0; i5 < TrainerCount; i5++)
            {
                Listx = Verwalter.Personen.Where(o => o.GetPosition() == "Trainer").ToList();
                Listx[i5].GetPersonData(ref ID, ref Name, ref vorname, ref Geburtsdatum, ref string1, ref string2, ref string3);
                TableTrainer.Rows[i5].Cells[0].Text = vorname;
                TableTrainer.Rows[i5].Cells[1].Text = Name;
                TableTrainer.Rows[i5].Cells[2].Text = Geburtsdatum.ToString("dd/MM/yyyy"); ;
                TableTrainer.Rows[i5].Cells[3].Text = string1;

                Button Btn_OK = new Button();
                Button BtnDel = CreateButtonDel();
                BtnDel.Click += (s, e) =>
                {
                    int IDvar = Convert.ToInt32(BtnDel.Attributes["ID"]);
                    PersonDel(IDvar);
                };
                Button BtnUpdate = CreateButtonUpdate();
                BtnUpdate.Click += (s, e) =>
                {
                    int Zeile = Convert.ToInt32(BtnUpdate.Attributes["Zeile"]);
                    UpdateBar(ref TableFussball, Zeile, ref Btn_OK);
                };
                // Button Del Eigenschaften
                BtnDel.Attributes.Add("ID", ID.ToString());

                // Cell Delete Eigenschaften
                TableTrainer.Rows[i5].Cells[4].HorizontalAlign = HorizontalAlign.Center;
                TableTrainer.Rows[i5].Cells[4].Width = 40;
                TableTrainer.Rows[i5].Cells[4].BackColor = System.Drawing.Color.Red;
                TableTrainer.Rows[i5].Cells[4].BorderWidth = 2;
                TableTrainer.Rows[i5].Cells[4].Controls.Add(BtnDel);
                // Button Update Eigenschaften
                BtnUpdate.Attributes.Add("Zeile", i5.ToString());

                // Update Buttons
                Btn_OK.Text = "Bestätigen";
                Btn_OK.Visible = false;

                //Cell Update Eigenschaften
                TableTrainer.Rows[i5].Cells[5].BackColor = System.Drawing.Color.Green;
                TableTrainer.Rows[i5].Cells[5].HorizontalAlign = HorizontalAlign.Center;
                TableTrainer.Rows[i5].Cells[5].Width = 0;
                TableTrainer.Rows[i5].Cells[5].BorderWidth = 2;
                TableTrainer.Rows[i5].Cells[5].Controls.Add(BtnUpdate);
            }
        }

        private void UpdateBar(ref Table varTable, int Zeile, ref Button BtnOK)
        {
            BtnOK.Visible = true;
            int CellsCount = varTable.Rows[Zeile].Cells.Count;
            varTable.Rows[Zeile + 1].Cells.Clear();
            for (int index = 0; index < 6; index++)
            {
                varTable.Rows[Zeile + 1].Cells.Add(new TableCell());
            }

            varTable.Rows[Zeile + 1].BackColor = System.Drawing.Color.LightGray;
            TextBox txtUpdateName = new TextBox
            {
                ID = "txt_updatename",
                Width = 200,
                Height = 30,
                AutoPostBack = false
            };
            txtUpdateName.Text = varTable.Rows[Zeile].Cells[1].Text;

            TextBox txtUpdateVorname = new TextBox
            {
                ID = "txt_updateVorname",
                Width = 200,
                Height = 30,
                AutoPostBack = false
            };
            txtUpdateVorname.Text = varTable.Rows[Zeile].Cells[0].Text;

            Button Btn_Abrruch = new Button
            {
                Text = "Cancel"
            };

            BtnOK.Click += (s, e) =>
            {
                //int Zeile = Convert.ToInt32(BtnUpdate.Attributes["Zeile"]);
                string vorName = TableFussball.Rows[Zeile].Cells[0].Text;
                string vName = TableFussball.Rows[Zeile].Cells[1].Text;
                int id = Verwalter.Personen.Find(x => x.Name == vName && x.Vorname == vorName).ID;

                Verwalter.Personen[id].Name = txtNachname.Text;
                Verwalter.Personen[id].Vorname = txtVorname.Text;

                TabellenLöschen();
                TabellenErstellen();
                TabellenAktualisieren();
            };

            varTable.Rows[Zeile + 1].Cells[0].Text = "Name:";
            varTable.Rows[Zeile + 1].Cells[1].Controls.Add(txtUpdateVorname);
            varTable.Rows[Zeile + 1].Cells[2].Text = "Nachname:";
            varTable.Rows[Zeile + 1].Cells[3].Controls.Add(txtUpdateName);
            varTable.Rows[Zeile + 1].Cells[4].Controls.Add(BtnOK);
            varTable.Rows[Zeile + 1].Cells[5].Controls.Add(Btn_Abrruch);
        }

        public void TabellenLöschen()
        {
            TableFussball.Rows.Clear();
            TableHandball.Rows.Clear();
            TableTennis.Rows.Clear();
            TableTrainer.Rows.Clear();
            TablePhysio.Rows.Clear();
        }

        public void PersonDel(int delID)
        {
            this.Verwalter.Personen.Remove(Verwalter.Personen.Find(x => x.ID == delID));
            TabellenLöschen();
            TabellenErstellen();
            TabellenAktualisieren();
        }

        public Button CreateButtonDel()
        {
            Button Del = new Button();
            Del.BackColor = System.Drawing.Color.Red;
            Del.Text = "Del";
            Del.Font.Size = 12;
            Del.ForeColor = System.Drawing.Color.White;
            Del.Font.Bold = true;
            Del.BorderWidth = 0;
            Del.BorderColor = System.Drawing.Color.Black;
            Del.UseSubmitBehavior = false;


            return Del;
        }

        public Button CreateButtonUpdate()
        {
            Button Update = new Button();
            Update.Text = "Bearbeiten";
            Update.BackColor = System.Drawing.Color.Green;
            Update.BorderWidth = 0;
            Update.Font.Size = 12;
            Update.ForeColor = System.Drawing.Color.White;
            Update.Font.Bold = true;

            return Update;
        }

        public void SortList(ref List<Person> varList, bool vorname, bool Aufwärts)
        {
            Person varP = null;
            int AnzahlBubble = 0;
            int AnzahlDurchläufe = 0;

            if (Aufwärts == true && vorname == false)
            {
                // Aufwärts Nachname
                for (int index2 = 1; index2 < varList.Count(); index2++)
                {
                    AnzahlDurchläufe++;
                    for (int index = 0; index < varList.Count() - 1; index++)
                    {
                        AnzahlBubble++;
                        if (varList[index].Name[0] > varList[index + 1].Name[0])
                        {
                            varP = varList[index];
                            varList[index] = varList[index + 1];
                            varList[index + 1] = varP;
                        }
                        else
                        {

                        }
                    }
                }
            }
            else if (Aufwärts == true && vorname == true)
            {
                // Aufwärts Vorname

                for (int index2 = 1; index2 < varList.Count(); index2++)
                {
                    AnzahlDurchläufe++;
                    for (int index = 0; index < varList.Count() - 1; index++)
                    {
                        AnzahlBubble++;
                        if (varList[index].Vorname[0] > varList[index + 1].Vorname[0])
                        {
                            varP = varList[index];
                            varList[index] = varList[index + 1];
                            varList[index + 1] = varP;
                        }
                        else
                        {

                        }
                    }
                }
            }
            else if (Aufwärts == false && vorname == true)
            {
                for (int index2 = 1; index2 < varList.Count(); index2++)
                {
                    AnzahlDurchläufe++;
                    for (int index = 0; index < varList.Count() - 1; index++)
                    {
                        AnzahlBubble++;
                        if (varList[index].Vorname[0] < varList[index + 1].Vorname[0])
                        {
                            varP = varList[index + 1];
                            varList[index + 1] = varList[index];
                            varList[index] = varP;
                        }
                        else
                        {

                        }
                    }
                }
            }
            else if (Aufwärts == false && vorname == false)
            {
                for (int index2 = 1; index2 < varList.Count(); index2++)
                {
                    AnzahlDurchläufe++;
                    for (int index = 0; index < varList.Count() - 1; index++)
                    {
                        AnzahlBubble++;
                        if (varList[index].Name[0] < varList[index + 1].Name[0])
                        {
                            varP = varList[index + 1];
                            varList[index + 1] = varList[index];
                            varList[index] = varP;
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            List<Person> Plist = this.Verwalter.Personen;
            bool Aufwärts = true;
            bool vorname = true;

            if(this.CheckVorname.Items[0].Selected == true)
            {
                vorname = false;
            }
            if (this.CheckAbwärts.Items[0].Selected == true)
            {
                Aufwärts = true;
            } else
            {
                Aufwärts = false;
            }
            SortList(ref Plist, vorname, Aufwärts);
            this.Verwalter.Personen = Plist;
            TabellenLöschen();
            TabellenErstellen();
            TabellenAktualisieren();
        }
    }
}