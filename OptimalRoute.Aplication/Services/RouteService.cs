using OptimalRoute.Aplication.Interfaces;
using OptimalRoute.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace OptimalRoute.Application.Services
{
    public class RouteService : IRouteService
    {
        public (List<string> route, int totalTime) CalculateShortestRoute(List<string> cities, List<(string from, string to, int time)> roads, string origin, string destination)
        {
            // Crear el grafo y agregar los nodos
            Graph graph = new Graph();
            foreach (var city in cities)
            {
                graph.AddNode(city);
            }

            // Agregar las conexiones (edges) al grafo
            foreach (var road in roads)
            {
                graph.AddEdge(road.from, road.to, road.time);
            }

            // Inicializar los datos para Dijkstra
            var shortestTimes = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node?>();
            var unvisitedNodes = new HashSet<Node>(graph.Nodes.Values);

            foreach (var node in graph.Nodes.Values)
            {
                shortestTimes[node] = int.MaxValue;
                previousNodes[node] = null;
            }
            shortestTimes[graph.GetNode(origin)] = 0;

            while (unvisitedNodes.Count > 0)
            {
                // Seleccionar el nodo con menor tiempo conocido
                var currentNode = unvisitedNodes.OrderBy(node => shortestTimes[node]).First();
                unvisitedNodes.Remove(currentNode);

                // Si llegamos al destino, terminamos
                if (currentNode.Name == destination)
                    break;

                // Revisar los vecinos (edges)
                foreach (var edge in currentNode.Edges)
                {
                    if (!unvisitedNodes.Contains(edge.To)) continue;

                    int newTime = shortestTimes[currentNode] + edge.Time;
                    if (newTime < shortestTimes[edge.To])
                    {
                        shortestTimes[edge.To] = newTime;
                        previousNodes[edge.To] = currentNode;
                    }
                }
            }

            // Reconstruir la ruta más corta
            var route = new List<string>();
            var current = graph.GetNode(destination);
            int totalTime = shortestTimes[current];

            while (current != null)
            {
                route.Add(current.Name);
                current = previousNodes[current];
            }

            route.Reverse();

            return (route, totalTime);
        }
    }
}
