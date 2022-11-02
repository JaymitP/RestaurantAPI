

using RestaurantAPI.Data.Domain;
using RestaurantAPI.Models;

namespace RestaurantAPI.Data.Persistence
{
    public class SqlEmployeeRepo : IEmployeeRepo
    {

        private readonly EmployeesContext _context;

        public SqlEmployeeRepo(EmployeesContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList().OrderBy(e => e.Id);
        }

        public Employee? GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }
        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}