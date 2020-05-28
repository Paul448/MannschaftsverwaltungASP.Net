// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public class Tennisspieler : Spieler
    {
        #region Eigenschaften
        private int _Treffer;
        private int _Siege;
        #endregion

        #region Modifier/Accesoren
        public int Treffer { get => _Treffer; set => _Treffer = value; }
        public int Siege { get => _Siege; set => _Siege = value; }
        #endregion

        #region Konstruktoren
        public Tennisspieler(string v_name, string v_vorname, int v_treffer, int v_siege) : base("Tennis", v_name, v_vorname) // HAUPTKONSTURKTOR mit Vorname
        {
            this.Treffer = v_treffer;
            this.Siege = v_siege;
        }

        public Tennisspieler() : base("Tennis", "NONAME")
        {
            this.Treffer = 0;
        }

        public Tennisspieler(Tennisspieler var) : base("Tennis", var.Name)
        {

        }
        #endregion

        #region Worker
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

        public override void GetPersonData(ref int ID, ref string Name, ref string vorname, ref DateTime Geburtsdatum, ref string string1, ref string string2, ref string string3)
        {
            ID = this.ID;
            Name = this.Name;
            vorname = this.Vorname;
            Geburtsdatum = this.Geburtsdatum;
            string1 = Convert.ToString(this.Siege);
            string2 = Convert.ToString(this.Treffer);
        }
        #endregion
    }
}
