using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.FileHandler;
using Newtonsoft.Json;
using Microsoft.JScript;


namespace Tavisca.EmployeeManagement.Model
{
    public class EmployeeManagementModel : IEmployeeHandler
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        //public string EmployeeId { get; set; }
        public string EmpId { get; set; }

        public EmployeeManagementModel(string title, string firstName, string lastName, string emailId)
        {
            // TODO: Complete member initialization
            this.Title = title;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.EmpId = "";
        }
        public string GenerateEmployeeId()
        {
            string employeeId = string.Format(@"{0}", Guid.NewGuid());
            return employeeId;
        }
        
        public static void InsertEmployeeDataIntoFile(EmployeeManagementModel employeeModel)
        {
            var JsonString = JsonConvert.SerializeObject(employeeModel);
            FileStorage employeeInfo = new FileStorage();
            employeeInfo.SaveEmployeeInfo(JsonString, employeeModel.EmpId);
        }

        public static EmployeeManagementModel GetEmployeeById(string id)
        {
            FileStorage employeeFile = new FileStorage();
            EmployeeManagementModel employeeModel = JsonConvert.DeserializeObject<EmployeeManagementModel>(employeeFile.RetrievedById(id));
            return employeeModel;
        }

        public static List<EmployeeManagementModel> AllEmployeeDetails()
        {
            List<EmployeeManagementModel> employeeList = new List<EmployeeManagementModel>();
            FileStorage employeeFile = new FileStorage();
            List<string> employeeID = employeeFile.RetrievedAll();
            for(int i = 0;i < employeeID.Count ; i++)
                employeeList.Add(GetEmployeeById(employeeID[i]));
            return employeeList; 
        }
    }
}
