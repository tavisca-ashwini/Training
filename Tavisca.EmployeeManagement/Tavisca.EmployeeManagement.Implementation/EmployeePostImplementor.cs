using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tavisca.EmployeeManagement.DataContract;
using Tavisca.EmployeeManagement.Model;
using Tavisca.EmployeeManagement.ServiceContract;


namespace Tavisca.EmployeeManagement.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmployeePostImplementor : IEmployeeManagementService
    {
        public Employee Create(Employee employee)
        {
            EmployeeManagementModel employeeManagementModel = Translator.TranslatorEmployee.EmployeeModelGenerator(employee);
            string employeeId = employeeManagementModel.GenerateEmployeeId();
            employeeManagementModel.EmpId = employeeId;
            EmployeeManagementModel.InsertEmployeeDataIntoFile(employeeManagementModel);
            return employee;
        }

        public Remark AddRemark(string employeeId, Remark remark)
        {
            RemarkModel remarkModel = Translator.TranslatorEmployee.RemarkGenerator(remark);
            string creationDate = remarkModel.GetUtcTime();
            remarkModel.UtcTime = creationDate;
            RemarkModel.InsertRemark(remarkModel, employeeId);
            return remark;
        }
    }
}
