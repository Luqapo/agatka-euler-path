using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace agatka
{
    public class Graph

    {

        public Dictionary<string, List<string>> childNodes;
        public List<string> visited;
        public string last = "start";
        public string journey = "";
        public Graph()
        {
            childNodes = new Dictionary<string, List<string>>();
            visited = new List<string>();
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
            childNodes.Add(u, new List<string>());
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
                List<string> verticec = childNodes[k];
                foreach (string v in verticec)
                {
                    Console.WriteLine($"     Połączenie: {v}");
                }
            }
        }

        private int dsfCount(string n, Dictionary<string, bool> isVisited)
        {
            isVisited[n] = true;
            int count = 1;
            foreach(string v in childNodes[n])
            {
                Boolean inVisited = visited.Contains($"{n}{v}");
                Boolean inVisited2 = visited.Contains($"{v}{n}");
                if(isVisited[v] && (!inVisited && !inVisited2))
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
            if(childNodes[a].Count == 1)
            {
                return true;
            }

            Dictionary<string, bool> isVisited = getVisited();
            int count1 = dsfCount(a, isVisited);

            visited.Add($"{a}{b}");
            isVisited = getVisited();
            int count2 = dsfCount(b, isVisited);

            visited.Remove($"{a}{b}");
            Boolean valid = (count1 > count2) ? false : true;
            return valid;
        }

        public void PrintEulerUtil(string start)
        {
            List<string> toVisit = childNodes[start].ToList();
            do
            {
                var random = new Random();
                int index = random.Next(toVisit.Count);
                string to = toVisit[index];
                toVisit.Remove(to);
                if(start != last && last != "start") break;
                Boolean inVisited = visited.Contains($"{start}{to}");
                Boolean inVisited2 = visited.Contains($"{to}{start}");
                if(isValidNextEdge(start, to) && (!inVisited && !inVisited2))
                {
                    visited.Add($"{start}{to}");
                    journey = $"{journey} - {start} > {to}";
                    last = to;
                    PrintEulerUtil(to);
                }
            } while (toVisit.Count > 0);
        }

        public void PrintVisited()
        {
            foreach (string edge in visited)
            {
                Console.WriteLine($"Visited - {edge}");
            }
        }
    }
}