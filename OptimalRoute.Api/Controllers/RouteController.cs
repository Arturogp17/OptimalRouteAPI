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
            try
            {
                if (request?.Cities == null || request.Roads == null ||
                    string.IsNullOrEmpty(request.Origin) || string.IsNullOrEmpty(request.Destination) || request == null)
                {
                    return BadRequest(new
                    {
                        statusCode = 400,
                        message = "Invalid request: Cities, roads, origin, and destination are required."
                    });
                }
                var roadsTuple = request.Roads
                    .Select(r => (r.From, r.To, r.Time))
                    .ToList();

                // Llamar al servicio y obtener tanto la ruta como el tiempo total
                var (route, totalTime) = _routeService.CalculateShortestRoute(
                    request.Cities,
                    roadsTuple,
                    request.Origin,
                    request.Destination
                );

                if (route.Count == 0)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "No valid route found between the specified cities."
                    });
                }


                return Ok(new
                {
                    route,
                    totalTime
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    statusCode = 500,
                    message = "An unexpected error occurred.",
                    details = ex.Message // just for dev, delete on PROD
                });
            }
            
        }
    }
}
