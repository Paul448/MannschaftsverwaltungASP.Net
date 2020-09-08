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
                TurnierList.SelectedIndex = 1;
                }
                else
                {

                }

            TurnierList.Items.Clear();
            Load_TN();
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
                
                String MSNAME = "";
                string cs = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
                MySqlConnection SQLMS = new MySqlConnection(cs);
                SQLMS.Open();
                if(TurnierList.SelectedIndex == -1)
                { 
                TurnierList.SelectedIndex = 0;
                }
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
            }

        protected void TurnierList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MS_LADEN();
        }
    }
    }
