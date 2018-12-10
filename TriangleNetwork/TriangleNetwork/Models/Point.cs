using System.Globalization;

//metoda SetPoint() převede vstupní parametry na decimal a přiřadí je vlastnostem.
//metoda CreatePoint() vrátí instanci objektu.

namespace TriangleNetwork.Models
{
    public class Point : IPoint
    {
        public decimal X { get;  set; }
        public decimal Y { get;  set; }
        
        public void SetPoint(string souradniceX, string souradniceY)
        {
            X = decimal.Parse(souradniceX, CultureInfo.InvariantCulture.NumberFormat);
            Y = decimal.Parse(souradniceY, CultureInfo.InvariantCulture.NumberFormat);
        }
        public Point CreatePoint()
        {
            return new Point();
        }
    }
}
