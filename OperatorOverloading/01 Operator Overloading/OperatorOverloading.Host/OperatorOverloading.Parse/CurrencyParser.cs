using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Parse
{
    public interface CurrencyParser
    {
        double GetCurrencyConversion(double amount, string currencySource , string currencyTarget);
    }
}
