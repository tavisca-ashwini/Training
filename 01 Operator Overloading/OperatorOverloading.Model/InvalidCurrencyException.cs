using System;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace OperatorOverloading.Model
{
    [Serializable]
    class InvalidCurrencyException : Exception
    {
        public string msg { get; set; }
        public InvalidCurrencyException(string msg) : base (msg)
        {
        }
        public InvalidCurrencyException()
        {
        }
        public InvalidCurrencyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
