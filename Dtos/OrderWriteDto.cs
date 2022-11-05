using System.ComponentModel.DataAnnotations;
using RestaurantAPI.Models;

namespace RestaurantAPI.DTOs
{
    public class OrderWriteDto
    {
        public int? Table { get; set; }

        [Required]
        public ICollection<OrderItem> OrderItems { get; set; } = null!;

        [Required]
        public decimal Cost { get; set; }

        public Delivery? Delivery { get; set; }
    }
}