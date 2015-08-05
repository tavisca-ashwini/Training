using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.DataContract
{
    [Serializable]
    [DataContract]
    public class ModifyPasswordResponse : Response
    {
        [DataMember]
        public ModifyPassword ModifyPasswordRequest { get; set; }
    }
}
