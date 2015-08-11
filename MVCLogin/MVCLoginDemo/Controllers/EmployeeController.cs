using LoginControl.Model;
using MVCLogin.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLoginDemo.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FetchRemark(int page)
        {
            int totalRemarks = 0, totalPages = 0, pageSize = 2;
            PaginationResponse pageRemarks = GetAllRemarks.GetRemarkList((HttpContext.User as AuthenticatePrincipal).Id, page.ToString());
            totalRemarks = pageRemarks.PaginationData.TotalPages;
            totalPages = (totalRemarks / pageSize) + ((totalRemarks % pageSize) > 0 ? 1 : 0);
            List<Remark> remarks = pageRemarks.PaginationData.Remarks.ToList();

            ViewBag.TotalRecords = totalRemarks;
            ViewBag.PageSize = 2;
            return View(remarks);
        }

        public ActionResult IndexPage()
        {
            if (HttpContext.User.IsInRole("HR") == true)
                return RedirectToAction("AddRemark", "Hr");
            else
                return RedirectToAction("FetchRemark", "Employee");
        }
    }
}
