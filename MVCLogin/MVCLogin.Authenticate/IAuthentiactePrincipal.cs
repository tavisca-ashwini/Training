using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogin.Authenticate
{
    public interface IAuthentiactePrincipal : System.Security.Principal.IPrincipal
    {
         string Id { get; set; }

         string FirstName { get; set; }

         string LastName { get; set; }

         string Email { get; set; }

         string Designation { get; set; }
    }
}
