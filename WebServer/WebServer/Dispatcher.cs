using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace WebServer
{
    class Dispatcher
    {
        private Socket _clientSocket = null;
        public FactoryHandler factoryHandler = new FactoryHandler();
        private Encoding _charEncoder = Encoding.UTF32;

        public Dispatcher(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }
        public void HandleRequest()
        {
            var requestParser = new RequestParser();
            string requestString = DecodeRequest(_clientSocket);

            if (requestParser.HttpMethod != null && requestParser.HttpMethod.Equals("GET"))
            {
                requestParser.Parser(requestString);
            }
            else 
            {
                return ;
            }
            Console.WriteLine(requestParser.HttpUrl);
            int dotIndex = requestParser.HttpUrl.LastIndexOf('.') + 1;
            
            if(dotIndex > 0)    
            {
                var requestHandler = FactoryHandler.CreateHandler(requestParser.HttpUrl, _clientSocket, ConfigurationSettings.AppSettings["Path"]);
                if (requestParser.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
                {
                    requestHandler.Get(requestParser.HttpUrl);
                }
                else
                {
                    Console.WriteLine("unimplimented mothod");
                    Console.ReadLine();
                }
            }
            else
            {
                TextRequestHandler htmlRequestHandler = new TextRequestHandler(_clientSocket , ConfigurationSettings.AppSettings["Path"]);
                htmlRequestHandler.Get(requestParser.HttpUrl);
            }
            StopClientSocket(_clientSocket);
        } 
        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }
        private string DecodeRequest(Socket clientSocket)
        {
            var receivedBufferlen = 0;    // specifying buffer length
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)    // if buffer gets full
            {
                Console.ReadLine();
            }
            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }
    }
}
