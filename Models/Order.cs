using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Order
    {
        [Key] // Not required, but good practice to include
        public int Id { get; set; }
        // Non nullable properties must contain a non null value whene exiting the constructor
        public int? Table { get; set; }

        public StatusEnum Status { get; set; }

        [Required]
        public IEnumerable<MenuItem> MenuItems { get; set; } = null!;

        [Required]
        public decimal Cost { get; set; }

        public IDelivery? Delivery { get; set; }

    }
    public enum StatusEnum
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public interface IDelivery
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string Name { get; set; }

        [Phone]
        [Required]
        public string Phone { get; set; }
    }

}