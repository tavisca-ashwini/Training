using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomControl.Model;
using Microsoft.JScript;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace CustomControl
{
    public partial class HR_HomePage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Title = TextBoxTitle.Text;
            employee.FirstName = TextBoxFirstName.Text;
            employee.LastName = TextBoxLastName.Text;
            employee.Email = TextBoxEmailID.Text; 
            employee.Phone = TextBoxContact.Text;
            
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Employee));
            ser.WriteObject(stream1, employee);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person object: ");
            string data = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee", "POST", data);
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            TextBoxTitle.Text = "";
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text="";
            TextBoxEmailID.Text="";
            TextBoxPassword.Text="";
            TextBoxContact.Text="";
        }
    }
}