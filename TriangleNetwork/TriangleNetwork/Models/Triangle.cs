//metoda CreateTriangle() vrátí instanci trídy Triangle.

namespace TriangleNetwork.Models
{
    public class Triangle : ITriangle
    {
        public Point TopA { get; set; }
        public Point TopB { get; set; }
        public Point TopC { get; set; }
               
        public Triangle CreateTriangle()
        {
            return new Triangle();
        }
    }
}

