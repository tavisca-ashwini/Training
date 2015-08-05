using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomControl.Model;


namespace CustomControl
{
    public partial class Employee_FetchRemark : System.Web.UI.UserControl
    {
        string employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Pagination pagination = new Pagination();
                HttpClient client = new HttpClient();
                var pageResponse = client.GetData<Pagination>("http://localhost:53412/EmployeeService.svc/pagination/1/" +GridViewRemark.PageIndex);
                HttpCookie cookie = new HttpCookie("LoginDetails");
                employeeId = cookie["emp_Id"];
                GridViewRemark.VirtualItemCount = pageResponse.TotalPages;
                GridViewRemark.DataSource = pageResponse.Remarks;
                GridViewRemark.DataBind();
                DataBindRepeater(GridViewRemark.PageIndex, GridViewRemark.PageSize, pageResponse.TotalPages);
            }
        }

        private void DataBindRepeater(int totalRecords, int pageIndex, int pageSize)
        {
            int totalPages = totalRecords / pageSize;
            if ((totalRecords % pageSize) != 0)
                totalPages += 1;
            List<ListItem> pageData = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 0; i <= totalPages; i++)
                    pageData.Add(new ListItem(i.ToString(), i.ToString(), (i != pageIndex + 1)));
            }
            RepeaterPage.DataSource = pageData;
            RepeaterPage.DataBind();
        }

        protected void GridViewRemark_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRemark.PageIndex = e.NewPageIndex;
            Pagination pagination = new Pagination();
            HttpClient client = new HttpClient();
            var pageResponse = client.GetData<Pagination>("http://localhost:53412/EmployeeService.svc/pagination/1/" + GridViewRemark.PageIndex);
            HttpCookie cookie = new HttpCookie("LoginDetails");
            employeeId = cookie["emp_Id"];
            GridViewRemark.DataSource = pageResponse.Remarks;
            GridViewRemark.DataBind();
            DataBindRepeater(GridViewRemark.PageIndex, GridViewRemark.PageSize, pageResponse.TotalPages);
        }

        protected void LinkButtonPage_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            GridViewRemark.PageIndex = pageIndex;
            Pagination pagination = new Pagination();
            HttpClient client = new HttpClient();
            var pageResponse = client.GetData<Pagination>("http://localhost:53412/EmployeeService.svc/pagination/1/"+GridViewRemark.PageIndex);
            pageIndex -= 1;
            HttpCookie cookie = new HttpCookie("LoginDetails");
            employeeId = cookie["emp_Id"];
            GridViewRemark.DataSource = pageResponse.Remarks;
            GridViewRemark.DataBind();
            DataBindRepeater(pageIndex, GridViewRemark.PageSize, pageResponse.TotalPages);
        }
    }
}