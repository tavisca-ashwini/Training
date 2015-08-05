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
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using System.Data.SqlClient;
using System.Data;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public Model.Employee Save(Model.Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = "Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#";
                    SqlCommand command = new SqlCommand("CreateEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("Id", employee.Id));
                    command.Parameters.Add(new SqlParameter("Title", employee.Title));
                    command.Parameters.Add(new SqlParameter("FirstName", employee.FirstName));
                    command.Parameters.Add(new SqlParameter("LastName", employee.LastName));
                    command.Parameters.Add(new SqlParameter("Email", employee.Email));
                    command.Parameters.Add(new SqlParameter("Phone", employee.Phone));
                    command.Parameters.Add(new SqlParameter("JoiningDate", employee.JoiningDate));
                    command.Parameters.Add(new SqlParameter("Password", employee.Password));
                    command.Parameters.Add(new SqlParameter("Designation", employee.Designation));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
            }
            return employee;
        }

        public Model.Remark AddRemark(string employeeId, Remark remark)
        {
            try
            {
                SqlConnection connect = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                connect.Open();
                SqlCommand commandRemark = new SqlCommand("AddRemark", connect);
                commandRemark.CommandType = CommandType.StoredProcedure;
                if (remark != null)
                {
                    commandRemark.Parameters.AddWithValue("@Id", employeeId);
                    commandRemark.Parameters.AddWithValue("@remark", remark.Text);
                    commandRemark.Parameters.AddWithValue("@remark_time", remark.CreateTimeStamp);
                    commandRemark.ExecuteNonQuery();
                }
                connect.Close();
                return remark;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public Model.Employee Authenticate(LoginDetails details)
        {
            Model.Employee employee = new Model.Employee();
            try
            {
                SqlConnection connect = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                connect.Open();
                SqlCommand commandAuth = new SqlCommand("Authenticate", connect);
                commandAuth.CommandType = CommandType.StoredProcedure;
                commandAuth.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar ));
                commandAuth.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
                commandAuth.Parameters["@Email"].Value = details.Email;
                commandAuth.Parameters["@Password"].Value = details.Password;

                SqlDataReader reader = commandAuth.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    employee.Id = reader[0].ToString();
                    employee.Title = reader[1].ToString();
                    employee.FirstName = reader[2].ToString();
                    employee.LastName = reader[3].ToString();
                    employee.Email = reader[4].ToString();
                    employee.Phone = reader[5].ToString();
                    employee.JoiningDate = Convert.ToDateTime(reader[7].ToString());
                    employee.Designation = reader[8].ToString();
                }
                else
                {
                    throw new System.Exception("Email or Password is incorrect");
                }
                connect.Close();
                return employee;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public int ChangePassword(ModifyPassword modify)
        {
            try
            {
                Model.Employee emp = new Model.Employee();
                SqlConnection connectPassword = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                connectPassword.Open();
                SqlCommand commandOldPassword = new SqlCommand("GetOldPassword", connectPassword);
                SqlCommand commandPassword = new SqlCommand("ChangePassword", connectPassword);
                commandPassword.CommandType = CommandType.StoredProcedure;
                commandPassword.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                commandPassword.Parameters["@Email"].Value = modify.Email;
                SqlDataReader reader = commandOldPassword.ExecuteReader();
                reader.Read();
                if (reader[0].ToString() == modify.OldPassword)
                {
                    reader.Close();
                    commandPassword.CommandType = CommandType.StoredProcedure;
                    commandPassword.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                    commandPassword.Parameters.Add(new SqlParameter("@OldPassword", SqlDbType.NVarChar));
                    commandPassword.Parameters.Add(new SqlParameter("@NewPassword", SqlDbType.NVarChar));
                    commandPassword.Parameters["@Email"].Value = modify.Email;
                    commandPassword.Parameters["@OldPassword"].Value = modify.OldPassword;
                    commandPassword.Parameters["@NewPassword"].Value = modify.NewPassword;
                    commandPassword.ExecuteNonQuery();
                    connectPassword.Close();
                    return 0;
                }
                else
                {
                    connectPassword.Close();
                    return 1;
                }
            }
            catch
            {
            }
            return 1;
        }

        public Model.Employee GetEmployee(string employeeId)
        {
            try
            {
                Model.Employee emp = new Model.Employee();
                SqlConnection conEmployee = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                conEmployee.Open();
                emp.Id = employeeId;
                SqlCommand cmdEmployee = new SqlCommand("select * from EmployeeRecord where Id='" + Int32.Parse(emp.Id) + "'", conEmployee);
                cmdEmployee.CommandType = CommandType.Text;
                SqlDataReader reader = cmdEmployee.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = reader[0].ToString();
                    emp.Title = reader[1].ToString();
                    emp.FirstName = reader[2].ToString();
                    emp.LastName = reader[3].ToString();
                    emp.Email = reader[4].ToString();
                    emp.Phone = reader[5].ToString();
                    emp.JoiningDate = Convert.ToDateTime(reader[7]);
                    emp.Designation = reader[8].ToString();
                }
                conEmployee.Close();
                SqlConnection conRemark = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                conRemark.Open();
                SqlCommand cmdGetRemark = new SqlCommand("select * from Emp_Remark where Id='" + emp.Id + "'", conRemark);
                SqlDataReader remarkReader = cmdGetRemark.ExecuteReader();
                List<Model.Remark> remarkList = new List<Model.Remark>();
                while (remarkReader.Read())
                {
                    Model.Remark remark = new Model.Remark();
                    remark.Text = remarkReader[1].ToString();
                    remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[2]);
                    remarkList.Add(remark);
                }
                emp.Remarks = remarkList;
                conEmployee.Close();
                return emp;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }
        public List<Model.Employee> GetAll()
        {
            try
            {
                List<Model.Employee> employeeList = new List<Model.Employee>();
                //Model.Employee allEmployee = new Model.Employee();
                SqlConnection conAllEmployee = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (conAllEmployee)
                {
                    SqlCommand commandGetAll = new SqlCommand("GetAll", conAllEmployee);
                    commandGetAll.CommandType = CommandType.StoredProcedure;
                    conAllEmployee.Open();
                    SqlDataReader readAllEmployee = commandGetAll.ExecuteReader();
                    while (readAllEmployee.Read())
                    {
                        Model.Employee allEmployee = new Model.Employee();
                        allEmployee.Id = readAllEmployee[0].ToString();
                        allEmployee.Title = readAllEmployee[1].ToString();
                        allEmployee.FirstName = readAllEmployee[2].ToString();
                        allEmployee.LastName = readAllEmployee[3].ToString();
                        allEmployee.Email = readAllEmployee[4].ToString();
                        allEmployee.Phone = readAllEmployee[5].ToString();
                        allEmployee.JoiningDate = Convert.ToDateTime(readAllEmployee[7]);
                        allEmployee.Designation = readAllEmployee[8].ToString();
                        employeeList.Add(allEmployee);
                    }
                    readAllEmployee.Close();
                }
                conAllEmployee.Close();
                return employeeList;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }
        public Pagination GetPage(string employeeId, string pageNumber)
        {
            try
            {
                Model.Pagination pagination = new Model.Pagination();
                SqlConnection connectPagination = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (connectPagination)
                {
                    SqlCommand commandCount = new SqlCommand("GetTotalCount", connectPagination);
                    //SqlCommand commandPage = new SqlCommand("Pagination", connectPagination);
                    commandCount.CommandType = CommandType.StoredProcedure;
                    commandCount.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                    commandCount.Parameters["@Id"].Value = employeeId;
                    connectPagination.Open();
                    SqlDataReader reader = commandCount.ExecuteReader();
                    while (reader.Read())
                    {
                        pagination.TotalPages = Convert.ToInt32(reader[0]).ToString();
                    }
                    reader.Close();
                }
                connectPagination.Close();

                List<Model.Remark> remarkList = new List<Model.Remark>();
                SqlConnection connectPage = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (connectPage)
                {
                    SqlCommand commandPage = new SqlCommand("Pagination", connectPage);
                    commandPage.CommandType = CommandType.StoredProcedure;
                    commandPage.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                    commandPage.Parameters["@Id"].Value = employeeId;
                    commandPage.Parameters.Add(new SqlParameter("@pageNumber", SqlDbType.Int));
                    commandPage.Parameters["@pageNumber"].Value = pageNumber;
                    connectPage.Open();
                    SqlDataReader reader = commandPage.ExecuteReader();
                    while (reader.Read())
                    {
                        Model.Remark remark = new Model.Remark();
                        remark.Text = reader[1].ToString();
                        remark.CreateTimeStamp = Convert.ToDateTime(reader[2]);
                        remarkList.Add(remark);
                    }
                    pagination.Remarks = remarkList;
                    reader.Close();
                }
                connectPage.Close();
                return pagination;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }
        private string GetFileName(string employeeId)
        {
            return string.Format(@"{0}\{1}.emp", Configurations.StoragePath, employeeId);
        }


        public List<Remark> GetRemark(string employeeId)
        {
            try
            {
                List<Model.Remark> remarks = new List<Remark>();
                SqlConnection connectRemark = new SqlConnection("Data Source=ASHWINIK;Initial Catalog=EmployeeManagement;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (connectRemark)
                {
                    SqlCommand commandRemark = new SqlCommand("GetRemarks", connectRemark);
                    commandRemark.CommandType = CommandType.StoredProcedure;
                    commandRemark.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                    commandRemark.Parameters["@Id"].Value = employeeId;
                    connectRemark.Open();
                    SqlDataReader reader = commandRemark.ExecuteReader();
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            Model.Remark remark = new Model.Remark();
                            remark.Text = reader[1].ToString();
                            remark.CreateTimeStamp = Convert.ToDateTime(reader[2]);
                            remarks.Add(remark);
                        }
                        reader.Close();
                    }
                    else
                    {
                        throw new System.Exception("Data not available");
                    }
                    reader.Close();
                }
                connectRemark.Close();
                return remarks;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
            
        }
    }
}