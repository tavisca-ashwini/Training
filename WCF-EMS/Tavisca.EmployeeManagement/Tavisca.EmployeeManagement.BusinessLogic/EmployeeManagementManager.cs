using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeManagementManager : IEmployeeManagementManager
    {
        public EmployeeManagementManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee Create(Employee employee)
        {
            employee.JoiningDate = DateTime.UtcNow;
            employee.Validate();
            //employee.Id = Guid.NewGuid().ToString();
            return _storage.Save(employee);
        }

        public Remark AddRemark(string employeeId, Remark remark)
        {
            remark.Validate();
            var employee = _storage.GetEmployee(employeeId);
            if (employee.Remarks == null) employee.Remarks = new List<Remark>();
            remark.CreateTimeStamp = DateTime.UtcNow;
            employee.Remarks.Add(remark);
            _storage.AddRemark(employeeId, remark);
            return remark;
        }

        public Employee Authenticate(LoginDetails details)
        {
            details.Validate();
            return _storage.Authenticate(details);
        }

        public int ChangePassword(ModifyPassword modify)
        {
            return _storage.ChangePassword(modify);
        }
    }
}
