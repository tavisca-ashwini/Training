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
            double number;
            string currency;

            Conversion currConvert = new Conversion();

            Console.WriteLine("Enter Amount and Currency");
            //currency = Console.ReadLine();
            if (double.TryParse(Console.ReadLine(), out tempAmount))
            {
                number = tempAmount;
            }
            else
            {
                throw new Exception("Not a valid currency");
            }

            Console.WriteLine("Enter the Currency for conversion");
            currency = Console.ReadLine();
            Console.WriteLine("{0} USD Equals to {1}{2}" ,number, currConvert.Converts(number, currency), currency);
            Console.ReadKey();
        }
    }
}