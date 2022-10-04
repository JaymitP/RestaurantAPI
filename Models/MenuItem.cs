using System.ComponentModel.DataAnnotations;

namespace ResterauntAPI.Models
{
    public class MenuItem
    {
        [Key] // Not required, but good practice to include
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
    }
}