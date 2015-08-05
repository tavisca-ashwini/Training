using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Model
{
    public class LoginDetails
    {
        public string Password { get; set; }

        public string Email { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Password))
                throw new Exception("Password cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(this.Email))
                throw new Exception("Email cannot be null or empty.");
        }
    }
}
