using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomControl.Model;

namespace CustomControl
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            TextBoxEmail.Text = "";
            TextBoxOldPassword.Text = "";
            TextBoxConfirmPassword.Text = "";
            TextBoxNewPassword.Text = "";
        }

        protected void SubmitPasswordButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
           
            employee.Email = TextBoxEmail.Text; 
        
            if(TextBoxNewPassword.Text != TextBoxConfirmPassword.Text)
            {
                Console.WriteLine("Invalid entries");
            }
        }


    }
}