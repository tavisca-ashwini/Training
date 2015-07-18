using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tavisca.EmployeeManagement.FileHandler
{
    public class FileStorage
    {
        public void SaveEmployeeInfo(string jsonString, string id)
        {
            if (File.Exists(@"C:\EmployeeID\EmployeeId.txt"))
            {
                File.AppendAllText(@"C:\EmployeeID\EmployeeId.txt", id + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(@"C:\EmployeeID\EmployeeId.txt", id + Environment.NewLine);
            }
            File.WriteAllText(@"C:\EmployeeDeatils\"+ id + ".txt", jsonString);
        }

        public string RetrievedById(string id)
        {
            var jsonString = File.ReadAllText(@"C:\EmployeeDeatils\" + id + ".txt");
            return jsonString;
        }

        public List<string> GetAll()
        {
            var allEmployeeId = File.ReadAllText(@"C:\EmployeeID\AllEmployeeID.txt");
            string[] employeeIds = allEmployeeId.Split('\n');
            List<string> listOfEmployee = new List<string>();
            for (int i = 0; i < employeeIds.Length; i++)
            {
                var jsonString = File.ReadAllText(@"D:\EmployeeDeatils\" + employeeIds[i] + ".txt");
                listOfEmployee.Add(jsonString);
            }
            return listOfEmployee;
        }
        public List<string> RetrievedAll()
        {
            DirectoryInfo directory = new DirectoryInfo(@"D:\EmployeeDeatils");
            var employeeFiles = directory.GetFiles(".txt");
            List<string> employeeIds = new List<string>();

            foreach (var fileData in employeeFiles)
            {
                employeeIds.Add(fileData.Name);
            }
            return employeeIds;
        }
    }
}