using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tavisca.EmployeeManagement.DataContract
{
    [Serializable]
    [DataContract]
    public class Response
    {
        [DataMember]
        public StatusCodes ResponseCodes { get; set; }

        public Response()
        {
            this.ResponseCodes = StatusCodes.Success;
        }
    }
}
