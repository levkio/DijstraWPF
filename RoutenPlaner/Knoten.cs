using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutenPlaner
{
    public class Knoten
    {
        public string getSetBezeichung
        {
            set { bezeichnung = value; }
            get { return bezeichnung; }
        }

        private string bezeichnung;

        public Knoten()
        {
            bezeichnung = "Lingen";
        }

        public Knoten(string pBezeichnung)
        {
            bezeichnung = pBezeichnung;
        }

        public string getBezeichnung()
        {
            return bezeichnung;
        }

        public void setBezeichnung(string pBezeichnung)
        {
            bezeichnung = pBezeichnung;
        }
    }
}
