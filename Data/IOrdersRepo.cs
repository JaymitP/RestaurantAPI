using ResterauntAPI.Models;


namespace ResterauntAPI.Data
{
    public interface IOrdersRepo
    {
        bool SaveChanges();

        IEnumerable<Order> GetAllOrders();

        Order? GetOrderById(int id);

        Order? GetOrderByTable(int table);

        void CreateOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(Order order);
    }
}