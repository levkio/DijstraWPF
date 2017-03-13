using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutenPlaner
{
    public class Graph
    {
        public List<Knoten> knotens;
        public List<Kante> kantens;

        public Graph()
        {
            knotens = new List<Knoten>();
            kantens = new List<Kante>();
        }

        public void addKnoten(Knoten pKnoten)
        {
            knotens.Add(pKnoten);
        }

        public void addKante(string v, string w, int entfernung)
        {
            Knoten vTemp = null, wTemp = null;

            foreach (Knoten k in knotens)
            {
                if (k.getBezeichnung().Equals(v))
                {
                    vTemp = k;
                }
                if (k.getBezeichnung().Equals(w))
                {
                    wTemp = k;
                }
            }

            if (vTemp != null && wTemp != null)
            {
                kantens.Add(new Kante(vTemp, wTemp, entfernung));
            }
        }

        public void giefMirDat()
        {
            Console.WriteLine("graph G {");
            foreach (Kante kante in kantens)
            {
                Console.WriteLine("\"" + kante.getV().getBezeichnung() + "\" -- \"" + kante.getW().getBezeichnung() + "\"");
            }
            Console.WriteLine("}");
        }

        public List<Kante> getKanten()
        {
            return kantens;
        }
    }
}
