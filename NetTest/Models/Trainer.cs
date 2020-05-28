// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public class Trainer : Person
    {
        #region Eigenschaften
        private int _Siege;
        #endregion

        #region Accessoren/Modifier
        public int Siege { get => _Siege; set => _Siege = value; }
        #endregion

        #region Konstruktoren
        public Trainer() : base()
        {
            this.Siege = 1;
        }

        public Trainer(int v, string v2) : base(v2)
        {
            this.Siege = v;
        }

        public Trainer(Physiotherapeut v) : base(v)
        {
            this.Siege = v.Bewertung;
        }

        public Trainer(string v_name, string v_vorname, int v_Siege) : base(v_name, v_vorname) // HAUPTKONSTURKTOR mit Vorname
        {
            this.Siege = v_Siege;
        }
        #endregion

        #region Worker
        public void traineren()
        {
            Console.WriteLine("Er trainert die Manschaft");
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
            return "Trainer";
        }


        public override void GetPersonData(ref int ID, ref string Name, ref string vorname, ref DateTime Geburtsdatum, ref string string1, ref string string2, ref string string3)
        {
            ID = this.ID;
            Name = this.Name;
            vorname = this.Vorname;
            Geburtsdatum = this.Geburtsdatum;
            string1 = Convert.ToString(this.Siege);
        }
        #endregion
    }
}
