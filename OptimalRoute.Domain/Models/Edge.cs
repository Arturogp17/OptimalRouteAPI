namespace OptimalRoute.Domain.Models
{
    public class Edge
    {
        public Node From { get; }
        public Node To { get; }
        public int Time { get; }

        public Edge(Node from, Node to, int time)
        {
            From = from;
            To = to;
            Time = time;
        }
    }
}
