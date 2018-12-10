using System.Collections.Generic;

namespace TriangleNetwork.Models
{
    public interface IColumns
    {
        List<Point> Column { get; set; }

        Columns CreateColumn();
    }
}