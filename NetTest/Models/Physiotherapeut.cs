// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public class Physiotherapeut : Person
    {
        #region Eigenschaften
        private int _Bewertung; // in Prozent!
        #endregion

        #region Accessoren/Modifier
        public int Bewertung { get => _Bewertung; set => _Bewertung = value; }
        #endregion

        #region Konstruktoren

        public Physiotherapeut() : base()
        {
            this.Bewertung = 1;
        }

        public Physiotherapeut(int v, string v2) : base(v2)
        {
            this.Bewertung = v;
        }

        public Physiotherapeut(Physiotherapeut v) : base(v)
        {
            this.Bewertung = v.Bewertung;
        }

        public Physiotherapeut(string v_name, string v_vorname, int Bewertung) : base(v_name, v_vorname)
        {
            this.Bewertung = Bewertung;
        }
        #endregion

        #region Worker

        public void zuhoeren()
        {
            Console.WriteLine("Physiotherapeut hört zu");
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
            return "Physiotherapeut";
        }

        public override void GetPersonData(ref int ID, ref string Name, ref string vorname, ref DateTime Geburtsdatum, ref string string1, ref string string2, ref string string3)
        {
            ID = this.ID;
            Name = this.Name;
            vorname = this.Vorname;
            Geburtsdatum = this.Geburtsdatum;
            string1 = Convert.ToString(this.Bewertung);
        }
        #endregion
    }
}
