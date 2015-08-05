using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class CacheEmployeeStorage : IEmployeeStorage
    {
        public CacheEmployeeStorage(ICacheManager manager)
        {
            _innerStorage = new EmployeeStorage();
            _cacheManager = manager;
        }

        IEmployeeStorage _innerStorage;
        ICacheManager _cacheManager;

        readonly string KEYFORMAT = "emp.{0}";
        readonly string CACHEMANAGER = "employee";

        public Model.Employee Save(Model.Employee employee)
        {
            var result = _innerStorage.Save(employee);
            _cacheManager.Add(string.Format(KEYFORMAT, result.Id), result, CACHEMANAGER);
            return result;
        }

        public Model.Employee GetEmployee(string employeeId)
        {
            Model.Employee result;
            result = _cacheManager.Get(string.Format(KEYFORMAT, employeeId), CACHEMANAGER) as Model.Employee;
            if (result == null)
            {
                result = _innerStorage.GetEmployee(employeeId);
                _cacheManager.Add(string.Format(KEYFORMAT, employeeId), result, CACHEMANAGER);
            }
            return result;
        }

        public List<Model.Employee> GetAll()
        {
            return _innerStorage.GetAll();
        }
        
        public Model.Remark AddRemark(string EmployeeId, Model.Remark remark)
        {
            var result = _innerStorage.AddRemark(EmployeeId, remark);
            //_cacheManager.Add(string.Format(KEYFORMAT, result.Id), result, CACHEMANAGER);
            return result;
        }

        public Model.Employee Authenticate(Model.LoginDetails details)
        {
            return _innerStorage.Authenticate(details);
        }

        public int ChangePassword(Model.ModifyPassword modify)
        {
            return _innerStorage.ChangePassword(modify);
        }

        public Model.Pagination GetPage(string employeeId, string totalPages)
        {
            return _innerStorage.GetPage(employeeId , totalPages);
        }

        public List<Model.Remark> GetRemark(string employeeId)
        {
            return _innerStorage.GetRemark(employeeId);
        }
    }
}
