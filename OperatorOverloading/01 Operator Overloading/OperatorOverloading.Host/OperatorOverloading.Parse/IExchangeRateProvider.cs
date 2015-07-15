﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Parse
{
    public interface IExchangeRateProvider
    {
        double GetExchangeRate(string currencySource , string currencyTarget);
    }
}
