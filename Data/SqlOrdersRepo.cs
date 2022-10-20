using ResterauntAPI.Models;

namespace ResterauntAPI.Data
{
    public class SqlOrdersRepo : IOrdersRepo
    {
        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return new List<Order>() { new Order() { Id = 1, Table = 12 } };
        }

        public Order? GetOrderById(int id)
        {
            return new Order() { Id = id, Table = new Random().Next(50) };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}