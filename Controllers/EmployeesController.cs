

// Controller is used to handle HTTP requests and responses. Also accesses the repository.
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{

    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;

        public EmployeesController(IEmployeeRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<Employee>> GetAllEmployees()
        {
            var employees = _repository.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetEmployeesById")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            _repository.CreateEmployee(employee);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employee employee)
        {
            var employeeFromRepo = _repository.GetEmployeeById(id);

            if (employeeFromRepo == null)
            {
                return NotFound();
            }

            // _repository.UpdateEmployee(employeeFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeFromRepo = _repository.GetEmployeeById(id);

            if (employeeFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEmployee(employeeFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}