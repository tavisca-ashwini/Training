using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    [Serializable]
    class EntryUnavailableException : Exception
    {
        public EntryUnavailableException(string message)
            : base(message)
        {
        }
        public EntryUnavailableException()
        {
        }
         protected EntryUnavailableException (SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
