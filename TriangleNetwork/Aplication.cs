using System;
using TriangleNetwork.Calculators;
using TriangleNetwork.Models;

//metoda WriteTriangles() vypíše počet trojůhelníku a jejich vrcholy

namespace TriangleNetwork
{
    public class Aplication : IAplication
    {
        ICalculator iCalculator;
        public Aplication(ICalculator iCalculator)
        {
            this.iCalculator = iCalculator;
        }
        public void WriteTriangles()
        {
            Console.WriteLine($"Počet troujůhelníku: {iCalculator.GetTriangles().Count}");
            Console.WriteLine($"               A                             B                                C");
            foreach (Triangle triangle in iCalculator.GetTriangles())
            {
                Console.WriteLine($"(X:{triangle.TopA.X} Y:{triangle.TopA.Y})   (X:{triangle.TopB.X} Y:{triangle.TopB.Y})   (X:{triangle.TopC.X} Y:{triangle.TopC.Y})");
            }
            Console.ReadKey();
        }
    }
}
