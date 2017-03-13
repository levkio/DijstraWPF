using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutenPlaner
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph streckennetz = new Graph();
            streckennetz.addKnoten(new Knoten("Lingen"));
            streckennetz.addKnoten(new Knoten("Rheine"));
            streckennetz.addKnoten(new Knoten("Meppen"));
            streckennetz.addKnoten(new Knoten("Groningen"));
            streckennetz.addKnoten(new Knoten("Hengelo"));
            streckennetz.addKnoten(new Knoten("Leer"));
            streckennetz.addKnoten(new Knoten("Osnabrück"));
            streckennetz.addKante("Lingen", "Rheine", 49);
            streckennetz.addKante("Lingen", "Meppen", 10);
            streckennetz.addKante("Meppen", "Leer", 10);
            streckennetz.addKante("Leer", "Groningen", 10);
            streckennetz.addKante("Groningen", "Hengelo", 10);
            streckennetz.addKante("Hengelo", "Rheine", 10);
            streckennetz.addKante("Rheine", "Osnabrück", 15);

            streckennetz.giefMirDat();

            dijkstra djk = new dijkstra(streckennetz, "Lingen", "Osnabrück");
            foreach (string ausg in djk.doDijkstra())
            {
                Console.WriteLine(ausg);
            }
            
            Console.ReadLine();
        }
    }
}
