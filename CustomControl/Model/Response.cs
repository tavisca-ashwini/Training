using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomControl.Model
{
    public class Response
    {
        public StatusCodes ResponseCodes { get; set; }

        public Response()
        {
            this.ResponseCodes = StatusCodes.Success;
        }
    }
}