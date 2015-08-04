using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CustomControl.Model
{
    public class Pagination
    {
            [DataMember]
        public int TotalPages { get; set; }

            [DataMember]
        public List<Remark> Remarks { get; set; }
    }
}