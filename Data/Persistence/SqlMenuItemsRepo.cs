using RestaurantAPI.Data.Domain;
using RestaurantAPI.Models;

namespace RestaurantAPI.Data.Persistence
{
    public class SqlMenuItemRepo : IMenuItemRepo
    {
        private readonly OrdersContext _context;

        public SqlMenuItemRepo(OrdersContext context)
        {
            _context = context;
        }

        public void CreateMenuItem(MenuItem MenuItems)
        {
            if (MenuItems == null)
            {
                throw new ArgumentNullException(nameof(MenuItems));
            }
            _context.MenuItems.Add(MenuItems);
        }

        public void DeleteMenuItem(MenuItem MenuItems)
        {
            if (MenuItems == null)
            {
                throw new ArgumentNullException(nameof(MenuItems));
            }
            _context.MenuItems.Remove(MenuItems);
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _context.MenuItems.ToList().OrderBy(o => o.Id);
        }

        public MenuItem? GetMenuItemById(int id)
        {
            return _context.MenuItems.FirstOrDefault(o => o.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMenuItem(MenuItem MenuItems)
        {
            // Nothing
        }
    }
}