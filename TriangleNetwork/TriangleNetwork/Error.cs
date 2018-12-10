using System;
using System.Collections.Generic;
using System.Threading;

//obsahuje evidenci chybové hlášky a funkce. A metody, které je vypíší do konzole a následně ukončí aplikaci

namespace TriangleNetwork
{
    public class Error : IError
    {
        Dictionary<EnumErrors, string> Errors = new Dictionary<EnumErrors, string>()
        {
            {EnumErrors.FieldSizeFormatException,"Počet sloupcu a řádků je neměnný. Tento údaj musí být umístěn na druhém řádku" },
            {EnumErrors.FileException, $"Výjimka: "},
            {EnumErrors.NumberOfPointsException, $"Pravděpodobně jste změnil data tak že jsou nevalidní" }
        };      
       
        public void GetError(EnumErrors error)
        {
            string errorText;
            Errors.TryGetValue(error, out errorText);
            WriteSleepEnd(errorText);
        }
        public void GetError(EnumErrors error, Exception ex)
        {
            string errorText;
            Errors.TryGetValue(error, out errorText);
            errorText += ex.Message;
            WriteSleepEnd(errorText);
        }

        private void WriteSleepEnd(string errorText)
        {
            Console.WriteLine(errorText);
            Thread.Sleep(5000);
            Environment.Exit(1);
        }
    }
    public enum EnumErrors
    {
        FieldSizeFormatException,
        FileException,        
        NumberOfPointsException,
    }
}
