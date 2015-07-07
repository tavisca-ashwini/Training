using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorOverloading.Model
{
    public class InvalidCurrencyException : Exception
    {
        public string msg = "Invalid Currency";
    }
}
