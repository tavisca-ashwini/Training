using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class Money
    {

        public double Money1 { get; set; }

        public double Money2 { get; set; }

        public double Money3 { get; set; }

        public double Total;

        public double getAdd()
        {
            return Total;
        }

        public void setAdd()
        {
            Total = Money1 + Money2 + Money3;
        }

        public static Money operator +(Money Money2, Money Money3)
        {
            Money money = new Money();
            money.Money1 = Money2.Money1 + Money3.Money1;
            money.Money2 = Money2.Money2 + Money3.Money2;
            money.Money3 = Money2.Money3 + Money3.Money3;
            return money;
        }

    }

}