using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double amount;
        private string currency;

        public double Amount
        {
            get 
            { 
               return this.amount; 
            }
            set 
            {
                this.amount = value;
            }
        }
        public string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
            } 
        }
        public Money(int money, string tempCurrency)
        {
            this.amount = money;
            this.currency = tempCurrency;
        }
        public Money()
        {

        }
        public static Money operator +(Money Money1, Money Money2)
        {
            Money Money3 = new Money();

            if (Money1.Currency.Equals(Money2.Currency))
            {
                Money3.Amount = Money1.Amount + Money2.Amount;
            }
            else
            {
                throw new InvalidCurrencyException();   //exception thrown
            }

            Money3.Currency = Money1.Currency;
            return Money3;
        }
    }
}
