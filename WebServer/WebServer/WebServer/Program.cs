using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
             try
            {
                //Console.WriteLine("Webserver Started");
                int port = 0;
                if (int.TryParse(ConfigurationManager.AppSettings["port"], out port) == false)
                    throw new Exception("Invalid port");

                string host = ConfigurationManager.AppSettings["host"];
                if (string.IsNullOrEmpty(host))
                    throw new Exception("Invalid Host");

                var server = new Server(host , port);
                server.Start();

                Console.WriteLine("Server started");

                server.Stop();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
