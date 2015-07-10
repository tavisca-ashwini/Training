using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;
using OperatorOverloading.Dbl;

namespace OperatorOverloading.Host
{
    class CurrencyConversion
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Amount in Format : 100 USD");
                string input = Console.ReadLine();
                string[] source = input.Split(' ');
                double amount=0.0;
                if (double.TryParse(source[0], out amount) == false)
                    Console.WriteLine("Invalid amount.");

                var money1 = new Money(amount,source[1]);

                Console.WriteLine("\nEnter target Currency in which want to Convert: ");
                string target = Console.ReadLine();
                Console.WriteLine("Converted Amount : ");

                double conversionRate = money1.CurrencyConversion(money1.Amount, money1.Currency, target);
                Console.WriteLine("{0} {1}", conversionRate, target.ToUpper());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
