
//V této třídě jsou umístěny vzory pro regulární výrazy, zdrojový soubor a číslo udávající počet řádků validovaného seznamu řetězců.
//jedná se o singleton a vlastnost GetInstance vrátí existující instanci této třídy, pokud instance neexistuje vytvoří ji (**A**).

namespace TriangleNetwork
{
    public sealed class Constants
    {
        public readonly string sourcePath = @"ZdrojSouradnic.txt";
        public readonly string patternForPoints = @"^[-+]?([0-1]{1})?([0-9]{1})(\.[0-9]{1,8})?\s+[-+]?([0-6]{1})(\.[0-9]{1,8})?$";
        public readonly string patternFieldSize = @"^[-+]?([2]{1})([1]{1})(\.[0-9]{1,8})?\s+[-+]?([9]{1})(\.[0-9]{1,8})?$";
        public readonly int linesCaunt = 190;

        private static Constants instance = null;
        private static readonly object key = new object();

        private Constants()
        {
        }
        //**A**
        public static Constants GetInstance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new Constants();
                    }
                    return instance;
                }
            }
        }
    }
}
