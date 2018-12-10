using System.Collections.Generic;
using System.Text.RegularExpressions;

//Tato třída obdrží instanci třídy FileService a zkontroluje, jestli seznam řetězců načtený ze zdrojového souboru odpovídá požadavkům.
//Funkce CheckFormat() projde seznam řetězců a zkontroluje shodu s regulerními výrazy (**A**), neodpovídající řádky odstraní (**B**).
//Dále pak zkontroluje, jestli má ošetřený seznam správný počet prvků (**C**)

namespace TriangleNetwork.DataLayer
{
    public class DataValidator : IDataValidator
    {
        private IService iServices;
        private IError iError;
        List<string> Fails { get; set; }

        public DataValidator(IService iServices,IError iError)
        {
            this.iError = iError;
            this.iServices = iServices;

            CheckFormat();
        }

        private void CheckFormat()
        {
            Fails = new List<string>();
            int i = 0;

            //**A**
            foreach (string line in iServices.GetLines())
            {                
                if (i == 1 &&!Regex.IsMatch(line, Constants.GetInstance.patternFieldSize))
                {
                    iError.GetError(EnumErrors.FieldSizeFormatException);
                }
                else if(i != 1 &&!Regex.IsMatch(line, Constants.GetInstance.patternForPoints))
                {
                    Fails.Add(line);
                }                
                i++;                
            }
            //**B**
            foreach (string fail in Fails)
            {
                 iServices.GetLines().Remove(fail);
            }

            //**C**
            if (iServices.GetLines().Count != Constants.GetInstance.linesCaunt)
            {
                iError.GetError(EnumErrors.NumberOfPointsException);
            }
        }
        public List<string> GetValidatedLines()
        {            
            return iServices.GetLines();
        }
    }
}
