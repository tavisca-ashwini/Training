using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebInvoke(Method = "GET" , UriTemplate = "/get_record/(id)" ,ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Employee Get(string employeeId);

        [WebInvoke(Method = "GET", UriTemplate = "/get_record_allEmployee", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Employee> GetAll();
    } 
}




