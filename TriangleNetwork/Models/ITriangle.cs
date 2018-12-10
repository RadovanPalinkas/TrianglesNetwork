namespace TriangleNetwork.Models
{
    public interface ITriangle
    {
        Point TopA { get; set; }
        Point TopB { get; set; }
        Point TopC { get; set; }

        Triangle CreateTriangle();
    }
}