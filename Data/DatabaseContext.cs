using RestaurantAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Data
{
    // Class instance can be used to query db, similar to ReactJS context providers
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> opt) : base(opt) { }

        public DbSet<Order> Orders { get; set; } = null!;

    }
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> opt) : base(opt) { }

        public DbSet<Employee> Employees { get; set; } = null!;

    }
    public class MenuItemsContext : DbContext
    {
        public MenuItemsContext(DbContextOptions<MenuItemsContext> opt) : base(opt) { }

        public DbSet<MenuItem> MenuItems { get; set; } = null!;

    }
}