using System;
using System.Collections.Generic;
using System.Linq;
using TriangleNetwork.Models;

//Tato třída převede validní seznam řetězců zpracovaný třídou "DataValidator" na seznam bodů setříděných podle souřadnice X. Toto provádí funkce DataSort(), která projde každý
//prvek validního seznamu řetězců a řetězce rozdělí na souřadnici X a Y (**A**). Na prvním řádku seznamu je uveden rozměr mřížky, ten je přiřazen objektu FieldSize (**B**).   
//Ostatní souřadnice jsou přiřazeny vytvořeným instancím bodů a přiřazeny do připraveného seznamu bodů "PointByX" (**C**). Ten je následně srovnán podle X (**D**).

namespace TriangleNetwork.DataLayer
{
    public class DataRepository : IDataRepository
    {
        private IDataValidator iDataValidator;        
        private IPoint iPoint;
        private List<Point> PointsByX { get; set; }       

        public DataRepository(IDataValidator iDataValidator, IPoint iPoint)
        {
            PointsByX = new List<Point>();
            this.iPoint = iPoint;
            this.iDataValidator = iDataValidator;
           
            DataSort();
        }

        private void DataSort()
        {
            int row = 0;
            foreach (string line in iDataValidator.GetValidatedLines())
            { 
                //**A**
                var coordinatesPair = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //**B**
                if (row == 0)
                {                      
                    FieldSize.SetFieldSize(coordinatesPair[0], coordinatesPair[1]);
                }

                //**C**
                else if (row >= 1)
                {                    
                    Point newPoint = iPoint.CreatePoint();
                    newPoint.SetPoint(coordinatesPair[0], coordinatesPair[1]);
                    PointsByX.Add(newPoint);
                }
                row++;
            }
            //**D**
            PointsByX = PointsByX.OrderBy(o => o.X).ToList();
        }

        public List<Point> GetPointsByX()
        {
            return PointsByX;
        }
        
      
    }
}
