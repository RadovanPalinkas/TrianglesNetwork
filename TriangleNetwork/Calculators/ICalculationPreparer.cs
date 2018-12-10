using System.Collections.Generic;
using TriangleNetwork.Models;

namespace TriangleNetwork.Calculators
{
    public interface ICalculationPreparer
    {
        List<IColumns> CreateColumns(List<Point> points);
    }
}