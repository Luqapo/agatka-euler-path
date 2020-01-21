using System;
using System.Collections.Generic;
using System.Linq;

namespace agatka
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> best = new List<string>();
            string bestJourney = "";
            Console.WriteLine("Creating Graph!");
            Graph myGraph = new Graph();
            myGraph.AddEdge("Gliwice", "Tarnowskie Góry");
            myGraph.AddEdge("Jelenia góra", "Zgorzelec");
            myGraph.AddEdge("Kedzierzyn Koźle", "Gliwice");
            myGraph.AddEdge("Kedzierzyn Koźle", "Opole");
            myGraph.AddEdge("Kłodzko", "Kamieniec Ząbkowicki");
            myGraph.AddEdge("Legnica", "Rudna Gwizdanów");
            myGraph.AddEdge("Legnica", "Zgorzelec");
            myGraph.AddEdge("Leszno", "Głogów");
            myGraph.AddEdge("Lubliniec", "Kluczbork");
            myGraph.AddEdge("Lubliniec", "Tarnowskie Góry");
            myGraph.AddEdge("Nysa", "Kamieniec Ząbkowicki");
            myGraph.AddEdge("Nysa", "Kedzierzyn Koźle");
            myGraph.AddEdge("Nysa", "Opole");
            myGraph.AddEdge("Opole", "Gliwice");
            myGraph.AddEdge("Rudna Gwizdanów", "Głogów");
            myGraph.AddEdge("Wałbrzych Główny", "Jelenia góra");
            myGraph.AddEdge("Wałbrzych Główny", "Kłodzko");
            myGraph.AddEdge("Wałbrzych Główny", "Wrocław Główny");
            myGraph.AddEdge("Wrocław Główny", "Kamieniec Ząbkowicki");
            myGraph.AddEdge("Wrocław Główny", "Kluczbork");
            myGraph.AddEdge("Wrocław Główny", "Legnica");
            myGraph.AddEdge("Wrocław Główny", "Leszno");
            myGraph.AddEdge("Wrocław Główny", "Opole");
            myGraph.AddEdge("Wrocław Główny", "Rudna Gwizdanów");
            for(int i = 0; i < 100; i++)
            {
                myGraph.PrintEulerUtil("Wrocław Główny");
                if(myGraph.visited.Count > best.Count)
                {
                    best = myGraph.visited.ToList();
                    bestJourney = myGraph.journey;
                }
                myGraph.visited.Clear();
                myGraph.last = "start";
                myGraph.journey = "";
            }
            Console.WriteLine($"Visited length {best.Count}");
            Console.WriteLine(bestJourney);
        }
    }
}
