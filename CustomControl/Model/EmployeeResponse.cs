using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomControl.Model
{
    public class EmployeeResponse : Response
    {
        public Employee EmployeeRequest { get; set; }
    }
}