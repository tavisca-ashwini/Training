using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer webserver = new WebServer();
            webserver.Start(8080, @"D:\WebServerTest\startbootstrap-sb-admin-1.0.3");
        }
    }
}
