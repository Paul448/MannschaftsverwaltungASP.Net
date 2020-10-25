using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTest.View
{
    public partial class PersonenSQL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReadTable();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CreateInsertTable();
        }
        void ReadTable()
            {
            TSpieler.Rows.Clear();
                string ConnectionString = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
                MySqlConnection SQL_Laden = new MySqlConnection(ConnectionString);
                SQL_Laden.Open();
                String Select_Fussball = "select PS_NAME, PS_Vname, SP.MS_NAME, FPS_TORE, FPS_Siege, FPS_NR from FussballSP SP inner join PersonData PS on SP.PS_ID = PS.PS_ID";
                //String Select_Trainer = "select * from Trainer TR inner join PersonData PS on TR.PS_ID = PS.PS_ID";

                MySqlCommand SL_FSB = new MySqlCommand(Select_Fussball, SQL_Laden);
                TableCell Cell = new TableCell();
                TableRow Row = new TableRow();
                MySqlDataReader reader1 = SL_FSB.ExecuteReader();
                while (reader1.Read())
                {
                    Row.Height = 30;
                    Row.Width = 400;
                    Cell.Text = reader1.GetString(0);
                    Cell.Width = 25;
                    Row.Cells.Add(Cell);
                    Cell = new TableCell();
                    Cell.Text = reader1.GetString(1);
                    Cell.Width = 25;
                    Row.Cells.Add(Cell);
                    Cell = new TableCell();
                    Cell.Text = reader1.GetString(2);
                    Cell.Width = 25;
                    Row.Cells.Add(Cell);
                    Cell = new TableCell();
                    Cell.Text = reader1.GetString(3) + " Tore";
                    Cell.Width = 25;
                    Row.Cells.Add(Cell);
                    Cell = new TableCell();
                    Cell.Text = reader1.GetString(4) + " Siege";
                    Cell.Width = 25;
                    Row.Cells.Add(Cell);
                    Cell = new TableCell();
                    Cell.Text = reader1.GetString(5) + " Nr";
                    Cell.Width = 25;
                    Row.Cells.Add(Cell);
                    Cell = new TableCell();
                    TSpieler.Rows.Add(Row);
                    Row = new TableRow();
                }
                reader1.Close();
                SQL_Laden.Close();
            }

            void NewFSP(string vName, string Name, string MS, int Tore)
            {
            string ConnectionString = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
            MySqlConnection SQL_INS = new MySqlConnection(ConnectionString);
                SQL_INS.Open();
                string max = "select max(PS_ID) from PersonData";
                MySqlCommand max_PS_ID = new MySqlCommand(max, SQL_INS);
                MySqlDataReader rd1 = max_PS_ID.ExecuteReader();
                int MaxPS_ID;

                while(rd1.Read())
                {
                    MaxPS_ID = rd1.GetInt16(0);
                }
            }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            BtnNew.Visible = false;
            TNEW.Visible = true;
            ReadTable();
        }

        void CreateInsertTable()
        {
            TNEW.Rows.Clear();
            TableCell Cell = new TableCell();
            TableRow Row = new TableRow();
            Row.Height = 10;
            Row.Width = 400;
            // HEADER
            Cell.Text = "Vorname:";
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            Cell.Text = "Nachname:";
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            Cell.Text = "Mannschaft:";
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            Cell.Text = "Tore:";
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            TNEW.Rows.Add(Row);
            Row = new TableRow();
            // CONTROLS
            Cell = new TableCell();
            TextBox txtVorname = new TextBox();
            Cell.Controls.Add(txtVorname);
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            TextBox txtNachname = new TextBox();
            Cell.Controls.Add(txtNachname);
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            DropDownList BoxL = new DropDownList();
            BoxMS(ref BoxL);
            Cell.Controls.Add(BoxL);
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            TextBox txtTore = new TextBox();
            Cell.Controls.Add(txtTore);
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            TNEW.Rows.Add(Row);
            Row = new TableRow();
            Cell = new TableCell();
            Cell.BorderWidth = 0;
            Button btn1 = new Button();
            btn1.Click += (s, e) =>
            {
                NewFSP(txtVorname.Text, txtNachname.Text, BoxL.SelectedItem.Text, Convert.ToInt32(txtTore.Text));
            };
            Cell.Controls.Add(btn1);
            btn1.Text = "Bestätigen";
            Row.Cells.Add(Cell);
            Cell = new TableCell();
            Cell.BorderWidth = 0;
            Button btn2 = new Button();
            btn2.Text = "Abbrechen";
            Cell.Controls.Add(btn2);
            Row.Cells.Add(Cell);
            TNEW.Rows.Add(Row);
        }

        void BoxMS(ref DropDownList box)
        {
            string ConnectionString = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
            MySqlConnection MS_LADEN = new MySqlConnection(ConnectionString);
            MS_LADEN.Open();
            string Sel = "select MS_NAME from MS";
            MySqlCommand selms = new MySqlCommand(Sel, MS_LADEN);
            MySqlDataReader rd = selms.ExecuteReader();

            while(rd.Read())
            {
                box.Items.Add(rd.GetString(0));
            }
            rd.Close();
            MS_LADEN.Close();
        }
    }
}