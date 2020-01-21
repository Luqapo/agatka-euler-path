using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace agatka
{
    public class Graph

    {

        public Dictionary<string, ArrayList> childNodes;
        public Graph()
        {
            this.childNodes = new Dictionary<string, ArrayList>();
        }

        public int Size
        {
            get
            {
                List<string> keysList = new List<string>(this.childNodes.Keys);
                return keysList.Count;
            }
        }

        public void AddVerice(string u)
        {
            childNodes.Add(u, new ArrayList());
        }

        public void RemoveVerice(string u)
        {
            childNodes.Remove(u);
        }

        public bool HasEdge(string u)

        {
            bool hasEdge = this.childNodes.ContainsKey(u);
            return hasEdge;
        }

        public void AddEdge(string a, string b)
        {
            if(!childNodes.ContainsKey(a)) {
                AddVerice(a);
            }
            if(!childNodes.ContainsKey(b)) {
                AddVerice(b);
            }
            childNodes[a].Add(b);
            childNodes[b].Add(a);
        }

        public void RemoveEdge(string a, string b)
        {
            Console.WriteLine($"remove from {a} to {b}");
            childNodes[a].Remove(b);
            childNodes[b].Remove(a);
        }

        public void PrintGraph()
        {
            List<string> keys = new List<string>(childNodes.Keys);
            foreach (string k in keys)
            {
                Console.WriteLine($"Miasto: {k}");
                ArrayList verticec = childNodes[k];
                foreach (string v in verticec)
                {
                    Console.WriteLine($"     Połączenie: {v}");
                }
            }
        }

        private int dsfCount(string n, Dictionary<string, bool> isVisited)
        {
            Console.WriteLine($"DFS Count {n}");
            isVisited[n] = true;
            int count = 1;
            foreach(string v in childNodes[n])
            {
                if(isVisited[v] == false)
                {
                    count = dsfCount(v, isVisited);
                }
            }
            return count;
        }

        private Dictionary<string, bool> getVisited()
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            List<string> keys = new List<string>(childNodes.Keys);
            foreach (string k in keys)
            {
                visited[k] = false;
            }
            return visited;
        }

        private bool isValidNextEdge(string a, string b)
        {
            Console.WriteLine($"is valid from {a} to {b}");
            if(childNodes[a].Count == 1)
            {
                return true;
            }

            Dictionary<string, bool> isVisited = getVisited();
            int count1 = dsfCount(a, isVisited);

            RemoveEdge(a, b);
            isVisited = getVisited();
            int count2 = dsfCount(b, isVisited);

            AddEdge(a, b);
            Boolean valid = (count1 > count2) ? false : true;
            Console.WriteLine($"? valid - {valid}");
            return valid;
        }

        public void PrintEulerUtil(string start)
        {
            foreach (string to in childNodes[start])
            {
                Console.WriteLine($"to visit - {to}");
                if(isValidNextEdge(start, to))
                {
                    Console.WriteLine($"z: {start} do: {to}");
                    RemoveEdge(start, to);
                    PrintEulerUtil(to);
                    // toVisit.Remove(to);
                }
                Console.WriteLine($"end - {to}");
                PrintGraph();
                // MakeGraph();
            }
        }

        private void MakeGraph()
        {
            List<string> keys = new List<string>(childNodes.Keys);
            foreach (string v in keys)
            {
                RemoveVerice(v);
            }
            AddEdge("Gliwice", "Tarnowskie Góry");
            AddEdge("Jelenia góra", "Zgorzelec");
            AddEdge("Kedzierzyn Koźle", "Gliwice");
            AddEdge("Kedzierzyn Koźle", "Opole");
            AddEdge("Kłodzko", "Kamieniec Ząbkowicki");
            AddEdge("Legnica", "Rudna Gwizdanów");
            AddEdge("Legnica", "Zgorzelec");
            AddEdge("Leszno", "Głogów");
            AddEdge("Lubliniec", "Kluczbork");
            AddEdge("Lubliniec", "Tarnowskie Góry");
            AddEdge("Nysa", "Kamieniec Ząbkowicki");
            AddEdge("Nysa", "Kedzierzyn Koźle");
            AddEdge("Nysa", "Opole");
            AddEdge("Opole", "Gliwice");
            AddEdge("Rudna Gwizdanów", "Głogów");
            AddEdge("Wałbrzych Główny", "Jelenia góra");
            AddEdge("Wałbrzych Główny", "Kłodzko");
            AddEdge("Wałbrzych Główny", "Wrocław Główny");
            AddEdge("Wrocław Główny", "Kamieniec Ząbkowicki");
            AddEdge("Wrocław Główny", "Kluczbork");
            AddEdge("Wrocław Główny", "Legnica");
            AddEdge("Wrocław Główny", "Leszno");
            AddEdge("Wrocław Główny", "Opole");
            AddEdge("Wrocław Główny", "Rudna Gwizdanów");
        }

    }
}