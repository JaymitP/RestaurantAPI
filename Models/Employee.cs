using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Employee
    {
        // [Key] // Not required, but good practice to include
        public int Id { get; set; }

        public short EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}