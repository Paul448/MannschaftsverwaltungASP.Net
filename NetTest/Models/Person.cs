// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetTest
{
    public abstract class Person
    {
        #region Eigenschaften
        private int _ID;
        private string _Name;
        private string _vorname;
        private DateTime _Geburtsdatum;
        private static int Count;
        #endregion

        #region Accessoren/Modifier
        public string Name { get => _Name; set => _Name = value; }
        public DateTime Geburtsdatum { get => _Geburtsdatum; set => _Geburtsdatum = value; }
        public string Vorname { get => _vorname; set => _vorname = value; }
        public int ID { get => _ID; set => _ID = value; }
        #endregion

        #region Konstruktoren
        public Person()
        {
            this.Name = "?---?";
        }

        public Person(string v)
        {
            this.Name = v;
            this.Geburtsdatum = new DateTime(2000, 1, 1); 
            Interlocked.Increment(ref Count);
            this.ID = Count;
        }

        public Person(string v_name, string v_vorname)
        {
            this.Geburtsdatum = new DateTime(2000, 1, 1);
            this.Name = v_name;
            this.Vorname = v_vorname;
            Interlocked.Increment(ref Count);
            this.ID = Count;
        }

        public Person(Person v)
        {
            this.Geburtsdatum = new DateTime(2000, 1, 1);
            this.Name = v.Name;
        }

        #endregion

        #region Worker

        public void reden()
        {
            Console.WriteLine("Person redet");
        }

        public abstract int CompareByName(Person value);

        public abstract string GetPosition();

        public abstract void GetPersonData(ref int ID, ref string Name, ref string vorname, ref DateTime Geburtsdatum, ref string string1, ref string string2, ref string string3);

        #endregion
    }
}
