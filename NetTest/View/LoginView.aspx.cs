using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace NetTest.View
{
    public partial class LoginView : System.Web.UI.Page
    {
        Controller Verwalter = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int Back1 = 0;
            string backPW = "";
            string UserTXT = txtUser.Text;
            string PWTXT = txtPasswort.Text;
            string SelectUser = "select count(*) from Users where Username = '" + UserTXT +"'";
            try
            {
                string ConnectionString = "Server=95.111.235.48;Database=Mannschaftsverwaltung;Uid=Schule;Pwd=12345678;";
                MySqlConnection SQLLogin = new MySqlConnection(ConnectionString);
                SQLLogin.Open();
                MySqlCommand cmd1 = new MySqlCommand(SelectUser, SQLLogin);
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    Back1 = reader1.GetInt16(0);
                }
                if(Back1 == 1)
                {
                    // User Vorhanden
                    string SelectPW = "Select Passwort from Users where Username = '" + UserTXT + "'";
                    MySqlCommand cmd2 = new MySqlCommand(SelectPW, SQLLogin);
                    MySqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        backPW = reader1.GetString(0);
                    }
                    if(backPW == PWTXT)
                    {
                        //Passwort Richtig

                        if (this.Session["Verwalter"] != null)
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
                    else
                    {
                        txtInfo.Text = "Passwort Falsch!";
                    }
                } else
                {
                    txtInfo.Text = "User nicht gefunden!";
                }
            }
            catch
            {
                txtInfo.Text = "Verbindung zur Datenbank fehlgeschlagen";
            }
        }
    }
}