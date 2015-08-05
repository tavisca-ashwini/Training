using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Translator;
using Tavisca.EmployeeManagement.EnterpriseLibrary;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeAuthenticationService : IEmployeeAuthenticationService
    {
        public EmployeeAuthenticationService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.Employee Authenticate(DataContract.LoginDetails details)
        {
            try
            {
                var result = _manager.Authenticate(details.ToDomainModel());
                if (result == null) return null;
                return result.ToDataContract();
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }
    }
}
