using BL_WebApi2_BasicAuth.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL_WebApi2_BasicAuth.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUserName(string userName, string password);
        Employee GetEmployeeById(int id);
        HttpResponseMessage PostEmployee(Employee employee);
        string PutEmployee(Employee employee);
        string DeleteEmployeeById(int id);

    }
}
