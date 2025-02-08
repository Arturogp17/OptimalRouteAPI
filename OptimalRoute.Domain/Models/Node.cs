using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalRoute.Domain.Models
{
    public class Node
    {
        public string Name { get; }
        public List<Edge> Edges { get; }

        public Node(string name)
        {
            Name = name;
            Edges = new List<Edge>();
        }

        // Añadir una conexión (camino) a otro nodo
        public void AddEdge(Node to, int time)
        {
            Edges.Add(new Edge(this, to, time));
        }
    }
}
