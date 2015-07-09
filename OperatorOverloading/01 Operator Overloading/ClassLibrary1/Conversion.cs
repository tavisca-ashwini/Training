using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;
using System.Net;
using System.IO;


namespace OperatorOverloading.DBL
{
    public class Conversion : IParser
    {
        static string[] splitedString;
        static string[] currencySplittedString;
        
        public double GetCurrencyConversion(string sourceCurrency, string targetCurrency)
        {
            Conversion currConversion = new Conversion();
            string stringLine;
            string completeData = "";

            StreamReader reader = new StreamReader("D:/Training_1/OperatorOverloading/01 Operator Overloading/ClassLibrary1/Json.txt");
            while ((stringLine = reader.ReadLine()) != null)
            {
                completeData += stringLine;
            }
           
            reader.Close();
            splitedString = completeData.Split('{');
            splitedString[0]="";
            splitedString[1]="";

            currencySplittedString = splitedString[2].Split(',');
            
            double converter1 = getConverter(sourceCurrency);
            double converter2 = getConverter(targetCurrency);
           
            return (converter1/converter2);
        }            
        public static double getConverter(string currency)
        {
            if (currency == null || currency.Length !=3)
            {
                throw new Exception("Invalid Currency Input");
            }
            if (currency.Equals("USD"))
            {
                return 1;
            }
            int j = 0;
            for ( j = 0; j < currencySplittedString.Length; j++)
            {
                if (currencySplittedString[j].Contains(currency) == true)
                {
                    break;
                }
            }
            string[] splittedString = currencySplittedString[j].Split(':');
            double converter;
           
            double.TryParse((splittedString[1]), out converter);
            return converter;
        }
    }
}
