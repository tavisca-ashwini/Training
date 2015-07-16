using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public static class Errors
    {
        public static Exception ResourceNotFound()
        {
            return new ResourceUnavailable();
        }
    }
}
