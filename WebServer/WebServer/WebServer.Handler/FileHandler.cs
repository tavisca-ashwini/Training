using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;
using WebServer.Interfaces;

namespace WebServer.Handler
{
    class FileHandler : IProcessor
    {
        private static string _typesIncluded = ConfigurationManager.AppSettings["file-handler"];

        public Response Process(Request request)
        {
            var response = new Response(request);

            if (string.IsNullOrWhiteSpace(request.TypeAccepted)) response.ContentType = "text/html";
            else response.ContentType = request.TypeAccepted.Split(',')[0];

            if (File.Exists(request.Path) == false)
            {
                throw Errors.ResourceNotFound();
            }
            response.Body = File.ReadAllBytes(request.Path);
            return response;
        }
    }
}
