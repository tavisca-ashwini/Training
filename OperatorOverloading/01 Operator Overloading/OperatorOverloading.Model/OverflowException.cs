using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace OperatorOverloading.Model
{
    [Serializable]
    class OverflowException : Exception
    {
        public string message { get; set; }
        public OverflowException(string message) : base (message)        
        {
        }
        public OverflowException()
        {
        }
        public OverflowException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
