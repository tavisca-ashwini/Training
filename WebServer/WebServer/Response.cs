using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebServer
{
    public class Response
    {
        private Byte [] _data = null;
        private Response(String , Byte[] _data)
        {
        }

        public static Request FromServer(Request request)
        {

        }
        public void Post(System.Net.Sockets.NetworkStream stream)
        {
            Stream.Write();
        }
    }
}
