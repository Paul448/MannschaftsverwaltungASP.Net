// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public class Handballspieler : Spieler
    {
        #region Eigenschaften
        private int _Hohsprung;
        private int _Siege;
        #endregion

        #region Accessoren/Modifier
        public int Hohsprung { get => _Hohsprung; set => _Hohsprung = value; }
        public int Siege { get => _Siege; set => _Siege = value; }
        #endregion

        #region Konstruktoren
        public Handballspieler() : base("Handball", "NO-NAME")
        {
            this.Hohsprung = 1;
        }


        public Handballspieler(string v_name, string v_vorname, int v_siege) : base("Handball", v_name, v_vorname) // HAUPTKONSTURKTOR mit Vorname
        {
            this.Siege = v_siege;
        }

        public Handballspieler(Handballspieler v) : base(v.Sportart, v.Name)
        {
            this.Hohsprung = v.Hohsprung;
        }

        public override void GetPersonData(ref int ID, ref string Name, ref string vorname, ref DateTime Geburtsdatum, ref string string1, ref string string2, ref string string3)
        {
            ID = this.ID;
            Name = this.Name;
            vorname = this.Vorname;
            Geburtsdatum = this.Geburtsdatum;
            string1 = Convert.ToString(this.Hohsprung);
            string2 = Convert.ToString(this.Siege);
        }
        #endregion

        #region Worker
        public void passen()
        {
            Console.WriteLine("Er passt dein Ball");
        }

        public override int CompareByName(Person value)
        {
            if (this.Name[0] > value.Name[0])
            {
                return 1;
            }
            else if (this.Name[0] == value.Name[0])
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public override string GetPosition()
        {
            return this.Sportart + "spieler";
        }
        #endregion
    }
}
