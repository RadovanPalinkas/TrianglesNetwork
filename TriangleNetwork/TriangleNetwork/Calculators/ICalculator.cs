using System.Collections.Generic;
using TriangleNetwork.Models;

namespace TriangleNetwork.Calculators
{
    public interface ICalculator
    {
        List<ITriangle> GetTriangles();
    }
}