// Autor:               Paul Jansen
// Klasse:              AI118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTest
{
    public class Mannschaft
    {
        #region Eigenschaften
        private string _name;
        private List<Person> _Personen = new List<Person>();
        #endregion

        #region Modifier/Accesoren
        public string Name { get => _name; set => _name = value; }
        public List<Person> Personen { get => _Personen; set => _Personen = value; }
        #endregion

        #region Konstruktoren
        public Mannschaft()
        {
            this.Name = "-";
        }

        public Mannschaft(string Value1)
        {
            this.Name = Value1;
        }

        public Mannschaft(string Value1, List<Person> Value2)
        {
            this.Name = Value1;
            this.Personen = Value2;
        }
        #endregion

        #region Worker

        public void Sortieren()
        {
            Console.WriteLine("");
            Console.WriteLine(System.DateTime.Now + ":  Wählen sie einen Sortieralgorithmus!");
            Console.WriteLine(System.DateTime.Now + ":  '1' [BubbleSort] Aufwärts");
            Console.WriteLine(System.DateTime.Now + ":  '2' [BubbleSort] Abwärts");
            Console.WriteLine(System.DateTime.Now + ":  '3' [InsertionSort] Aufwärts");
            Console.WriteLine(System.DateTime.Now + ":  '4' [InsertionSort] Abwärts");
            string output = Console.ReadLine();

            if (output == "1")
            {
                Sort(true);
            }
            else if (output == "2")
            {
                Sort(false);
            }
            else if (output == "3")
            {
                //
            }
            else if (output == "4")
            {
                //
            }
            else
            {
                Sort(true);
            }
        }

        public void Sort(bool Aufwärts) // True = Aufwärts sortieren
        {
            Person c;
            if (Aufwärts == true) // Bubblesort Aufwärts
            {
                for (int b = 1; b < Personen.Count; b++)
                {
                    for (int i = 0; i < (Personen.Count - 1); i++)
                    {
                        if (Personen[i].CompareByName(Personen[i + 1]) == 1)
                        {
                            c = Personen[i];
                            Personen[i] = Personen[i + 1];
                            Personen[i + 1] = c;
                        }
                        else
                        {

                        }
                    }
                }
            } else // Bubblesort Abwärts
            {
                for (int b = 1; b < Personen.Count; b++)
                {
                    for (int i = 0; i < (Personen.Count - 1); i++)
                    {
                        if (Personen[i].CompareByName(Personen[i + 1]) == -1)
                        {
                            c = Personen[i + 1];
                            Personen[i + 1] = Personen[i];
                            Personen[i] = c;
                        }
                    }
                }
            }
        }

        public void IntersectSort()
        {
            Person c;
            for(int i = 0;i < (Personen.Count() - 1); i++)
            {

                while(Personen[i].CompareByName(Personen[i+1]) == 1)
                {
                    c = Personen[i++];
                    Personen[i++] = Personen[i];
                    Personen[i] = c;

                }
            }
        }


        public void AusgabeListe()
        {
                WriteTable("NAME:", "POSITION:", "BEMERKUNG:");
                for (int i = 0; i < Personen.Count; i++)
                {
                    WriteTable(Personen[i].Name, Personen[i].GetPosition(), "---");
                    //Console.WriteLine("   Name: " + var.Personen[i].Name + "  |  Position: " + var.Personen[i].GetPosition());
                }
        }

        void WriteTable(string var1, string var2, string var3)
        {
            Console.WriteLine("    {0,-10} {1,-20} {2,-10}", var1, var2, var3);
        }
        #endregion
    }
}
