using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace WebServer
{
    class Dispatcher
    {
        //Dispatcher dispatch = new Dispatcher();
        public void HandleClient(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            string requestedInfo = "";
            while (reader.Peek() != -1)
            {
                requestedInfo += reader.ReadLine() + "\n";
            }
            Debug.WriteLine("Request \n" + requestedInfo);  //Writes information about debug to trace listeners in the Listeners collection.
            Request request_get = Request.GetRequest(requestedInfo);
            Response response_get = Response.FromServer(request_get);

            response_get.Post(client.GetStream());
        }
    }
}
