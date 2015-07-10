using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Parse;
using OperatorOverloading.Dbl;
using System.Text.RegularExpressions;


namespace OperatorOverloading.Model
{
    public class Money
    {
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
                _currency = value;
            }
            get
            {
                return _currency;
            }
        }
        public Money(string targetCurrency)
        {
            Currency = targetCurrency;
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
            if (Money1 == null || Money2 == null)   //Null checked for money objects
            {
                throw new Exception(Messages.MoneyNullValues);
            }
            Money Money3 = new Money();
            if (Money1.Currency.Equals(Money2.Currency , StringComparison.OrdinalIgnoreCase))  // checking whether both currencies are equal or not
            {
                Money3.Amount = Money1.Amount + Money2.Amount;
            }
            Money3.Currency = Money1.Currency.ToUpper();
            return Money3;
        }

        public double CurrencyConversion(double amount, string sourceCurrency, string targetCurrency)
        {
            if (string.IsNullOrWhiteSpace(targetCurrency) || string.IsNullOrWhiteSpace(sourceCurrency) || targetCurrency.Length != 3 || Regex.IsMatch(targetCurrency, @"^[a-zA-Z]+$") == false)
            {
                throw new ArgumentException("Currency is Null");
            }
            Conversion currencyConversion = new Conversion();
            double convertValue = currencyConversion.GetCurrencyConversion(Amount, Currency, targetCurrency.ToUpper());
            return convertValue;
        }
        public override string ToString()
        {
            StringBuilder show = new StringBuilder();
            show.Append("Amount : " + this.Amount + " " + "Currency : " + this.Currency);
            return show.ToString();
        }
    }
}
                    
        