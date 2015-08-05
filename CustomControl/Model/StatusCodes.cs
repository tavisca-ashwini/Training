using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomControl.Model
{
    public class StatusCodes : Response
    {
        public string Codes { get; set; }

        public string Message { get; set; }

        public static StatusCodes Success { get { return new StatusCodes() { Codes = "500", Message = "OK" }; } }
    }
}