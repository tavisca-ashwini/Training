using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace OperatorOverloading.Model
{
    public class Conversion : IParser
    {
        public double Converts(double amount, string currency)
        {
            double amount1;

            string sURL;
            sURL = "http://www.apilayer.net/api/live?access_key=9f011e5b35e7990d360073da30a7f8f2";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;

            wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sLine = null;
            int i = 0;
            int j=0;
            string CompleteString = null;
            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    CompleteString += sLine;
            }
            string[] SplittedString = CompleteString.Split(',');

            for (j = 0; j < SplittedString.Length; j++)
            {
                if (SplittedString[j].Contains(currency) == true)
                    break;
            }
            string[] FinalString = SplittedString[j].Split(':');
            double multiply = Convert.ToDouble(FinalString[1]);
            amount1 = amount * multiply;
            return amount1;
        }
    }
}
