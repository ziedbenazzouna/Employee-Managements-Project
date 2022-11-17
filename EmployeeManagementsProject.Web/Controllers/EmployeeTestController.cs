using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OA_DataAccess;
using OA_Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementsProject.Web.Controllers
{
    public class EmployeeTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
            => await _context.Employees.ToArrayAsync();

        [HttpPost]
        public async Task<Employee> Add([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
