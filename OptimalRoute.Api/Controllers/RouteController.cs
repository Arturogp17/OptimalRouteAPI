using Microsoft.AspNetCore.Mvc;
using OptimalRoute.Api.Models;
using OptimalRoute.Aplication.Interfaces;

namespace OptimalRoute.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpPost("optimal-route")]
        public IActionResult GetOptimalRoute([FromBody] RouteRequest request)
        {
            var roadsTuple = request.Roads
                .Select(r => (r.From, r.To, r.Time))
                .ToList();

            var result = _routeService.CalculateShortestRoute(
                request.Cities,
                roadsTuple,
                request.Origin,
                request.Destination
            );

            return Ok(new { route = result });
        }
    }
}
