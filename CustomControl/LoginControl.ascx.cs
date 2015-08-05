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
            if (!IsPostBack)
            {
                if (Request.Cookies["Email"] != null)
                    UserIdText.Text = Request.Cookies["Email"].Value;
                if (Request.Cookies["Password"] != null)
                    PasswordText.Attributes.Add("value", Request.Cookies["Password"].Value);
                if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
                    RememberMeCheckbox.Checked = true;
            } 
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            LoginDetails details = new LoginDetails();
            details.Email = UserIdText.Text;
            details.Password = PasswordText.Text;
            HttpClient client = new HttpClient();

            var response = client.UploadData<LoginDetails, EmployeeResponse>("http://localhost:53412/EmployeeManagementService.svc/login", details);
            
            
            if (response.ResponseCodes.Codes=="500")
            {
                Response.Write(response.ResponseCodes.Message);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("LoginDetails");
                cookie["Email"] = response.EmployeeRequest.Email;
                cookie["Password"] = response.EmployeeRequest.Password;
                Response.Cookies.Add(cookie);

                if (RememberMeCheckbox.Checked == true)
                {
                    Response.Cookies["Email"].Value = response.EmployeeRequest.Email; ;
                    Response.Cookies["Email"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["Password"].Value = response.EmployeeRequest.Password;
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(1);
                }
                
                if (string.Equals(response.EmployeeRequest.Designation.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("http://localhost:49722/HR_Page.aspx");
                }
                else
                {
                    Response.Redirect("http://localhost:49722/Employee_Page.aspx");
                }
            }
        }

        protected void PasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}