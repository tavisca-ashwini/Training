using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogin.Authenticate
{
    public class AuthenticatePrincipal : IAuthentiactePrincipal
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Designation { get; set; }
        
        public IIdentity Identity { get; private set; }

        public AuthenticatePrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public bool IsInRole(string role)
        {
            return Identity != null && Identity.IsAuthenticated &&
           !string.IsNullOrWhiteSpace(role) && string.Equals(role, Designation, StringComparison.OrdinalIgnoreCase);
        }
    }
}
