using Microsoft.AspNetCore.Mvc;
using OA_DataAccess;
using OA_Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementsProject.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _iEmployeeService;

        public EmployeeController(IEmployeeService iEmployeeService)
        {
            _iEmployeeService = iEmployeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        {
            var employees = _iEmployeeService.GetAllEmployees();
            return employees;
        }

        [HttpPost]
        public Employee Add([FromBody] Employee e)
        {
            var employee = _iEmployeeService.AddEmployee(e);
            return employee;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            if (id != 0)
            {
                _iEmployeeService.DeleteEmployee(id);
            }
        }
    }
}
