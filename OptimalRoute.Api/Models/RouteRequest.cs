namespace OptimalRoute.Api.Models
{
    public class RouteRequest
    {
        public List<string> Cities { get; set; } = new();
        public List<Road> Roads { get; set; } = new();
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
    }

    public class Road
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public int Time { get; set; }
    }
}