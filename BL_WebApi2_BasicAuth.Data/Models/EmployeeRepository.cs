using BL_WebApi2_BasicAuth.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;

namespace BL_WebApi2_BasicAuth.Data.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static string conStr = string.Empty;
        static EmployeeRepository()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", baseDir);
            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString3"].ConnectionString;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlCommand cmd = new SqlCommand())
            {
                Employee employee = new Employee();
                string sql = string.Empty;
                sql += " select * from [employees] ";
                sql += " order by EmployeeID; ";

                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                DataTable dt = DataAccess.GetDataTable(conStr, cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    employee = new Employee
                    {
                        EmployeeID = Convert.ToInt32(dr["EmployeeID"] == System.DBNull.Value ? 0 : dr["EmployeeID"]),
                        LastName = Convert.ToString(dr["LastName"] == System.DBNull.Value ? String.Empty : dr["LastName"]),
                        FirstName = Convert.ToString(dr["FirstName"] == System.DBNull.Value ? String.Empty : dr["FirstName"]),
                        Title = Convert.ToString(dr["Title"] == System.DBNull.Value ? String.Empty : dr["Title"]),
                        BirthDate = Convert.ToDateTime(dr["BirthDate"] == System.DBNull.Value ? DateTime.MinValue : dr["BirthDate"]),
                        HireDate = Convert.ToDateTime(dr["HireDate"] == System.DBNull.Value ? DateTime.MinValue : dr["HireDate"]),
                        Address = Convert.ToString(dr["Address"] == System.DBNull.Value ? String.Empty : dr["Address"]),
                        City = Convert.ToString(dr["City"] == System.DBNull.Value ? String.Empty : dr["City"]),
                        Region = Convert.ToString(dr["Region"] == System.DBNull.Value ? String.Empty : dr["Region"]),
                        PostalCode = Convert.ToString(dr["PostalCode"] == System.DBNull.Value ? String.Empty : dr["PostalCode"]),
                        Country = Convert.ToString(dr["Country"] == System.DBNull.Value ? String.Empty : dr["Country"]),
                        HomePhone = Convert.ToString(dr["HomePhone"] == System.DBNull.Value ? String.Empty : dr["HomePhone"]),
                        Extension = Convert.ToString(dr["Extension"] == System.DBNull.Value ? String.Empty : dr["Extension"]),
                        ReportsTo = Convert.ToInt32(dr["ReportsTo"] == System.DBNull.Value ? 0 : dr["ReportsTo"]),
                        Notes = Convert.ToString(dr["Notes"] == System.DBNull.Value ? String.Empty : dr["Notes"])
                    };
                    employees.Add(employee);
                }
                return employees;
            }
        }
        public Employee GetEmployeeByUserName(string userName, string password)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                Employee employee = new Employee();
                string sql = string.Empty;
                sql += " select top 1 * from [employees] ";
                sql += " where lastName=@lastName AND firstName=@firstName;";

                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lastName", userName);     //Davolio
                cmd.Parameters.AddWithValue("@firstName", password);    //Nancy
                DataTable dt = DataAccess.GetDataTable(conStr, cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    employee = new Employee
                    {
                        EmployeeID = Convert.ToInt32(dr["EmployeeID"] == System.DBNull.Value ? 0 : dr["EmployeeID"]),
                        LastName = Convert.ToString(dr["LastName"] == System.DBNull.Value ? String.Empty : dr["LastName"]),
                        FirstName = Convert.ToString(dr["FirstName"] == System.DBNull.Value ? String.Empty : dr["FirstName"]),
                        Title = Convert.ToString(dr["Title"] == System.DBNull.Value ? String.Empty : dr["Title"]),
                        BirthDate = Convert.ToDateTime(dr["BirthDate"] == System.DBNull.Value ? DateTime.MinValue : dr["BirthDate"]),
                        HireDate = Convert.ToDateTime(dr["HireDate"] == System.DBNull.Value ? DateTime.MinValue : dr["HireDate"]),
                        Address = Convert.ToString(dr["Address"] == System.DBNull.Value ? String.Empty : dr["Address"]),
                        City = Convert.ToString(dr["City"] == System.DBNull.Value ? String.Empty : dr["City"]),
                        Region = Convert.ToString(dr["Region"] == System.DBNull.Value ? String.Empty : dr["Region"]),
                        PostalCode = Convert.ToString(dr["PostalCode"] == System.DBNull.Value ? String.Empty : dr["PostalCode"]),
                        Country = Convert.ToString(dr["Country"] == System.DBNull.Value ? String.Empty : dr["Country"]),
                        HomePhone = Convert.ToString(dr["HomePhone"] == System.DBNull.Value ? String.Empty : dr["HomePhone"]),
                        Extension = Convert.ToString(dr["Extension"] == System.DBNull.Value ? String.Empty : dr["Extension"]),
                        ReportsTo = Convert.ToInt32(dr["ReportsTo"] == System.DBNull.Value ? 0 : dr["ReportsTo"]),
                        Notes = Convert.ToString(dr["Notes"] == System.DBNull.Value ? String.Empty : dr["Notes"])
                    };
                }
                return employee;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            string strSql = string.Empty;
            strSql += " SELECT * FROM [employees] WHERE EmployeeID = @EmployeeID ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 50;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("@EmployeeID", id);
            DataTable dt = DataAccess.GetDataTable(conStr, cmd);
            foreach (DataRow dr in dt.Rows)
            {
                employee = new Employee
                {
                    EmployeeID = Convert.ToInt32(dr["EmployeeID"] == System.DBNull.Value? 0 : dr["EmployeeID"]),
                    LastName = Convert.ToString(dr["LastName"] == System.DBNull.Value? String.Empty : dr["LastName"]),
                    FirstName = Convert.ToString(dr["FirstName"] == System.DBNull.Value? String.Empty : dr["FirstName"]),
                    Title = Convert.ToString(dr["Title"] == System.DBNull.Value? String.Empty : dr["Title"]),
                    BirthDate = Convert.ToDateTime(dr["BirthDate"] == System.DBNull.Value? DateTime.MinValue : dr["BirthDate"]),
                    HireDate = Convert.ToDateTime(dr["HireDate"] == System.DBNull.Value? DateTime.MinValue : dr["HireDate"]),
                    Address = Convert.ToString(dr["Address"] == System.DBNull.Value? String.Empty : dr["Address"]),
                    City = Convert.ToString(dr["City"] == System.DBNull.Value? String.Empty : dr["City"]),
                    Region = Convert.ToString(dr["Region"] == System.DBNull.Value? String.Empty : dr["Region"]),
                    PostalCode = Convert.ToString(dr["PostalCode"] == System.DBNull.Value? String.Empty : dr["PostalCode"]),
                    Country = Convert.ToString(dr["Country"] == System.DBNull.Value? String.Empty : dr["Country"]),
                    HomePhone = Convert.ToString(dr["HomePhone"] == System.DBNull.Value? String.Empty : dr["HomePhone"]),
                    Extension = Convert.ToString(dr["Extension"] == System.DBNull.Value? String.Empty : dr["Extension"]),
                    ReportsTo = Convert.ToInt32(dr["ReportsTo"] == System.DBNull.Value? 0 : dr["ReportsTo"]),
                    Notes = Convert.ToString(dr["Notes"] == System.DBNull.Value? String.Empty : dr["Notes"])
                };
            }
            return employee;
        }

        public HttpResponseMessage PostEmployee(Employee employee)
        {
            string resp = "success";
            int recordAffected = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "INSERT INTO [dbo].[Employees] ";
                sql += "( LastName,FirstName,Title,BirthDate,HireDate,Address,City, ";
                sql += " Region,PostalCode,Country,HomePhone,Extension,Notes) VALUES ";
                sql += "( @LastName,@FirstName,@Title,@BirthDate,@HireDate,@Address,@City, ";
                sql += " @Region,@PostalCode,@Country,@HomePhone,@Extension,@Notes)";

                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@Title", employee.Title);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Region", employee.Region);
                cmd.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                cmd.Parameters.AddWithValue("@Country", employee.Country);
                cmd.Parameters.AddWithValue("@HomePhone", employee.HomePhone);
                cmd.Parameters.AddWithValue("@Extension", employee.Extension);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                recordAffected = DataAccess.ExecuteCommand(conStr, cmd);
                resp = (recordAffected > 0) ? "New Id is " + recordAffected.ToString() : "insert error";
            }

            //return
            return new HttpResponseMessage(HttpStatusCode.Created)
            {
                //Content = new StringContent( res, System.Text.Encoding.UTF8, "text/html" )
                Content = new StringContent(resp, System.Text.Encoding.UTF8, "application/json") //header only
            };
            //return new HttpResponseMessage(HttpStatusCode.Created) { 
            //    Content = new StringContent("success") 
            //};

        }

        public string PutEmployee(Employee employee)
        {
            string res = "success";
            int recordAffected = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = "UPDATE [dbo].[employees] SET ";
                sql += " LastName = @LastName, FirstName = @FirstName, Title = @Title, BirthDate = @BirthDate, ";
                sql += " HireDate = @HireDate, Address = @Address, City = @City, Region = @Region, ";
                sql += " PostalCode = @PostalCode, Country = @Country, HomePhone = @HomePhone, ";
                sql += " Extension = @Extension, Notes = @Notes ";
                sql += " WHERE EmployeeId = @EmployeeID";

                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@Title", employee.Title);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Region", employee.Region);
                cmd.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                cmd.Parameters.AddWithValue("@Country", employee.Country);
                cmd.Parameters.AddWithValue("@HomePhone", employee.HomePhone);
                cmd.Parameters.AddWithValue("@Extension", employee.Extension);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                recordAffected = DataAccess.ExecuteCommand(conStr, cmd);
            }
            if (recordAffected < 1) res = "update error";
            return res;
        }


        public string DeleteEmployeeById(int id)
        {
            string res = string.Empty;
            int recordAffected = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "DELETE FROM [employees] WHERE EmployeeID = @EmployeeID";
                    cmd.CommandTimeout = 50;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@EmployeeID", id);
                    recordAffected = DataAccess.ExecuteCommand(conStr, cmd);
                }
            }
            catch
            {
                res = String.Format("{0} is not deleted.", id);
            }
            res = recordAffected > 0 ? String.Format("{0} is deleted.", id) : "update error";
            return res;
        }



    }
}
