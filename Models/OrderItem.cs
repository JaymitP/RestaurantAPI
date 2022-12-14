using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class OrderItem
    {
        [Key] // Not required, but good practice to include
        public int Id { get; set; }

        // Foreign keys such as MenuItemId and OrderId are auto generated by EF Core
        [Required]
        [ForeignKey("MenuItemId")]
        public MenuItem MenuItem { get; set; } = null!;

        [Required]
        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }
    }
}