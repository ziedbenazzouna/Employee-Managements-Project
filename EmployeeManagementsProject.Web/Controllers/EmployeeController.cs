using Microsoft.AspNetCore.Mvc;
using OA_Service;

namespace EmployeeManagementsProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _iEmployeeService;

        public EmployeeController(IEmployeeService iEmployeeService)
        {
            _iEmployeeService = iEmployeeService;
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employees = _iEmployeeService.GetAllEmployees();
            return View(employees);
        }
    }
}
