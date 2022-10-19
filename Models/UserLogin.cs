using System.ComponentModel.DataAnnotations;

namespace ResterauntAPI.Models
{
    public class UserLogin
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}