using InventoryApp.Common.Models;

namespace InventoryApp.Common.Interfaces.Repositories
{
    public interface IInventoryRepository
    {
        List<InventoryItem> GetAll();
        InventoryItem GetById(int id);
        void Add(InventoryItem item);
        void Edit(InventoryItem item);
    }
}
