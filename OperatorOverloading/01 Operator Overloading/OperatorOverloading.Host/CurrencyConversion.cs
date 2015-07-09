using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    class CurrencyConversion
    {
        public static void Main(string [] args)
        {
            string sourceCurrency = "";
            string targetCurrency = "";

            Money money = new Money();

            Console.WriteLine("Enter the Source Currency");
            sourceCurrency = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter the Target Currency for conversion");
            targetCurrency = Console.ReadLine().ToUpper();

            double convertedCurrency = money.ConvertCurrency(sourceCurrency, targetCurrency);
            Console.WriteLine(convertedCurrency);
            Console.ReadKey();
        }
    }
}
