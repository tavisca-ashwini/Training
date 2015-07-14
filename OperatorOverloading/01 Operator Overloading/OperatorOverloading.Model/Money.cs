using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Dbl;
using OperatorOverloading.Parse;

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
                    throw new Exception();
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

        public Money(string source)
        {
            this.Currency = source;
        }
       
        // Code for Currency conversion Rate 
        FileExchangeRateProvider fileExchangeRateProvider = new FileExchangeRateProvider();
        public  double Convert(double amount, string sourceCurrency, string targetCurrency)
        {
            double exchangeRate = fileExchangeRateProvider.GetExchangeRate(sourceCurrency, targetCurrency);
            return exchangeRate * amount;
        }

        //operator + is overloaded
        public static Money operator +(Money Money1, Money Money2)
        {
            string currency;
            
            if (Money1 == null || Money2 == null)   //Null checked for money objects
            {
                throw new NullReferenceException();
            }
            Money Money3 = new Money();
            
            if (Money1.Currency.Equals(Money2.Currency, StringComparison.OrdinalIgnoreCase))  // checking whether both currencies are equal or not
            {
                Money3.Amount = Money1.Amount + Money2.Amount;
                Money3.Currency = Money1.Currency.ToUpper();
                if (double.IsInfinity(Money3.Amount))     //cheked infinity for amount for exception
                {
                    throw new OverflowException(Messages.Overfolw);
                }
            }
            currency = Money1.Currency.ToUpper(); // used to convert the currency into Uppercase
            Money3.Amount = Money1.Amount + Money2.Amount;
            Money3.Currency = Money1.Currency;
            return Money3;
        }
        public override string ToString()
        {
            StringBuilder show = new StringBuilder();
            show.Append("Amount" + this.Amount + "Currency" + this.Currency);
            return show.ToString();
        }
    }
}