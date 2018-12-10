using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//metoda SetFieldSize() převede vstupní řetězce na typ decimal a přiřadí je vlastnostem

namespace TriangleNetwork.Models
{
    public static class FieldSize
    {
        public static int ColumnsCount { get; private set; }
        public static int RowsCount { get; private set; }

        public static void SetFieldSize(string columns, string rows)
        {
            ColumnsCount = Convert.ToInt32(decimal.Parse(columns, CultureInfo.InvariantCulture.NumberFormat));
            RowsCount = Convert.ToInt32(decimal.Parse(rows, CultureInfo.InvariantCulture.NumberFormat));
        }
    }

}
