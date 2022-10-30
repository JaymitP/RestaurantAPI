using System.ComponentModel.DataAnnotations;
using RestaurantAPI.Models;

namespace RestaurantAPI.DTOs
{
    public class OrderItemCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = null!;
    }
}