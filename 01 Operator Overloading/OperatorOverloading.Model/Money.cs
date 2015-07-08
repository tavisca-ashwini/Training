using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        public double Amount { get; set; }
        public string Currency { get; set; }

        public Money(double money, string tempCurrency)
        {
            this.Amount = money;
            this.Currency = tempCurrency;
        }
        public Money()
        {

        }

        //operator + is overloaded
        public static Money operator +(Money Money1, Money Money2)
        {
            string currency;
            double money = 0.0;
            Money Money3 = new Money();

            if (!string.IsNullOrEmpty(Money1.Currency) && !string.IsNullOrEmpty(Money2.Currency) && string.Equals(Money1.Currency, Money2.Currency, StringComparison.OrdinalIgnoreCase))
            {
                currency = Money1.Currency.ToUpper();
                Money3.Amount = Money1.Amount + Money2.Amount;
                Money3.Currency = Money1.Currency;

                if (Money1.Amount <= (double.MaxValue - Money2.Amount))
                {
                    money = Money3.Amount;
                }
                else
                {
                    throw new OverflowException("Amount Overflowing");
                }
            }
            else
            {
                throw new InvalidCurrencyException("Invalid Currency");   //exception thrown
            }
            return Money3;
        }
    }
}
                    
        