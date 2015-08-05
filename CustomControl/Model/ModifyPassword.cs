using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomControl.Model
{
    public class ModifyPassword
    {
        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}