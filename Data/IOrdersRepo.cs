using ResterauntAPI.Models;


namespace ResterauntAPI.Data
{
    // Interface will contain all of the methods that the repository should provide to the consumer.
    public interface IOrdersRepo
    {
        bool SaveChanges();

        IEnumerable<Order> GetAllOrders();

        Order? GetOrderById(int id);

        void CreateOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(Order order);
    }
}