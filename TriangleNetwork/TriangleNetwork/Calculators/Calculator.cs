using System.Collections.Generic;
using TriangleNetwork.DataLayer;
using TriangleNetwork.Models;

//Třída "Calculator" vytvoří seznam "Triangles"  a naplní ho trojúhelníky podle zadání příkladu.
//Funkce CalculateTriangles() tvoří trojúhelník tak, že vrcholu A přiřadí bod s indexem 0 ze sloupce s indexem 0 (**A**),
//vrcholu B přiřadí bod s indexem 1 ze sloupce s indexem 0 (**B**) a vrcholu C přiřadí bod s indexem 1 ze sloupce s indexem 1 **C**.
//Při další iteraci cyklu for se index bodu navýší o 1 a celá situace se opakuje (**D**). Takto se projde celá mřížka dvakrát s tím
//rozdílem, že při druhém kole "round"(**E**) se vykoná druhá podmínka (**F**)

namespace TriangleNetwork.Calculators
{
    public class Calculator : ICalculator
    {
        private ITriangle iTriangle;
        private IDataRepository iDataRepository;
        private ICalculationPreparer iCalculationPreparer;

        private List<IColumns> ListColumns { get; set; }
        private List<ITriangle> Triangles { get; set; }

        public Calculator(ITriangle iTriangle, IDataRepository iDataRepository, ICalculationPreparer iCalculationPreparer)
        {
            ListColumns = new List<IColumns>();
            Triangles = new List<ITriangle>();
            this.iTriangle = iTriangle;
            this.iDataRepository = iDataRepository;
            this.iCalculationPreparer = iCalculationPreparer;

            ListColumns = iCalculationPreparer.CreateColumns(this.iDataRepository.GetPointsByX());
            CalculateTriangles();
        }

        private void CalculateTriangles()
        {
            //**E**
            for (int round = 0; round < 2; round++)
            {
                for (int column = 0; column < FieldSize.ColumnsCaunt - 1; column++)
                {
                    //**D**
                    for (int row = 0; row < FieldSize.RowsCaunt - 1; row++)
                    {
                        ITriangle triangle = iTriangle.CreateTriangle();

                        //**A**
                        triangle.TopA = ListColumns[column].Column[row];

                        if (round == 0)
                        {   
                            //**B**
                            triangle.TopB = ListColumns[column].Column[row + 1];

                            //**C**
                            triangle.TopC = ListColumns[column + 1].Column[row + 1];
                        }
                        //**F**
                        else if (round == 1)
                        {
                            triangle.TopB = ListColumns[column + 1].Column[row + 1];
                            triangle.TopC = ListColumns[column + 1].Column[row];
                        }
                        Triangles.Add(triangle);
                    }
                }
            }
        }
        public List<ITriangle> GetTriangles()
        {
            return Triangles;
        }
    }
}
