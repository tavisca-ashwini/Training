using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;

namespace OperatorOverloading.Dbl
{
    public class FileExchangeRateProvider:IExchangeRateProvider
    {
         static string[] initialseperatedString;
         static string[] currencySeperatedString;

        public  double GetExchangeRate(string sourceCurrency,string targetCurrency)
        {
            string line;
            string completeData = "";

            System.IO.StreamReader file = new System.IO.StreamReader("C:/Users/akardile/Desktop/Json.txt");
            while ((line = file.ReadLine()) != null)
            {
                completeData += line;
            }
            file.Close();
            initialseperatedString = completeData.Split('{');
            initialseperatedString[0] = "";
            initialseperatedString[1] = "";

            currencySeperatedString = initialseperatedString[2].Split(',');

            double converter1 = GetConverter(sourceCurrency);
            double converter2 = GetConverter(targetCurrency);

            return (converter2/converter1);
        }
        public static double GetConverter(string sourceCurrency)
         {
             string currency = sourceCurrency.ToUpper();
             if (currency.Equals("USD"))
                 return 1;
             int j;
             for (j = 0; j < currencySeperatedString.Length; j++)
             {
                 if (currencySeperatedString[j].Contains(currency) == true)
                     break;
             }
             string[] finalSplit = currencySeperatedString[j].Split(':');
             double multiplier = Convert.ToDouble(finalSplit[1]);

             return multiplier;
         }     
    }
        
}