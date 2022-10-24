using RestaurantAPI.Models;

namespace RestaurantAPI.Data
{
    public class SqlOrdersRepo : IOrdersRepo
    {
        private readonly OrdersContext _context;

        public SqlOrdersRepo(OrdersContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Remove(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.ToList().OrderBy(o => o.Id);
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public Order? GetOrderByTable(int table)
        {
            return _context.Orders.FirstOrDefault(o => o.Table == table);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateOrder(Order order)
        {
            // Nothing
        }
    }
}