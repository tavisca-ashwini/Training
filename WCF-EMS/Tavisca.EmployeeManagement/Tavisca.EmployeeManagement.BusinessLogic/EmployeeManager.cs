using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeManager : IEmployeeManager
    {
        public EmployeeManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee GetEmployee(string employeeId)
        {
            return _storage.GetEmployee(employeeId);
        }

        public List<Employee> GetAll()
        {
            return _storage.GetAll();
        }

        public Pagination GetPage(string employeeId, string totalPages)
        {
            return _storage.GetPage(employeeId, totalPages);
        }

        public List<Remark> GetRemark(string employeeId)
        {
            return _storage.GetRemark(employeeId);
        }
    }
}
