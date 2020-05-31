using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTest.View
{
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        Controller Verwalter = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            // autopostback einfügen
            if(!this.IsPostBack)
            {
                // Erstes mal seite Laden!
                Mannschaften_Laden();
                PersonenVerfügbar();
                ListPersonen.Font.Size = 15;
                ListVerfügbar.Font.Size = 15;
                listMannschaften.Font.Size = 15;
            } else
            {

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

        public void Mannschaften_Laden()
        {
            listMannschaften.Items.Clear();
            int count = Verwalter.Mannschaften.Count();

            for(int index = 0; index < count; index++)
            {
                listMannschaften.Items.Add(Verwalter.Mannschaften[index].Name);
            }
            if(listMannschaften.SelectedItem == null)
            {
                listMannschaften.SelectedIndex = Verwalter.SelectedMannschaft;
            }
            else
            {
                listMannschaften.SelectedIndex = Verwalter.SelectedMannschaft;
            }
            PersonenListe(Verwalter.Mannschaften.FindIndex(a => a.Name == listMannschaften.SelectedItem.Text));
       }

        public void PersonenListe(int varMS)
        {
            List <Person> MSpersonen = new List<Person>();
            MSpersonen = Verwalter.Mannschaften[varMS].Personen.ToList();
            ListPersonen.Items.Clear();

            CompareLists(ref MSpersonen); // Vergleich die Manschaftsliste und Personenliste | Wenn person gelöscht wurde wird sie auch im der Mannschaft gelöscht
            Verwalter.Mannschaften[varMS].Personen = MSpersonen;

            for (int i = 0; i < MSpersonen.Count(); i++)
            {
                ListPersonen.Items.Add(MSpersonen[i].Vorname + " " + MSpersonen[i].Name);
            }
        }

        protected void listMannschaften_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verwalter.SelectedMannschaft = listMannschaften.SelectedIndex;
            PersonenListe(Verwalter.Mannschaften.FindIndex(a => a.Name == listMannschaften.SelectedItem.Text));
            PersonenVerfügbar();
        }

        void PersonenVerfügbar()
        {
            ListVerfügbar.Items.Clear();
            for(int i = 0; i < Verwalter.Personen.Count(); i++)
            {
                if (!ListPersonen.Items.Cast<ListItem>().Any(x => x.Text == Verwalter.Personen[i].Vorname + " " + Verwalter.Personen[i].Name))
                {
                    ListVerfügbar.Items.Add(Verwalter.Personen[i].Vorname + " " + Verwalter.Personen[i].Name);
                } else
                {

                }
            }

        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            Verwalter.SelectedMannschaft = listMannschaften.SelectedIndex;
            if (ListPersonen.SelectedItem == null)
            {
                ListPersonen.SelectedIndex = 0;
            }
            string[] array = ListPersonen.SelectedItem.Text.Split(' ');
            this.Verwalter.Mannschaften.Find(x => x.Name == listMannschaften.SelectedItem.Text).Personen.Remove(this.Verwalter.Mannschaften.Find(x => x.Name == listMannschaften.SelectedItem.Text).Personen.Find(x => x.Vorname == array[0] && x.Name == array[1]));
            Mannschaften_Laden();
            PersonenVerfügbar();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Verwalter.SelectedMannschaft = listMannschaften.SelectedIndex;
            if(ListVerfügbar.SelectedItem == null)
            {
                ListVerfügbar.SelectedIndex = 0;
            }
            string[] array = ListVerfügbar.SelectedItem.Text.Split(' ');
            this.Verwalter.Mannschaften.Find(x => x.Name == listMannschaften.SelectedItem.Text).Personen.Add(this.Verwalter.Personen.Find(x => x.Vorname == array[0] && x.Name == array[1]));
            Mannschaften_Laden();
            PersonenVerfügbar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Name = this.Request.Form["ctl00$MainContent$txtName"];
            this.Verwalter.Mannschaften.Add(new Mannschaft(Name));
            Mannschaften_Laden();
        }

        protected void CompareLists(ref List<Person> ListCompare)
        {
            var PersonenUngleich = ListCompare.Except(Verwalter.Personen).ToList();
            if(PersonenUngleich.Count() > 0)
            {
                for(int index = 0; index < PersonenUngleich.Count(); index++)
                {
                    ListCompare.Remove(PersonenUngleich[index]);
                }
                infoLabel.Visible = true;
                infoLabel.Text = "Person " + PersonenUngleich[0].Name + " wurde aus der Mannschaft entfernt!";
            }
            else
            {

            }
        }
    }
}