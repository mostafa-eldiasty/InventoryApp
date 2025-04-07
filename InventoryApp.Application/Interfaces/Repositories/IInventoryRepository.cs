using InventoryApp.Domain.Entites;

namespace InventoryApp.Application.Interfaces.Repositories
{
    public interface IInventoryRepository
    {
        List<InventoryItem> GetAll();
        InventoryItem GetById(int id);
        void Add(InventoryItem item);
        void Edit(InventoryItem item);
    }
}
