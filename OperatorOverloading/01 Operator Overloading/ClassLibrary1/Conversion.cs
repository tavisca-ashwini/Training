using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;

namespace OperatorOverloading.Dbl
{
    public class Conversion : CurrencyParser
    {
        FetchFile fetch = new FetchFile();
        static string[] currencySeperatedData;

        public double GetCurrencyConversion(double sourceAmount, string sourceCurrency, string targetCurrency)
        {

            currencySeperatedData = fetch.FetchParse();

            double converter1 = getConverter(sourceCurrency);
            double converter2 = getConverter(targetCurrency);
            return (converter2 / converter1) * sourceAmount;
        }
        public static double getConverter(string currency)
        {
            bool found = false;
            if (currency.Equals("USD"))
            {
                return 1;
            }
            int j;
            for (j = 0; j < currencySeperatedData.Length; j++)
            {
                currencySeperatedData[j] = currencySeperatedData[j].Trim();
                if (currencySeperatedData[j].Contains(currency))
                {
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                throw new System.Exception(ParserMessages.UnavailableEntry);
            }
            string[] finalSplit = currencySeperatedData[j].Split(':');
            double conversionRate = Convert.ToDouble(finalSplit[1]);
            return conversionRate;
        }
    }
}
