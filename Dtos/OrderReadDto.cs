using ResterauntAPI.Models;

namespace ResterauntAPI.DTOs
{
    // Defines the structure of the data that is returned to the client
    public class EmployeeOrderReadDto
    {
        // Non nullable properties must contain a non null value whene exiting the constructor
        public int? Table { get; set; }

        public StatusEnum Status { get; set; }

        public IEnumerable<MenuItem> Items { get; set; } = null!;

        public decimal Cost { get; set; }

        public IDelivery? Delivery { get; set; }
    }
    // Currently the same as for employee
    public class CustomerOrderReadDto
    {
        public int? Table { get; set; }

        public StatusEnum Status { get; set; }

        public IEnumerable<MenuItem> Items { get; set; } = null!;

        public decimal Cost { get; set; }

        public IDelivery? Delivery { get; set; }
    }
}