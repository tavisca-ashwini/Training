using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CustomControl.Model
{
    [DataContract]
    public class LoginDetails
    {
            [DataMember]
        public string Email { get; set; }

            [DataMember]
        public string Password { get; set; }
    }
}