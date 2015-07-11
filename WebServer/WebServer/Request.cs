using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class Request
    {
        public String Type { get; set; }
        public String Host { get; set; }
        public String Url { get; set; }

        private Request(String type, String host, String url)
        {
            Type = type;
            Host = host;
            Url = url;
        }

        public static Request GetRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
            {
                return null;
            }
            String[] splittedUrl = request.Split(' ');
            String type = splittedUrl[0];
            String host = splittedUrl[4];
            String url = splittedUrl[1];

            return new Request(type,host,url);
        }
    }
}
