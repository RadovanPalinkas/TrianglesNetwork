using System.Collections.Generic;

//metoda Create vrátí instanci třídy Columns.

namespace TriangleNetwork.Models
{
    public class Columns : IColumns
    {
        public List<Point> Column { get; set; }   
        
        public Columns CreateColumn()
        {
            return new Columns();
        }
    }
}
