using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Translator;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeManager manager)
        {
            _manager = manager;
        }

        IEmployeeManager _manager;

        public DataContract.EmployeeResponse GetEmployee(string employeeId)
        {
            DataContract.EmployeeResponse employeeResponse = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.GetEmployee(employeeId);
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

        public DataContract.GetAllEmployeeResponse GetAll()
        {
            DataContract.GetAllEmployeeResponse getAll = new DataContract.GetAllEmployeeResponse();
            try
            {
                var result = _manager.GetAll();
                if (result == null) return null;
                getAll.GetAllEmployee = result.Select(employee => employee.ToDataContract()).ToList();
                return getAll;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                getAll.ResponseCodes.Code = "500";
                getAll.ResponseCodes.Message = ex.Message;
                return getAll;
            }
        }

        public DataContract.PaginationResponse GetPage(string employeeId, string totalPages)
        {
            DataContract.PaginationResponse pageResponse = new DataContract.PaginationResponse();
            try
            {
                var result = _manager.GetPage(employeeId, totalPages);
                if (result == null) return null;
                pageResponse.GetPaginationResponse = result.ToDataContract();
                return pageResponse;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                pageResponse.ResponseCodes.Code = "500";
                pageResponse.ResponseCodes.Message = ex.Message;
                return pageResponse;
            }
        }

        public DataContract.RemarkList GetRemark(string employeeId)
        {
            DataContract.RemarkList remarkAll = new DataContract.RemarkList();
            try
            {
                var result = _manager.GetRemark(employeeId);
                if (result == null) return null;
                remarkAll.RemarkListResponse = result.Select(remark => remark.ToDataContract()).ToList();
                return remarkAll;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                remarkAll.ResponseCodes.Code="500";
                remarkAll.ResponseCodes.Message = ex.Message;
                return remarkAll;
            }
        }
    }
}
