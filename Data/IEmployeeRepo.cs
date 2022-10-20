using ResterauntAPI.Models;


namespace ResterauntAPI.Data
{
    public interface IEmployeeRepo
    {
        bool SaveChanges();

        IEnumerable<Employee> GetAllEmployees();

        Employee? GetEmployeeById(int id);

        void CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}