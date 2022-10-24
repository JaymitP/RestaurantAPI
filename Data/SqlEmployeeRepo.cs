

using RestaurantAPI.Models;

namespace RestaurantAPI.Data
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
            throw new NotImplementedException();
        }

        public Employee? GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
        public void CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
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