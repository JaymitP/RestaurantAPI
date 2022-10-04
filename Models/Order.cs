using System.ComponentModel.DataAnnotations;

namespace ResterauntAPI.Models
{
    public class Order
    {
        [Key] // Not required, but good practice to include
        public int Id { get; set; }
        // Non nullable properties must contain a non null value whene exiting the constructor
        public int? Table { get; set; }

        public StatusEnum Status { get; set; }

        [Required]
        public IEnumerable<MenuItem> Items { get; set; } = null!;

        [Required]
        public decimal Cost { get; set; }

        public IDelivery? Delivery { get; set; }

    }
    // [Flags]
    // [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum StatusEnum
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public interface IDelivery
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

}