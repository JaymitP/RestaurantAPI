namespace RestaurantAPI.Models
{
    public class UserLogin
    {
        public short UserId { get; set; }
        public string Password { get; set; } = null!;
    }
}