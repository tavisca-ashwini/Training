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

           /*obtaining values or first object*/
           Console.WriteLine("Enter Amount for first object");
           while (!double.TryParse(Console.ReadLine(), out money))
           {
               Console.WriteLine(" Enter valid entry for money");
           }
           Console.WriteLine("Enter Currency for first object");
           tempCurrency = Console.ReadLine();

           /*assigning values to object*/
           money1.Amount = money;
           money1.Currency = tempCurrency;

           /*obtaining values or second object*/
           Console.WriteLine("Enter Amount for second object ");
           while (!double.TryParse(Console.ReadLine(), out money))
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
           catch (InvalidCurrencyException ex) // catched exception
           {
               Console.WriteLine("" + ex.msg);
               Console.WriteLine("");
               Console.ReadKey();
               return;
           }
           catch (OverflowException e)
           {
               Console.WriteLine("" + e.Message);
               Console.WriteLine("");
               Console.ReadKey();
               return;
           }
           Console.WriteLine("Amount entered :  " +money1.Amount + " Currency for Amount :" +money1.Currency);
           Console.WriteLine("Amount entered :  " + money2.Amount + " Currency for Amount : " + money2.Currency);
           Console.WriteLine("Addtion is Done");
           Console.WriteLine("");
           Console.WriteLine("Amount after addition : " + money3.Amount + "Currency for Amount : " + money3.Currency);
           Console.ReadKey();
        }
    }
}
