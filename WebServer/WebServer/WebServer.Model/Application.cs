using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model.Interfaces;

namespace WebServer.Model
{
    internal class Application
    {
        static Application()
        {
            RequestQueue = new InProcessQueue();
        }
        public static IQueue RequestQueue { get; private set; }
    }
}
