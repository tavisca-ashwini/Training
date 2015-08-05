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
    public class EmployeeManagementService : IEmployeeManagementService
    {
        public EmployeeManagementService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.EmployeeResponse Create(DataContract.Employee employee)
        {
            DataContract.EmployeeResponse employeeResponse = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Create(employee.ToDomainModel());
                if (result == null) return null;
                employeeResponse.EmployeeRequest = result.ToDataContract();
                return employeeResponse;
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                employeeResponse.ResponseCodes.Code = "500";
                employeeResponse.ResponseCodes.Message = ex.Message;
                return employeeResponse;
            }
        }

        public DataContract.RemarkResponse AddRemark(string employeeId, DataContract.Remark remark)
        {
            DataContract.RemarkResponse remarkResponse = new DataContract.RemarkResponse();
            try
            {
                var result = _manager.AddRemark(employeeId, remark.ToDomainModel());
                if (result == null) return null;
                remarkResponse.RemarkRequest = result.ToDataContract();
                return remarkResponse;
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                remarkResponse.ResponseCodes.Code = "500";
                remarkResponse.ResponseCodes.Message = ex.Message;
                return remarkResponse;
            }
        }

        public DataContract.EmployeeResponse Authenticate(DataContract.LoginDetails details)
        {
            DataContract.EmployeeResponse employeeResponse = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Authenticate(details.ToDomainModel());
                if (result == null) return null;
                employeeResponse.EmployeeRequest = result.ToDataContract();
                return employeeResponse;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                employeeResponse.ResponseCodes.Code = "500";
                employeeResponse.ResponseCodes.Message = ex.Message;
                return employeeResponse;
            }
        }

        public DataContract.ModifyPasswordResponse ChangePassword(DataContract.ModifyPassword modify)
        {
            DataContract.ModifyPasswordResponse modifyResponse = new DataContract.ModifyPasswordResponse();
            try
            {
                var result = _manager.ChangePassword(modify.ToDomainModel());
                DataContract.Employee employee = new DataContract.Employee();
                if (result.Equals(1)) return modifyResponse;
                else
                {
                    throw new System.Exception("You entered wrong password");
                }
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                modifyResponse.ResponseCodes.Code = "500";
                modifyResponse.ResponseCodes.Message = ex.Message;
                return modifyResponse;
            }
        }
    }
}
