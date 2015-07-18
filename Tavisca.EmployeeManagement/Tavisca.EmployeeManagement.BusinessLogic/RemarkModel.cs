using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.FileHandler;

namespace Tavisca.EmployeeManagement.Model
{
    public class RemarkModel : IRemarkHandler
    {
        public string Text { get; set; }
        public string UtcTime { get; set;}
        public RemarkModel(string text)
        {
            this.Text = text;
        }

        public string GetUtcTime()
        {
            DateTime time = DateTime.UtcNow;
            return time.ToString();
        }

        public static void InsertRemark(RemarkModel remark, string id)
        {
            var jsonString = JsonConvert.SerializeObject(remark);
            FileStorage fileStorage = new FileStorage();
            EmployeeManagementModel employeeModel = JsonConvert.DeserializeObject<EmployeeManagementModel>(fileStorage.RetrievedById(id));
            employeeModel.EmpId = jsonString;
            jsonString = JsonConvert.SerializeObject(employeeModel);
            fileStorage.SaveEmployeeInfo(jsonString, id);
        }
    }
}
