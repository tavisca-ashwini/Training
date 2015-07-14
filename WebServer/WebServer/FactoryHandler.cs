using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    class FactoryHandler
    {
        private List<string> _fileExtension = new List<string>();
        public FactoryHandler()
        {
            _fileExtension.Add(".html");
            _fileExtension.Add(".htm");
            _fileExtension.Add(".css");
            _fileExtension.Add(".js");
            _fileExtension.Add(".ico");
            _fileExtension.Add(".txt");
        }
        public IProcessor CreateHandler(string url, Socket clientSocket, string contentPath)
        {
            IProcessor processor = null;
            string extension = GetExtensionFromUrl(url);

            if (_fileExtension.Contains(extension))
            {

                switch (extension)
                {

                    case ".html":
                        processor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".htm":
                        processor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".css":
                        processor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".js":
                        processor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".txt":
                        processor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    default :
                        processor = new FileNotFoundErrorHandler(clientSocket);
                        break;
                }
            }
            else 
            {
                processor = new InternalErrorHandler(clientSocket);
            }
            return processor;
        }
        private string GetExtensionFromUrl(string url)
        {
           return url.Substring(url.LastIndexOf('.'));
        }
    }
}
