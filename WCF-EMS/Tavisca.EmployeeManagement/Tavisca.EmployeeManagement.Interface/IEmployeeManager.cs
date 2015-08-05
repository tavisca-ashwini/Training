using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;


namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeManager
    {
        Employee GetEmployee(string employeeId);

        List<Employee> GetAll();

        Pagination GetPage(string employeeId, string totalPages);

        List<Remark> GetRemark(string employeeId);
    }
}
