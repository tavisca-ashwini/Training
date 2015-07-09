using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.DBL;
using OperatorOverloading.Parse;

namespace OperatorOverloading.Model
{
    public class Money
    {
        Conversion currConversion = new Conversion();
        private string _currency;
        
        public double Amount
        {
            get;
            set;
        }
        public string Currency
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
                {
                    throw new Exception(Messages.CurrencyEmpty);
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

        public double ConvertCurrency(string source, string target)
        {
            return (currConversion.GetCurrencyConversion(source,target));
        }
        //operator + is overloaded
        public static Money operator +(Money Money1, Money Money2)
        {
            if (Money1 == null || Money2 == null)   //Null checked for money objects
            {
                throw new Exception(Messages.MoneyNullValues);
            }

            Money Money3 = new Money();

            if (Money1.Currency.Equals(Money2.Currency , StringComparison.OrdinalIgnoreCase))  // checking whether both currencies are equal or not
            {
                Money3.Amount = Money1.Amount + Money2.Amount;
                Money3.Currency = Money1.Currency.ToUpper();

                if (double.IsInfinity(Money3.Amount))     //cheked infinity for amount for exception
                {
                    throw new OverflowException(Messages.Overfolw);
                }
            }
            /*else
            {
                throw new InvalidCurrencyException(Messages.InvalidCurrency);   //exception thrown
            }*/
            return Money3;
        }

        public override string ToString()
        {
            StringBuilder show = new StringBuilder();
            show.Append("Amount : " + this.Amount + " " + "Currency : " + this.Currency);
            return show.ToString();
        }
    }
}
                    
        