using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class Order
    {
        [Key] // Not required, but good practice to include
        public int Id { get; set; }

        public int? Table { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public ICollection<OrderItem> OrderItems { get; set; } = null!;

        [Required]
        public decimal Cost { get; set; }

        [ForeignKey("DeliveryId")]
        public int? DeliveryId { get; set; }

        public Delivery? Delivery { get; set; }
    }
}