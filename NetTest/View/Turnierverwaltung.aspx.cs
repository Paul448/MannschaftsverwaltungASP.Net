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
                TurnierList.SelectedIndex = 0;
                }
                else
                {

                }
            MS_LADEN();
            Add_MS();
            Spiele();

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
                while (reader1.Read())
                {
                    Button btnDel = new Button();
                    btnDel.Click += (s, e) =>
                    {
                        string MS = btnDel.Attributes["MS"];
                        string del = "delete from Tunier_MS where T_NAME ='" + TurnierList.SelectedItem.Text + "' and MS_NAME = '" + MS + "'";
                        MySqlConnection DELMS = new MySqlConnection(cs);
                        DELMS.Open();
                        MySqlCommand cmd3 = new MySqlCommand(del, DELMS);
                        cmd3.ExecuteNonQuery();
                        DELMS.Close();
                        this.Response.Redirect(@"~\View\Turnierverwaltung.aspx");
                    };
                    btnDel.Text = "Löschen";
                    MSNAME = reader1.GetString(0);
                    btnDel.Attributes.Add("MS", MSNAME);
                    TC = new TableCell();
                    TC.Text = MSNAME;
                    TR.Cells.Add(TC);
                    MS_Table.Rows.Add(TR);
                    TC = new TableCell();
                    TC.Controls.Add(btnDel);
                    TR.Cells.Add(TC);
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

        void Add_MS()
        {
            string[] ExistingMS = new string[15];
            string[] MS = new string[20];
            for (int index = 0; index < MS_Table.Rows.Count; index++)
            {
                ExistingMS[index] = MS_Table.Rows[index].Cells[0].Text;
            }
            string sel = "select * from MS";
            string cs = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
            MySqlConnection SQLMS1 = new MySqlConnection(cs);
            SQLMS1.Open();
            MySqlCommand cmd1 = new MySqlCommand(sel, SQLMS1);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            int index1 = 0;
            while(reader1.Read())
            {
                MS[index1] = reader1.GetString(0);
                index1++;
            }
            reader1.Close();

            string[] MS_LIST = MS.Except(ExistingMS).ToArray();

            TableAddMS.Visible = true;
            TableRow TR = new TableRow();
            TableCell TC = new TableCell();
            DropDownList DD = new DropDownList();
            Button BtnAdd = new Button();
            BtnAdd.Click += (s, e) =>
            {
                DropDownList DDTable = (DropDownList)TableAddMS.Rows[0].Cells[0].Controls[0];
                // Insert DB
                MySqlCommand cmd2 = new MySqlCommand("Insert Into Tunier_MS (T_NAME, MS_NAME) Values ('" + TurnierList.SelectedItem.Text + "', '" + DDTable.SelectedItem.Text + "')" , SQLMS1);
                cmd2.ExecuteNonQuery();
                this.Response.Redirect(@"~\View\Turnierverwaltung.aspx");

            };
            BtnAdd.Text = "Hinzufügen";

            for(int index = 0; index < MS_LIST.Count(); index++)
            {
                DD.Items.Add(MS_LIST[index]);
            }

            TC.Controls.Add(DD);
            TR.Cells.Add(TC);
            TC = new TableCell();
            TC.Text = "   ";
            TC.Controls.Add(BtnAdd);
            TR.Cells.Add(TC);
            TableAddMS.Rows.Add(TR);
        }

        protected void btn_MSADD_Click(object sender, EventArgs e)
        {
            Add_MS();
        }

        void Spiele()
        {
            ListMS1.Items.Clear();
            ListMS2.Items.Clear();

            string[] ExistingMS2 = new string[15];
            for (int index = 0; index < MS_Table.Rows.Count; index++)
            {
                ExistingMS2[index] = MS_Table.Rows[index].Cells[0].Text;
            }

            for(int index2 = 0; index2 < MS_Table.Rows.Count; index2++)
            {
                ListMS1.Items.Add(ExistingMS2[index2]);
                ListMS2.Items.Add(ExistingMS2[index2]);
            }
        }

        protected void btn_SpielAdd_Click(object sender, EventArgs e)
        {
            string ins = "insert into Spiele (T_NAME, MS1, MS2, MS1_Tore, MS2_Tore) Values ('";
            string cs = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
            MySqlConnection SQLMS1 = new MySqlConnection(cs);
            SQLMS1.Open();
            MySqlCommand cmd1 = new MySqlCommand(ins, SQLMS1);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
        }
    }
    }
