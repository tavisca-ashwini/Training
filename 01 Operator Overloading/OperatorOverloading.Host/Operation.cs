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
           string tempCurrency = " ";

           Money money1 = new Money();
           Money money2 = new Money();
           Money money3 = new Money();

           Console.WriteLine("Enter Amount for Money1");
           money = Convert.ToDouble(Console.ReadLine());
           Console.WriteLine("Enter Currency for Money1");
           tempCurrency = Convert.ToString(Console.ReadLine());

           money1.Amount = money;
           money1.Currency = tempCurrency;

           Console.WriteLine("Enter Amount for Money2");
           money = Convert.ToDouble(Console.ReadLine());
           Console.WriteLine("Enter Currency for Money2");
           tempCurrency = Convert.ToString(Console.ReadLine());
           
           money2.Amount = money;
           money2.Currency = tempCurrency;

           if (money1.Amount < 0 || money2.Amount < 0)
           {
               Console.WriteLine("Enter valid Amount");
               return;
           }
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
           Console.WriteLine("Amount entered :  " +money1.Amount + " Currency for Amount :" +money1.Currency);
           Console.WriteLine("Amount entered :  " + money2.Amount + " Currency for Amount : " + money2.Currency);
           Console.WriteLine("Addtion is Done");
           Console.WriteLine("Amount after addition : " + money3.Amount + "Currency for Amount : " + money3.Currency);
           Console.ReadKey();
        }
    }
}
