using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;
using System.IO;

namespace OperatorOverloading.Dbl
{
    public class FetchFile
    {
        public string FileFetch()
        {
            string jsonFile = System.IO.File.ReadAllText(@"C:\Users\akardile\Desktop\Json.txt");
            return jsonFile; 
        }

        public static string[] convertString;
        public static string[] splittedString;

        public string[] FetchParse()
        {
            string text = FileFetch();
            text = text.Replace('}', '\0').Replace('\"', '\0');
            splittedString = text.Split('{');
            convertString = splittedString[2].Split(',');
            return convertString;
        }
    }
}
