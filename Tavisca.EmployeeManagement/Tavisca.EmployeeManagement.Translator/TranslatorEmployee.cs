using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Translator
{
    public class TranslatorEmployee
    {
        public static EmployeeManagementModel EmployeeModelGenerator(Employee employee)
        {
            var employeeModel = EmployeeManagementFactory.CreateInstance(employee.Title, employee.FirstName, employee.LastName, employee.EmailId);
            return employeeModel as EmployeeManagementModel;
        }
        public static RemarkModel RemarkGenerator(Remark remark)
        {
            return null;
        }
        public static Employee EmployeeTranslator(EmployeeManagementModel employeeModel)
        {
            Employee employeeFromDataContract = new Employee();
            employeeFromDataContract.Id = employeeModel.EmpId;
            employeeFromDataContract.Title = employeeModel.Title;
            employeeFromDataContract.FirstName = employeeModel.FirstName;
            employeeFromDataContract.LastName = employeeModel.LastName;
            employeeFromDataContract.EmailId = employeeModel.EmpId;
            return employeeFromDataContract;
        }

        public static List<Employee> EmployeeTranslator(List<EmployeeManagementModel> listEmployeeModel)
        {
            List<Employee> allEmployees = new List<Employee>();
            for (int i = 0; i < listEmployeeModel.Count-1; i++)
            { 
                Employee employeeFromDataContract = new Employee();
                employeeFromDataContract.Id = listEmployeeModel[i].EmpId;
                employeeFromDataContract.Title = listEmployeeModel[i].Title;
                employeeFromDataContract.FirstName = listEmployeeModel[i].FirstName;
                employeeFromDataContract.LastName = listEmployeeModel[i].LastName;
                employeeFromDataContract.EmailId = listEmployeeModel[i].EmpId;
                allEmployees.Add(employeeFromDataContract);
            }
            return allEmployees;
        }
    }
}