using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        // Non nullable properties must contain a non null value whene exiting the constructor
        [Required]
        public int Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = null!;

        [Required]
        public ICollection<OrderItem> OrderItems { get; set; } = null!;
    }
}