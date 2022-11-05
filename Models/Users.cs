using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
    public class Employee : User
    {

        [Required]
        public short EmployeeId { get; set; }

        [Required]
        public string Role { get; set; } = null!;
    }
    public class Customer : User
    {
        [Required]
        public ICollection<Order>? Orders { get; set; }
    }

}