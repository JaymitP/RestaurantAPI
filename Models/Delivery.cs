using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Order OrderId { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
