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
        void Verbindungsaufbau()
        {
            try
            {
                string ConnectionString = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
                SQL_Verbindung = new MySqlConnection(ConnectionString);
                SQL_Verbindung.Open();
            } catch
            {

            }        
        }

        void Testdaten()
        {
            string TestSelect = "Select * from PersonData";
            MySqlCommand cmd1 = new MySqlCommand(TestSelect, SQL_Verbindung);
            MySqlDataReader rdr = cmd1.ExecuteReader();

            for(int index = 0; index < rdr.FieldCount; index++)
            {
                string test = rdr.GetName(index);
            }
        }


        void Mannschaften_Laden()
        {

        }

        void Spieler_Laden()
        {

        }

        void Trainer_Laden()
        {

        }


    }
}