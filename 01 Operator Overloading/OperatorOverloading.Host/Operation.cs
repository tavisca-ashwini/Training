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
           string tempCurrency = null;

           Money money1 = new Money();
           Money money2 = new Money();
           Money money3 = new Money();

           Console.WriteLine("Enter Amount for first object");
           while (double.TryParse(Console.ReadLine(), out money)== false)
           {
               Console.WriteLine(" Enter valid entry for money");
           }
           Console.WriteLine("Enter Currency for first object");
           tempCurrency = Console.ReadLine();

           money1.Amount = money;
           money1.Currency = tempCurrency;

           Console.WriteLine("Enter Amount for second object ");
           while (double.TryParse(Console.ReadLine(), out money)== false)
           {
               Console.WriteLine(" Enter valid entry for money");
           }
           Console.WriteLine("Enter Currency for second object");
           tempCurrency = Console.ReadLine();
           
           money2.Amount = money;
           money2.Currency = tempCurrency;

           try
           {
               money3 = money1 + money2;
           }
           catch (Exception ex) // catched exception
           {
               Console.WriteLine("" + ex.Message);
               Console.ReadKey();
               return;
           }

           Console.WriteLine(money1.ToString());
           Console.WriteLine(money2.ToString());
           Console.WriteLine("");
           Console.WriteLine("After Addition");
           Console.WriteLine("");
           Console.WriteLine(money3.ToString());
           Console.ReadKey();
        }
    }
}
