using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorOverloading.Model
{
    [Serializable]
    public class InvalidCurrencyException : Exception
    {
        public string msg { get; set; }
        public InvalidCurrencyException(string msg)
            : base(msg)
        {
        }
    }
}
