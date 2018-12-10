using System.Collections.Generic;
using TriangleNetwork.Models;

namespace TriangleNetwork.DataLayer
{
    public interface IDataRepository
    {       
        List<Point> GetPointsByX();
    }
}