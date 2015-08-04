using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using CustomControl.Model;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;

namespace CustomControl
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            LoginDetails details = new LoginDetails();
            details.Email = UserIdText.Text;
            details.Password = PasswordText.Text;
            HttpClient client = new HttpClient();
            var response = client.UploadData<LoginDetails, Employee>("http://localhost:53412/EmployeeManagementService.svc/login", details);
            HttpCookie cookie = new HttpCookie("LoginDetails");
            cookie["Email"] = response.Email;
            cookie["Password"] = response.Password;
            Response.Cookies.Add(cookie);

            if (response.Equals(null))
            {
                Response.Write("Invalid Entries");
            }
            else
            {
                if (string.Equals(response.Designation.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("http://localhost:49722/HR_Page.aspx");
                }
                else
                {
                    Response.Redirect("http://localhost:49722/Employee_Page.aspx");
                }
            }
        }
    }
}