using RestaurantAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Data
{
    // Class instance can be used to query db, similar to ReactJS context providers
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> opt) : base(opt) { }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Order>()
        //         .Property(b => b.Status)
        //         .HasDefaultValueSql("InProgress");

        //     base.OnModelCreating(modelBuilder);
        // }

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;

    }
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> opt) : base(opt) { }

        public DbSet<Employee> Employees { get; set; } = null!;

    }
}