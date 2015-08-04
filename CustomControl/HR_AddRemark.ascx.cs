using CustomControl.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CustomControl
{
    public partial class HR_AddRemark : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SqlConnection connect = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (connect)
                {
                    SqlCommand command = new SqlCommand("DropDownList", connect);
                    command.CommandType = CommandType.StoredProcedure;
                    connect.Open();
                    EmployeeDropDownList.DataSource = command.ExecuteReader();
                    EmployeeDropDownList.DataTextField = "name";
                    EmployeeDropDownList.DataValueField = "Id";
                    EmployeeDropDownList.DataBind();
                }
                EmployeeDropDownList.Items.Insert(0, new ListItem("Add Employee", "0"));
            }
        }
        protected void AddRemarkButton_Click(object sender, EventArgs e)
        {
            
            Employee employee = new Employee();
            Remark remark = new Remark();
            employee.Id = Convert.ToInt32(EmployeeDropDownList.Text);
            remark.Text = TextAreaRemark.InnerText;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Remark));
            ser.WriteObject(stream1, remark);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person object: ");
            string data = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee/" + employee.Id + "/remark", "POST", data);
        }

        protected void EmployeeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}