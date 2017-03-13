using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutenPlaner
{
    public class Kante
    {
        private Knoten v, w;
        public int laenge;

        public Kante(Knoten pV, Knoten pW, int pLaenge)
        {
            v = pV;
            w = pW;
            laenge = pLaenge;
        }

        public Knoten getV()
        {
            return v;
        }

        public Knoten getW()
        {
            return w;
        }
    }
}
