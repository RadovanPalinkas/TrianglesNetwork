using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//metoda SetFieldSize() převede vstupní řetězce na typ decimal a přiřadí ho vlastnostem

namespace TriangleNetwork.Models
{
    public static class FieldSize
    {
        public static int ColumnsCaunt { get; private set; }
        public static int RowsCaunt { get; private set; }

        public static void SetFieldSize(string columns, string rows)
        {
            ColumnsCaunt = Convert.ToInt32(decimal.Parse(columns, CultureInfo.InvariantCulture.NumberFormat));
            RowsCaunt = Convert.ToInt32(decimal.Parse(rows, CultureInfo.InvariantCulture.NumberFormat));
        }
    }

}
