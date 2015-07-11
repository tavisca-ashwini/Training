using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Webserver Started");
            Listener server = new Listener(8080);
            server.start();
            Console.ReadKey();
        }
    }
}