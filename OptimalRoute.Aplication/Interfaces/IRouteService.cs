using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalRoute.Aplication.Interfaces
{
    public interface IRouteService
    {
        List<string> CalculateShortestRoute(List<string> cities, List<(string from, string to, int time)> roads, string origin, string destination);
    }
}
