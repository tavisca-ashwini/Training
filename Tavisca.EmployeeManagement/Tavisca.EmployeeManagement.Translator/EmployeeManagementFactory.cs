using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;
using Tavisca.EmployeeManagement.ServiceContract;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class EmployeeManagementFactory
    {
        public static IEmployeeHandler CreateInstance(string title, string firstName, string lastName, string emailId)
        {
            var employeeHandler = new EmployeeManagementModel(title, firstName, lastName, emailId);
            return employeeHandler;
        }
    }
}
