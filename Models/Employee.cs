using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Employee
    {
        [Key] // Not required, but good practice to include
        public int Id { get; set; }

        [Required]
        public short EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;
    }
}