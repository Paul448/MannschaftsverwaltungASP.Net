using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetTest
{
    public class Turnier
    {
        #region Eigenschaften
        private string _TurnierName;
        private string _T_Status;
        private string _T_Spiele;
        private string _T_Fertige_Spiele;

        #endregion

        #region Accesoren/Modififier
        public string TurnierName { get => _TurnierName; set => _TurnierName = value; }
        public string T_Status { get => _T_Status; set => _T_Status = value; }
        public string T_Spiele { get => _T_Spiele; set => _T_Spiele = value; }
        public string T_Fertige_Spiele { get => _T_Fertige_Spiele; set => _T_Fertige_Spiele = value; }
        #endregion

        #region Konstruktoren 

        public Turnier(string Name)
        {
            this.TurnierName = Name;
        }

        #endregion

        #region Worker

        #endregion
    }
}