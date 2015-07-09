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
    public class NullReferenceException : Exception
    {
        public string message { get; set; }
        public NullReferenceException()
        {
        }
        public NullReferenceException(string Message)
            : base(Message)
        {
        }
        protected NullReferenceException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
