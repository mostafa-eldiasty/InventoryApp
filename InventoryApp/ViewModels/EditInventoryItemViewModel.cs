using InventoryApp.Common.Interfaces.Repositories;
using InventoryApp.Commands;
using InventoryApp.Common.Models;
using System.Windows.Input;

namespace InventoryApp.ViewModels
{
    public class EditInventoryItemViewModel
    {
        #region props
        public int Id { get; set; }
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
        public EditInventoryItemViewModel(IInventoryRepository repository, InventoryItem _selectedItem, InventoryViewModel currentInventoryVm)
		{
            Id = _selectedItem.Id;
            Name = _selectedItem.Name;
            Category = _selectedItem.Category;
            StockQuantity = _selectedItem.StockQuantity;
            LastUpdated = _selectedItem.LastUpdated;

            _repository = repository;
            _currentInventoryVm = currentInventoryVm;
            EditItemCommand = new RelayCommand(EditItem);
        }
        #endregion

        #region ICommands
        public ICommand EditItemCommand { get; set; }
        private void EditItem(object obj)
        {
            InventoryItem item = _repository.GetById(Id);
            item.Name = Name;
            item.Category = Category;
            item.StockQuantity = StockQuantity;
            item.LastUpdated = LastUpdated;

            _repository.Edit(item);
            _currentInventoryVm.LoadItemsCommand.Execute(item);
        }
        #endregion
    }
}