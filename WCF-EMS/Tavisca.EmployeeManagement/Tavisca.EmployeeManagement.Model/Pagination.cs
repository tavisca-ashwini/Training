using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Model
{
    public class Pagination
    {
        public string TotalPages { get; set; }

        public List<Remark> Remarks { get; set; }
    }
}
