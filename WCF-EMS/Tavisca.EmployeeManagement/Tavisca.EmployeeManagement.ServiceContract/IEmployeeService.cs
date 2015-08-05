using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebGet(UriTemplate = "/employee/{employeeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        EmployeeResponse GetEmployee(string employeeId);

        [WebGet(UriTemplate = "/employee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        GetAllEmployeeResponse GetAll();

        [WebGet(UriTemplate = "/pagination/{employeeId}/{totalPages}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PaginationResponse GetPage(string employeeId, string totalPages);

        [WebGet(UriTemplate = "/{employeeId}/remark", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        RemarkList GetRemark(string employeeId);
    }
}
