using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
   class Operation
    {
        static void Main(string[] args)
        {
            double money = 0.0;

            Money money1 = new Money();
            Money money2 = new Money();
            Money money3 = new Money();

            Console.WriteLine("Enter Amount for first object");
            while (double.TryParse(Console.ReadLine(), out money)== false)
            {
               Console.WriteLine(" Enter valid entry for money");
            }
            money1.Amount = money;
            
            Console.WriteLine("Enter Currency for first object");
            while (true)
            {
                try
                {
                    money1.Currency = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }

            Console.WriteLine("Enter Amount for second object ");
            while (double.TryParse(Console.ReadLine(), out money)== false)
            {
               Console.WriteLine(" Enter valid entry for money");
            }
            money2.Amount = money;
            
            Console.WriteLine("Enter Currency for second object");
            while (true)
            {
                try
                {
                    money2.Currency = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
           
            try
            {
               money3 = money1 + money2;
            }
            catch (Exception ex) // catched exception
            {
               Console.WriteLine(ex.Message);
               Console.ReadKey();
               return;
            }

            Console.WriteLine(money1);
            Console.WriteLine(money2);
            Console.WriteLine("");
            Console.WriteLine("After Addition");
            Console.WriteLine("");
            Console.WriteLine(money3);
            Console.ReadKey();
        }
    }
}
