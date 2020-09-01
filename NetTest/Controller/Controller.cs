using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace NetTest
{
    public partial class Controller
    {
        private List<Person> _Personen;
        private List<Mannschaft> _Mannschaften;
        private int _selectedMannschaft;
        private MySqlConnection _SQLconnection;
        private string _username;
        public List<Person> Personen { get => _Personen; set => _Personen = value; }
        public List<Mannschaft> Mannschaften { get => _Mannschaften; set => _Mannschaften = value; }
        public int SelectedMannschaft { get => _selectedMannschaft; set => _selectedMannschaft = value; }
        public MySqlConnection SQL_Verbindung { get => _SQLconnection; set => _SQLconnection = value; }
        public string Username { get => _username; set => _username = value; }

        public Controller()
        {
            this.SelectedMannschaft = 0;                                                                             
        }

        public void run()
        {
            Verbindungsaufbau();
            Testdaten();

            //Fussballspieler(string v_name, string v_vorname, int v_tore, int v_siege, int v_nummer)
            //Trainer(string v_name, string v_vorname, int v_Siege)
            //Physiotherapeut(string v_name, string v_vorname, int Bewertung)
            //Handballspieler(string v_name, string v_vorname, int v_siege)
            //Tennisspieler(string v_name, string v_vorname, int v_treffer, int v_siege)

            List<Person> Liste = new List<Person>();
            Liste.Add(new Fussballspieler("Caumer", "Peter", 145, 22, 5));
            Liste.Add(new Fussballspieler("Auler", "Marvin", 30, 10, 22));
            Liste.Add(new Trainer("Jan", "Daulsberg", 0));
            Liste.Add(new Fussballspieler("Müller", "Dorsten", 140, 20, 7));
            Liste.Add(new Fussballspieler("Thomas", "Müller", 523, 362, 1));
            Liste.Add(new Physiotherapeut("Tokyo", "Rot", 89));
            Liste.Add(new Fussballspieler("Losser", "Winner", 12, 21, 54));
            Liste.Add(new Physiotherapeut("Jonny", "since", 69));
            Liste.Add(new Handballspieler("Dauer", "Auer", 69));
            Liste.Add(new Handballspieler("Power", "Mauer", 69));
            Liste.Add(new Tennisspieler("Lisa", "Müller", 16, 25));
            Liste.Add(new Tennisspieler("Boris", "Boris", 84, 48));
            this.Personen = Liste;

            List<Mannschaft> Liste2 = new List<Mannschaft>();
            Liste2.Add(new Mannschaft("FC Planlos"));
            Liste2.Add(new Mannschaft("FC Testing"));
            Liste2[0].Personen.Add(Liste[1]);
            Liste2[0].Personen.Add(Liste[4]);
            Liste2[1].Personen.Add(Liste[2]);
            Liste2[1].Personen.Add(Liste[7]);
            this.Mannschaften = Liste2;
            //SQLconnection();
        }

        /*
        public void SQLconnection()
        {
            List<Person> SQLpersonen = new List<Person>();
            List<Mannschaft> SQLmannschaft = new List<Mannschaft>();
            try
            {
                this.SQLconn = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='main';username=root;password=root");
                this.SQLconn.Open();
                if (this.SQLconn.State == System.Data.ConnectionState.Open)
                {
                    // Verbindung Aufgebaut
                    MySqlCommand cmdListPersonen = new MySqlCommand("SELECT * FROM Person", this.SQLconn);
                    MySqlCommand cmdListMannschaften = new MySqlCommand("SELECT * from Mannschaft", this.SQLconn);
                    MySqlDataReader Reader = cmdListPersonen.ExecuteReader();

                    while (Reader.Read())
                    {
                        int id = (int)Reader["idPerson"];
                        string name = Reader["name"].ToString();
                        string vorname = Reader["vorname"].ToString();
                        SQLpersonen.Add(new Fussballspieler(name, vorname, 0 ,0 ,0));
                    }
                    Reader.Close();

                    Reader = cmdListMannschaften.ExecuteReader();

                    while (Reader.Read())
                    {
                        int id = (int)Reader["idMannschaft"];
                        string name = Reader["name"].ToString();
                        SQLmannschaft.Add(new Mannschaft(name));
                    }
                    Reader.Close();
                    this.SQLconn.Close();
                }
                else
                {
                    // Verbindung Fehlgeschlagen
                }

            }
            catch
            {
               
            }
        }
        */
    }
}