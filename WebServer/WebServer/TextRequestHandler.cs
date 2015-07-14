using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    class TextRequestHandler : IProcessor
    {
        public Socket ClientSocket = null;
        private string _contentPath;
        private RegistryKey _registryKey = Registry.ClassesRoot;
        private Encoding _charEncoder = Encoding.UTF32;
        private FileHandler _fileHandler = null;

        public TextRequestHandler(Socket clientSocket , string contentPath)
        {
            _contentPath = contentPath;
            ClientSocket = clientSocket;
            FileHandler FileHandler = new FileHandler (contentPath);
        }
        public void Get(string requestFile)  
        {
            if (FileHandler.FileExists(requestFile))
                SendResponse(ClientSocket, _fileHandler.ReadFile(requestFile), "200 Ok", GetTypeOfFile(_registryKey, (_contentPath + requestFile)));
            else
                SendErrorResponce(ClientSocket);
        }
        public void DoPost()
        {
            throw new NotImplementedException();
        }
        private string GetTypeOfFile(RegistryKey registryKey, string fileName)
        {
            RegistryKey fileClass = registryKey.OpenSubKey(Path.GetExtension(fileName));
            return fileClass.GetValue("Content Type").ToString();
        }
        private void SendResponse(Socket clientSocket, byte[] byteContent, string responseCode, string contentType)
        {
            try
            {
                byte[] byteHeader = CreateHeader(responseCode, byteContent.Length, contentType);
                clientSocket.Send(byteHeader);
                clientSocket.Send(byteContent);
                clientSocket.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void SendErrorResponce(Socket clientSocket)
        {
            byte[] emptyByteArray = new byte[0];
            SendResponse(clientSocket, emptyByteArray, "404 Not Found", "text/html");
        }
        private byte[] CreateHeader(string responseCode, int contentLength, string contentType)
        {
            return _charEncoder.GetBytes("HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Simple Web Server\r\n"
                                  + "Content-Length: " + contentLength + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
        }
        public void Post()
        {
            throw new NotImplementedException();
        }
    }
}
