using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutenPlaner
{
    public class dijkstra
    {
        Dictionary<string, int> abstand;
        Dictionary<string, string> vorgaenger;
        private string startKnoten, zielKnoten;
        List<string> q;
        Graph g;

        public dijkstra(Graph graph, string pStartKnoten, string pZielKnoten)
        {
            g = graph;
            abstand = new Dictionary<string, int>();
            vorgaenger = new Dictionary<string, string>();
            q = new List<string>();
            startKnoten = pStartKnoten;
            zielKnoten = pZielKnoten; 
        }

        public List<string> doDijkstra()
        {
            initialisierung(g, startKnoten);
            while (q.Count > 0)
            {
                string u = "";
                int geringste = int.MaxValue;
                foreach (string zwischen in q)
                {
                    if (geringste > abstand[zwischen])
                    {
                        u = zwischen;
                        geringste = abstand[zwischen];
                    }
                }
                q.Remove(u);

                if (u == zielKnoten)
                {
                    return erstelleKuerzestenWeg();
                }


                foreach (Kante kant in g.kantens)
                {
                    if (kant.getV().getSetBezeichung == u)
                    {
                        if (q.Contains(kant.getW().getSetBezeichung))
                        {
                            distanz_update(u, kant.getW().getSetBezeichung);
                        }
                    }
                    else if (kant.getW().getSetBezeichung == u)
                    {
                        if (q.Contains(kant.getV().getSetBezeichung))
                        {
                            distanz_update(u, kant.getV().getSetBezeichung);
                        }
                    }
                }
            }
            return erstelleKuerzestenWeg();
        }

        private void initialisierung(Graph graph, string startKnoten)
        {
            foreach (Knoten knot in graph.knotens)
            {
                abstand.Add(knot.getSetBezeichung, int.MaxValue);
                vorgaenger.Add(knot.getSetBezeichung, "");
                q.Add(knot.getSetBezeichung);
            }
            abstand[startKnoten] = 0;

        }

        private void distanz_update(string u, string v)
        {
            int alternativ = abstand[u] + abstand_zwischen(u, v);
            if (alternativ < abstand[v])
            {
                abstand[v] = alternativ;
                vorgaenger[v] = u;
            }
        }

        private int abstand_zwischen(string u, string v)
        {
            foreach (Kante k in g.getKanten())
            {
                if ((k.getV().getSetBezeichung == u || k.getW().getSetBezeichung == u) && (k.getV().getSetBezeichung == v || k.getW().getSetBezeichung == v))
                {
                    return k.laenge;
                }
            }
            return 1;
        }

        private List<string> erstelleKuerzestenWeg()
        {
            List<string> weg = new List<string>();
            weg.Add(zielKnoten);
            string u = zielKnoten;

            while (vorgaenger[u] != "")
            {
                u = vorgaenger[u];
                weg.Add(u);
            }

            return weg;
        }

    }
}
