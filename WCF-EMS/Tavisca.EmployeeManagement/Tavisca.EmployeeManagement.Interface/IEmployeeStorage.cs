using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeStorage
    {
        Employee Save(Employee employee);

        Employee GetEmployee(string employeeId);

        List<Employee> GetAll();

        Employee Authenticate(LoginDetails details);

        Remark AddRemark(string employeeId, Remark remark);

        int ChangePassword(ModifyPassword modify);

        Pagination GetPage(string employeeId, string totalPages);

        List<Remark> GetRemark(string employeeId);
    }
}
