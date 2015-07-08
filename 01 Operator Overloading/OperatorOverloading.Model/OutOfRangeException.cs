using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace OperatorOverloading.Model
{
    [Serializable]
    class OutOfRangeException : Exception
    {
        public string Message { get; set; }
        public OutOfRangeException(string Message) :base (Message)
        {
        }
        public OutOfRangeException()
        {
        }
        public OutOfRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
