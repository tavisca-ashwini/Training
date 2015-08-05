using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tavisca.EmployeeManagement.ServiceTests.Model
{
    [DataContract]
    internal class Pagination
    {
        [DataMember]
        public int TotalPages { get; set; }

        [DataMember]
        public List<Remark> Remarks { get; set; }
    }
}
