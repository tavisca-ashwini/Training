using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class OperatorOverload
    {
        static void Main(string[] args)
        {
            Money BasicSalary = new Money();
            Money OverTimeBonus = new Money();
            Money TotalBonus = new Money();


            BasicSalary.Money1 = 7;
            BasicSalary.Money2 = 6;
            BasicSalary.Money3 = 5;

            OverTimeBonus.Money1 = double.MinValue;
            OverTimeBonus.Money2 = double.MinValue;
            OverTimeBonus.Money3 = double.MinValue;

            TotalBonus = BasicSalary + OverTimeBonus;
            try
            {
                TotalBonus.setAdd();
                BasicSalary.setAdd();
                OverTimeBonus.setAdd();

                if (double.IsInfinity(TotalBonus.Total) || double.IsInfinity(BasicSalary.Total) || double.IsInfinity(OverTimeBonus.Total))
                {
                    throw new OverflowException();
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Values of some object are out of bound");
            }
            finally
            {
                Console.WriteLine(" ");
                Console.WriteLine("Addition of BasicSalary : {0}", BasicSalary.getAdd());
                Console.WriteLine("Addition of OverTimeBonus : {0}", OverTimeBonus.getAdd()%double.MaxValue);
                Console.WriteLine("Addition of TotalBonus : {0}", TotalBonus.getAdd());
            }
            Console.ReadKey();
        }
    }
}
