using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTest.View
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        Controller Verwalter = new Controller();
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
                if (!this.IsPostBack)
                {
                Load_TN();
                }
                else
                {

                }
            MS_LADEN();

        }

        void Load_TN()
        {
            string ConnectionString = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
            MySqlConnection SQLTN = new MySqlConnection(ConnectionString);
            string TNAME = "";
            try
            {

                SQLTN.Open();
                MySqlCommand cmd1 = new MySqlCommand("Select T_NAME from Tunier", SQLTN);
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    TNAME = reader1.GetString(0);
                    TurnierList.Items.Add(TNAME);
                }
                reader1.Close();
                SQLTN.Close();
            }
            catch
            {
                lblInfo.Text = "SQL Verbindung Fehlgeschlagen";
            }
        }

            void MS_LADEN()
            {
            if (TurnierList.SelectedIndex != -1)
            {
                MS_Table.Rows.Clear();
                String MSNAME = "";
                string cs = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
                MySqlConnection SQLMS = new MySqlConnection(cs);
                SQLMS.Open();
                MySqlCommand cmd1 = new MySqlCommand("Select MS_NAME from Tunier_MS where T_NAME ='" + TurnierList.SelectedItem.Text + "'", SQLMS);
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                TableRow TR = new TableRow();
                TableCell TC = new TableCell();
                TC.Text = "Teilnehmende Mannschaften:";
                TR.Cells.Add(TC);
                MS_Table.Rows.Add(TR);
                TC = new TableCell();
                TR = new TableRow();
                while (reader1.Read())
                {
                    MSNAME = reader1.GetString(0);
                    TC = new TableCell();
                    TC.Text = MSNAME;
                    TR.Cells.Add(TC);
                    MS_Table.Rows.Add(TR);
                    TR = new TableRow();
                }
                reader1.Close();
                SQLMS.Close();
                Load_Spiele();
            } else
            {

            }
            }

        protected void TurnierList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MS_LADEN();
        }

        void Load_Spiele()
        {
            Spiele_Table.Rows.Clear();
            string sel = "select * from Spiele where T_NAME = '" + TurnierList.SelectedItem.Text + "'";
            string cs = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
            MySqlConnection SQLSP = new MySqlConnection(cs);
            SQLSP.Open();
            MySqlCommand cmd1 = new MySqlCommand(sel, SQLSP);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            TableRow TR = new TableRow();
            TableCell TC = new TableCell();
            TC.Text = "Spiel ID:";
            TR.Cells.Add(TC);
            TC = new TableCell();
            TC.Text = "Turniername:";
            TR.Cells.Add(TC);
            TC = new TableCell();
            TC.Text = "Mannschaft 1:";
            TR.Cells.Add(TC);
            TC = new TableCell();
            TC.Text = "Mannschaft 2:";
            TR.Cells.Add(TC);
            TC = new TableCell();
            TC.Text = "MS1 Tore:";
            TR.Cells.Add(TC);
            TC = new TableCell();
            TC.Text = "MS2 Tore:";
            TR.Cells.Add(TC);
            Spiele_Table.Rows.Add(TR);
            TC = new TableCell();
            TR = new TableRow();
            while (reader1.Read())
            {
                int SPID = reader1.GetInt16(0);
                string TNAME = reader1.GetString(1);
                string MS1 = reader1.GetString(2);
                string MS2 = reader1.GetString(3);
                int MS1Tore = reader1.GetInt16(4);
                int MS2Tore = reader1.GetInt16(5);
                TC = new TableCell();
                TR = new TableRow();
                TC.Text = Convert.ToString(SPID);
                TR.Cells.Add(TC);
                TC = new TableCell();
                TC.Text = TNAME;
                TR.Cells.Add(TC);
                TC = new TableCell();
                TC.Text = MS1;
                TR.Cells.Add(TC);
                TC = new TableCell();
                TC.Text = MS2;
                TR.Cells.Add(TC);
                TC = new TableCell();
                TC.Text = Convert.ToString(MS1Tore);
                TR.Cells.Add(TC);
                TC = new TableCell();
                TC.Text = Convert.ToString(MS2Tore);
                TR.Cells.Add(TC);
                TC = new TableCell();
                Spiele_Table.Rows.Add(TR);

            }
            reader1.Close();
            SQLSP.Close();
        }
    }
    }
