using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class ModifyPasswordTranslator
    {
        public static Model.ModifyPassword ToDomainModel(this DataContract.ModifyPassword modify)
        {
            if (modify == null) return null;
            return new Model.ModifyPassword()
            {
               
                Email = modify.Email,
                OldPassword = modify.OldPassword,
                NewPassword = modify.NewPassword,
            };
        }
        public static int ToDataContract(this Model.ModifyPassword modifier)
        {
            if (modifier == null) return 0;
            return 1;
        }
    }
}
