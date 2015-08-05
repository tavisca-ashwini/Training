using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tavisca.EmployeeManagement.DataContract
{
    [DataContract]
    public class StatusCodes
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        public static StatusCodes Success { get { return new StatusCodes() { Code = "200", Message = "OK" }; } }
    }
}
