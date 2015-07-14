using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace WebServer
{
    class Listener
    {
        private bool _running = false;
        private TcpListener _listener;

        public Listener(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }
        public void Run()
        {
            Console.WriteLine("Waiting for Connection");
            _running = true;
            _listener.Start();
            while (_running)
            {
                if(_listener.Pending())
                {
                    Socket clientSocket = _listener.AcceptSocket();
                    Dispatcher dispatcher = new Dispatcher(clientSocket);
                    Thread thread = new Thread(new ThreadStart(dispatcher.HandleRequest));
                    thread.Start();
                    Console.WriteLine("Connected !!");
                }
            }
            _running = false;
            _listener.Stop();
        }
    }
}
