namespace OptimalRoute.Domain.Models
{
    public class Graph
    {
        public Dictionary<string, Node> Nodes { get; }

        public Graph()
        {
            Nodes = new Dictionary<string, Node>();
        }

        // Agregar un nodo (ciudad)
        public void AddNode(string city)
        {
            if (!Nodes.ContainsKey(city))
            {
                Nodes[city] = new Node(city);
            }
        }

        // Agregar una conexión entre dos nodos
        public void AddEdge(string from, string to, int time)
        {
            var fromNode = Nodes[from];
            var toNode = Nodes[to];

            fromNode.AddEdge(toNode, time);
            toNode.AddEdge(fromNode, time); // Grafo no dirigido (bidireccional)
        }

        // Obtener un nodo por nombre
        public Node GetNode(string name) => Nodes[name];
    }
}
