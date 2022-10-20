using ResterauntAPI.Models;


namespace ResterauntAPI.Data
{
    public interface IMenuItemRepo
    {
        bool SaveChanges();

        IEnumerable<MenuItem> GetAllMenuItems();

        MenuItem? GetMenuItemById(int id);

        void CreateMenuItem(MenuItem menuItem);

        void UpdateMenuItem(MenuItem menuItem);

        void DeleteMenuItem(MenuItem menuItem);
    }
}