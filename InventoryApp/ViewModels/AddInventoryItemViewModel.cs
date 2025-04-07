using InventoryApp.Common.Interfaces.Repositories;
using InventoryApp.Commands;
using InventoryApp.Common.Models;
using System.Windows.Input;

namespace InventoryApp.ViewModels
{
    public class AddInventoryItemViewModel
    {
        #region props
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        #endregion

        #region Fields
        private readonly IInventoryRepository _repository;
        private readonly InventoryViewModel _currentInventoryVm;
        #endregion

        #region Constructor
        public AddInventoryItemViewModel(IInventoryRepository repository, InventoryViewModel currentInventoryVm)
        {
            _repository = repository;
            _currentInventoryVm = currentInventoryVm;
            CreateNewItemCommand = new RelayCommand(CreateNewItem);
        }
        #endregion

        #region ICommand
        public ICommand CreateNewItemCommand { get; set; }
        private void CreateNewItem(object obj)
        {
            InventoryItem newItem = new InventoryItem() { Name = Name, Category = Category, StockQuantity = StockQuantity, LastUpdated = LastUpdated};
            _repository.Add(newItem);
            _currentInventoryVm.LoadItemsCommand.Execute(newItem);
        }
        #endregion
    }
}
