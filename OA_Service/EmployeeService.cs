using OA_DataAccess;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _repository.GetById(Id);
        }

        public Employee AddEmployee(Employee employee)
        {
            _repository.Add(employee);
            return GetEmployeeById(employee.Id);
        }
    }
}
