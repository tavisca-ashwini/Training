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
    public class GetAllEmployeeResponse : Response
    {
        [DataMember]
        public List<Employee> GetAllEmployee { get; set; }
    }
}
