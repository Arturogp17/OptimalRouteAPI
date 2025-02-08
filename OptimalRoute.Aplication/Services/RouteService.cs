using OptimalRoute.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalRoute.Application.Services
{
    public class RouteService : IRouteService
    {
        public List<string> CalculateShortestRoute(List<string> cities, List<(string from, string to, int time)> roads, string origin, string destination)
        {
            // hacer Dijkstra
            return new List<string> { origin, destination }; 
        }
    }
}


