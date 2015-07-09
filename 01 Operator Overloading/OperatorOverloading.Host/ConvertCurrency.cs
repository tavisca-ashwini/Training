using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    class ConvertCurrency
    {
        public static void Main(string[] args)
        {
            double tempAmount;
            double count;
            string currency;

            ConvertCurrency currConvert = new ConvertCurrency();

            Console.WriteLine("Enter Amount in USD (currency)");
            if (double.TryParse(Console.ReadLine(), out tempAmount))
            {
                count = tempAmount;
            }
            else
            {
                throw new Exception("Not a valid currency");
            }
            Console.WriteLine("Enter the Currency for conversion");
            currency = Console.ReadLine();

            Console.WriteLine("{0} USD Equals to {1} {2}" + count, currConvert.Converts(count, currency), currency);
        }
    }
}
