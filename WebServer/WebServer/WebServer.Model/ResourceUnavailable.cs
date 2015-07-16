using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServer.Model
{
    [Serializable]
    public class ResourceUnavailable : Exception
    {
        public ResourceUnavailable() : base() { }

        public ResourceUnavailable(string message) : base(message) { }

        public ResourceUnavailable(string message, Exception exception) : base(message, exception) { }

        protected ResourceUnavailable(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
