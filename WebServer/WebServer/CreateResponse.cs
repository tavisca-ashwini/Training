using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Win32;
using System.IO;

namespace WebServer
{
    public class CreateResponse
    {
        RegistryKey registryKey = Registry.ClassesRoot;
        public Socket clientSocket1 = null;
        private Encoding _charEncoder = Encoding.UTF32;
        private string _contentPath;
        public FileHandler FileHandler;

        public CreateResponse(Socket clientSocket, string contentPath)
        {
            _contentPath = contentPath;
            clientSocket1 = clientSocket;
            FileHandler = new FileHandler(_contentPath);
        }
        public void RequestUrl(string requestedFile)
        {
            int dotIndex = requestedFile.LastIndexOf('.') + 1;
            if (dotIndex > 0)
            {
                if (FileHandler.DoesFileExists(requestedFile))    //If yes check existence of the file
                    SendResponse(clientSocket1, FileHandler.ReadFile(requestedFile), "200 Ok", GetTypeOfFile(registryKey, (_contentPath + requestedFile)));
                else
                    SendErrorResponce(clientSocket1);
            }
            else
            {
                if (FileHandler.DoesFileExists("\\index.htm"))
                    SendResponse(clientSocket1, FileHandler.ReadFile("\\index.htm"), "200 Ok", "text/html");
                else if (FileHandler.DoesFileExists("\\index.html"))
                    SendResponse(clientSocket1, FileHandler.ReadFile("\\index.html"), "200 Ok", "text/html");
                else
                    SendErrorResponce(clientSocket1);
            }
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
            catch
            {
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
    }
}
