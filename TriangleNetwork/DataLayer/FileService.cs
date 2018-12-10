using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Třída načte ze souboru data a uloží je do seznamu řetězců (**A**). Pokud nebude soubor nalezen vypíše výjimku a program ukončí (**B**)

namespace TriangleNetwork.DataLayer
{
    class FileService : IService
    {
        private List<string> Lines { get; set; }
        IError iError;        
       
        public FileService(IError iError)
        {
            this.iError = iError;

            LoadFile();           
        }
        private void LoadFile()
        {
            Lines = new List<string>();
            try
            {
                //**A**
                Lines = File.ReadAllLines(Constants.GetInstance.sourcePath).ToList();
            }
            catch (Exception ex)
            {
                //**B**
                iError.GetError(EnumErrors.FileException, ex);
            }
        }

        public List<string> GetLines()
        {            
            return Lines;
        }
    }
}
