// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public abstract class Spieler : Person
    {
        #region Eigenschaften
        private string _Sportart;
        #endregion

        #region Accessoren/Modifier
        public string Sportart { get => _Sportart; set => _Sportart = value; }
        #endregion

        #region Konstruktoren

        public Spieler()
        {
            this.Sportart = "";
        }


        public Spieler(string value1, string value2) : base(value2)
        {
            this.Sportart = value1;
        }

        public Spieler(string value1, string value2, string value3) : base(value2, value3)
        {
            this.Sportart = value1;
        }

        public Spieler(Spieler v)
        {
            this.Sportart = v.Sportart;
        }

        #endregion

        #region Worker
        public override abstract int CompareByName(Person value);

        public void spieler()
        {
            Console.WriteLine("Spieler spielt");
        }

        #endregion
    }
}
