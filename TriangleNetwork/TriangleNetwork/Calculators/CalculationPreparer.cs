using System.Collections.Generic;
using System.Linq;
using TriangleNetwork.Models;

//Třída "CalculationPreparer" rozdělí seznam bodů seřazených podle X na několik menšíš seznamů. Každý z těchto seznamů odpovídá jednomu sloupci mřížky. 
//Tyto sloupce jsou následně setříděny podle Y.
//Funkce CreateColumns() nejprve vytvoří seznam, který naplní samotnými sloupci (**A**), následně do těchto sloupců přiřadí body ze seznamu bodů "pointsByX" (**B**).


namespace TriangleNetwork.Calculators
{
    public class CalculationPreparer : ICalculationPreparer
    {
        private IColumns iColumns;
        private List<IColumns> ListColumns { get; set; }

        public CalculationPreparer(IColumns iColumns)
        {
            this.iColumns = iColumns;
        }

        public List<IColumns> CreateColumns(List<Point> pointsByX)
        {                       
            //**A**
            ListColumns = new List<IColumns>();         
            for (int i = 0; i < FieldSize.ColumnsCaunt; i++)
            {
                ListColumns.Add(iColumns.CreateColumn());
            }

            //**B**
            int Row = 0;
            foreach (Columns columns in ListColumns)
            {
                columns.Column = pointsByX.GetRange(Row, FieldSize.RowsCaunt);
                columns.Column = columns.Column.OrderByDescending(p => p.Y).ToList();
                Row += FieldSize.RowsCaunt;
            }

            return ListColumns;
        }
    }
}
