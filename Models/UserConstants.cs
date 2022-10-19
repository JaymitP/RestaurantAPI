using System.ComponentModel.DataAnnotations;

namespace ResterauntAPI.Models
{
    public class UserConstants
    {
        public static List<Employee> Users = new List<Employee>();
        // {
        //     new Employee() { EmployeeId = 12,Password = "j", Role = "Admin"},
        //     new Employee() { Username = "a",Password = "a", Role = "Waiter"},
        // }
    }
}