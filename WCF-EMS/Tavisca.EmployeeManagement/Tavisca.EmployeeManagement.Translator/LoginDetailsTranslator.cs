using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class LoginDetailsTranslator
    {
        public static Model.LoginDetails ToDomainModel(this DataContract.LoginDetails details)
        {
            if (details == null) return null;
            return new Model.LoginDetails()
            {
                Email = details.Email,
                Password = details.Password
            };
        }

        public static DataContract.LoginDetails ToDataContract(this Model.LoginDetails details)
        {
            if (details == null) return null;
            return new DataContract.LoginDetails()
            {
                Email = details.Email,
                Password = details.Password
            };
        }
    }
}