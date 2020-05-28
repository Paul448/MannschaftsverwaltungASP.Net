// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public class Fussballspieler : Spieler
    {
        #region Eigenschaften
        private int _Tore;
        private int _siege;
        private int _nummer;
        #endregion

        #region Accessoren/Modifier
        public int Tore { get => _Tore; set => _Tore= value; }
        public int Siege { get => _siege; set => _siege = value; }
        public int Nummer { get => _nummer; set => _nummer = value; }
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base("Fussball", "NO-NAME")
        {
            this.Tore = 1;
        }

        public Fussballspieler(string v_name, int v_tore, int v_siege, int v_nummer) : base("Fussball", v_name) // HAUPTKONSTURKTOR
        {
            this.Tore = v_tore;
            this.Siege = v_siege;
            this.Nummer = v_nummer;
        }

        public Fussballspieler(string v_name, string v_vorname, int v_tore, int v_siege, int v_nummer) : base("Fussball", v_name, v_vorname) // HAUPTKONSTURKTOR mit Vorname
        {
            this.Tore = v_tore;
            this.Siege = v_siege;
            this.Nummer = v_nummer;
        }

        public Fussballspieler(int v, string v2) : base("Fussball", v2)
        {
            this.Tore = v;
        }

        public Fussballspieler(Fussballspieler v) : base(v)
        {
            this.Tore = v.Tore;
        }
        #endregion

        #region Worker
        public virtual void passen()
        {
            Console.WriteLine("Er passt dein Ball");
        }

        public override int CompareByName(Person value)
        {
            if(this.Name[0] > value.Name[0])
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
            string1 =  Convert.ToString(this.Tore);
            string2 = Convert.ToString(this.Siege);
            string3 = Convert.ToString(this.Nummer);
        }
        #endregion
    }
}
