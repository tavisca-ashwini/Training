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
    public class RemarkList : Response
    {
        [DataMember]
        public List<Remark> RemarkListResponse { get; set; }
    }
}
