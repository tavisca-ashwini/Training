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
            double money = 0.0;
            string sourceCurrency = null;
            try
            {
                Console.WriteLine("\nEnter Amount : ");
                while (double.TryParse(Console.ReadLine(), out money) == false)
                {
                    Console.WriteLine(" Enter valid entry for money");
                }
                Console.WriteLine("Enter Currency");
                sourceCurrency = Console.ReadLine();
                
                Money money1 = new Money(money,sourceCurrency);
                
                Console.WriteLine("\nEnter target Currency : ");
                string target = Console.ReadLine();
                Console.WriteLine("\nExchanged Amount : ");
                var money2 = new Money(target);

                double exchangedRate = money1.Convert(money1.Amount, money1.Currency, money2.Currency);
                Console.WriteLine("{0} {1}", exchangedRate, target.ToUpper());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}
