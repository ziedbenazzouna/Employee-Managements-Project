using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OA_DataAccess;
using OA_Service;
using System.Collections.Generic;
using System.IO;
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

        [Route("Export")]
        [HttpGet]
        public IActionResult ExportExcel()
        {
            var employees = _iEmployeeService.GetAllEmployees();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "FullName";
                worksheet.Cell(currentRow, 3).Value = "EMPCode";
                worksheet.Cell(currentRow, 4).Value = "Mobile";
                worksheet.Cell(currentRow, 5).Value = "Position";
                foreach (var employee in employees)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = employee.Id;
                    worksheet.Cell(currentRow, 2).Value = employee.FullName;
                    worksheet.Cell(currentRow, 3).Value = employee.EMPCode;
                    worksheet.Cell(currentRow, 4).Value = employee.Mobile;
                    worksheet.Cell(currentRow, 5).Value = employee.Position;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "users.xlsx");
                }
            }
        }

    }
}
