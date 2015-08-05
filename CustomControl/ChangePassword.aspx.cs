using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomControl.Model;

namespace CustomControl
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitPasswordButton_Click(object sender, EventArgs e)
        {
            ModifyPassword modify = new ModifyPassword();
            HttpClient client = new HttpClient();
            HttpCookie cookie = new HttpCookie("Logindetails");
            modify.Email = cookie["Email"];
            modify.OldPassword = TextBoxOldPassword.Text;
            modify.NewPassword = TextBoxNewPassword.Text;
            var response = client.UploadData<ModifyPassword, ModifyPasswordResponse>("http://localhost:53412/EmployeeManagementService.svc/changePassword", modify);
            Response.Write(response.ResponseCodes.Message);

            if (TextBoxConfirmPassword.Text != TextBoxNewPassword.Text)
            {
                Response.Write(response.ResponseCodes.Message);
            }
        }

        protected void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            TextBoxOldPassword.Text = "";
            TextBoxNewPassword.Text = "";
            TextBoxConfirmPassword.Text = ""; 
        }
    }
}