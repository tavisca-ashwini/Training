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
    public class PaginationResponse : Response
    {
        [DataMember]
        public Pagination GetPaginationResponse { get; set; }
    }
}
