using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;
using Tavisca.EmployeeManagement.Model;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Translator;

namespace Tavisca.EmployeeManagement.Implementation
{
    class EmployeeGetImplementor : IEmployeeService
    {
        public Employee Get(string employeeId)
        {
            EmployeeManagementModel employeeModel = EmployeeManagementModel.GetEmployeeById(employeeId);
            return TranslatorEmployee.EmployeeTranslator(employeeModel);
        }

        public List<Employee> GetAll()
        {
            List<EmployeeManagementModel> listEmployeeModel = EmployeeManagementModel.AllEmployeeDetails();
            return TranslatorEmployee.EmployeeTranslator(listEmployeeModel);
        }
    }
}
