using InventoryApp.Common.Interfaces.Repositories;
using InventoryApp.Common.Models;
using InventoryApp.Infrastructure.Data;

namespace InventoryApp.Infrastructure.Persistence.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<InventoryItem> GetAll()
        {
            return _context.InventoryItems.ToList();
        }

        public InventoryItem? GetById(int id)
        {
            return _context.InventoryItems.Find(id);
        }

        public void Add(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            _context.SaveChanges();
        }

        public void Edit(InventoryItem item)
        {
            _context.InventoryItems.Update(item);
            _context.SaveChanges();
        }
    }
}
