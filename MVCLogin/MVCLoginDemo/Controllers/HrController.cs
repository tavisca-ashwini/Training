using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLoginDemo.Models;
using LoginControl.Model;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace MVCLoginDemo.Controllers
{
    [Authorize]
    public class HrController : Controller
    {
        //
        // GET: /Hr/
        [AllowAnonymous]
        public ActionResult AddEmp()
        {
            if (HttpContext.User.IsInRole("HR") == false)
                return RedirectToAction("Login", "Account");
            ViewData["Status"] = "";
            return View();
        }

        [AllowAnonymous]
        public ActionResult SaveEmployee(Employee model)
        {
            model.JoiningDate = DateTime.UtcNow;
            EmployeeResponse response = model.CreateEmployee();
            if (string.Equals(response.ResponseCodes.Codes, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                ViewData["Status"] = "Employee Added Successfully";
                return View("AddEmp");
            }
            else
            {
                ViewData["Status"] = "Employee Creation Failed";
            }
            return View("AddEmp");
        }

        [AllowAnonymous]
        public ActionResult AddRemark()
        {
            if (HttpContext.User.IsInRole("HR") == false)
                return RedirectToAction("Login", "Account");
            ViewData["Status"] = "";
            var response = GetAllEmployeeResponse.GetEmpList();
            List<SelectListItem> allEmployeeList = new List<SelectListItem>();

            foreach (var employee in response.GetAllEmployee)
            {
                allEmployeeList.Add(new SelectListItem { Value = Convert.ToString(employee.Id), Text = employee.Id + ". " + employee.FirstName + "  " + employee.LastName });
            }
            ViewData["EmpList"] = allEmployeeList;
            return View();
        }

        public ActionResult SaveRemark(Remark remark)
        {
            string employeeId = Request["Employee"];
            RemarkResponse response = remark.AddRemark(employeeId , remark);
            ViewData["Status"] = response.ResponseCodes.Message;
            return View("AddRemark");
        }

        public ActionResult HrIndex()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDetails model,Employee employee)
        {
            LoginDetails details = new LoginDetails();
            details.Email = model.Email;
            details.Password = model.Password;
            var response = LoginDetailsResponse.LoginCredentials(details);
            if (response.ResponseCodes.Codes == "200")
            {
                HttpCookie cookie = new HttpCookie("Cookies");
                cookie["Email"] = model.Email;
                cookie["Designation"] = employee.Designation;
                cookie.Expires.AddDays(30);
                HttpContext.Response.Cookies.Add(cookie);
                
                if (string.Equals(employee.Title, "Hr", StringComparison.CurrentCultureIgnoreCase))
                        return RedirectToAction("HrIndex", "Hr");
                else
                {
                    TempData["Id"] = employee.Id;
                    return RedirectToAction("AddEmp", "Hr");
                }
            }
            return View("LoginView");
        }
    }
}