using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class MenuItemCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Range(0.01, int.MaxValue, ErrorMessage = "The price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = null!;
    }
}