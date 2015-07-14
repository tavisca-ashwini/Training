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
            try
            {
                Console.WriteLine("Webserver Started");
                Listener server = new Listener(8080);
                server.Run();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}