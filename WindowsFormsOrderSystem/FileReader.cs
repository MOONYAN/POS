using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class FileReader
    {
        private const char SPLIT_TOKEN = ',';
        private StreamReader _reader;

        // get string[] list from .csv file
        public List<String[]> GetStringList(string path)
        {
            List<string[]> stringList = new List<string[]>();
            string readLine = string.Empty;
            _reader = new StreamReader(path);

            while ((readLine = _reader.ReadLine()) != null)
            {
                stringList.Add(readLine.Split(SPLIT_TOKEN));
            }
            _reader.Close();
            return stringList;
        }
    }
}
