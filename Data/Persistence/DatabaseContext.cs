using RestaurantAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Data.Persistence
{
    // Class instance can be used to query db, similar to ReactJS context providers
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.Status)
                .HasDefaultValue("InProgress");
            modelBuilder.Entity<Order>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<MenuItem>().HasData
            (
                new MenuItem { Id = 1, Name = "Spaghetti Bolognese", Price = 5.99m, Description = "Spaghetti served with a sauce made from tomatoes, minced beef, garlic, wine and herbs" },
                new MenuItem { Id = 2, Name = "Margherita Pizza", Price = 6.99m, Description = "A traditional Margherita pizza made with a tomato sauce with fresh tomatoes, mozzarella cheese and basil." },
                new MenuItem { Id = 3, Name = "French Fries", Price = 3.99m, Description = "Perfect French fry with a crunchy exterior and a light, fluffy interior." }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;

    }
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> opt) : base(opt) { }

        public DbSet<Employee> Employees { get; set; } = null!;

    }
}