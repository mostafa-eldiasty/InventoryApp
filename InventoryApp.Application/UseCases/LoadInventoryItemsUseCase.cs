using InventoryApp.Application.Interfaces.Repositories;
using InventoryApp.Domain.Entites;

namespace InventoryApp.Application.UseCases
{
    public class LoadInventoryItemsUseCase
    {
        private readonly IInventoryRepository _repository;

        public LoadInventoryItemsUseCase(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public List<InventoryItem> Execute()
        {
            return _repository.GetAll();
        }
    }
}
