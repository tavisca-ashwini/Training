using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        private string _currency;

        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        public string Currency
        {
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 3)
                {
                    throw new Exception(messages.CurrencyEmpty);
                }
                _currency = value;
            }
            get
            {
                return _currency;
            }
        }
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

            if (Money1 == null || Money2 == null)   //Null checked for money objects
            {
                throw new NullReferenceException(messages.NullValues);
            }

            Money Money3 = new Money();

            if (Money1.Currency.Equals(Money2.Currency , StringComparison.OrdinalIgnoreCase))  // checking whether both currencies are equal or not
            {
                currency = Money1.Currency.ToUpper(); // used to convert the currency into Uppercase
                Money3.Amount = Money1.Amount + Money2.Amount;
                Money3.Currency = Money1.Currency;

                if (double.IsInfinity(Money3.Amount))     //cheked infinity for amount for exception
                {
                    throw new OutOfRangeException();
                }

                if (Money1.Amount <= (double.MaxValue - Money2.Amount))
                {
                    money = Money3.Amount;
                }
                else
                {
                    throw new OverflowException(messages.Overfolw);
                }
            }
            else
            {
                throw new InvalidCurrencyException();   //exception thrown
            }
            return Money3;
        }
        public override string ToString()
        {
            StringBuilder show = new StringBuilder();
            show.Append("New_Amount : " + this.Amount + " " + "New_Currency : " + this.Currency);
            return show.ToString();
        }
    }
}
                    
        