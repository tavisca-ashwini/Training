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
        public void start()
        {
            Thread serverThread = new Thread(new ThreadStart(Run));
            serverThread.Start();
        }
        Dispatcher dispatch = new Dispatcher();
        public void Run()
        {
            Console.WriteLine("Waiting for Connection");
            _running = true;
            _listener.Start();
            while (_running)
            {
                TcpClient client = _listener.AcceptTcpClient();
                Console.WriteLine("Connected");
                dispatch.HandleClient(client);
                client.Close();
            }
            _running = false;
            _listener.Stop();
        }
    }
}
