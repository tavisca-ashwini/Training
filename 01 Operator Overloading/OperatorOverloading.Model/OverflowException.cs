using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    [Serializable]
    class OverflowException : Exception
    {
        public string message { get; set; }
        public OverflowException(string message)
            : base(message)
        {
        }
    }
}
