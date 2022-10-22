namespace RestaurantAPI.Models
{
    public class UserLogin
    {
        public short EmployeeId { get; set; }
        public string Password { get; set; } = null!;
    }
}