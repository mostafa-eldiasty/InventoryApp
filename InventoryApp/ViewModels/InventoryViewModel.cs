using InventoryApp.Commands;
using InventoryApp.Common.Interfaces.Repositories;
using InventoryApp.Common.Models;
using InventoryApp.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace InventoryApp.ViewModels
{
    public class InventoryViewModel
    {
        #region Props
        public InventoryItem SelectedItem { get; set; }
        public ObservableCollection<InventoryItem> InventoryItems { get; set; } = new();
        #endregion

        #region Fields
        private readonly IInventoryRepository _repository;
        #endregion

        #region Constructor
        public InventoryViewModel(IInventoryRepository repository)
        {
            _repository = repository;
            LoadItemsCommand = new RelayCommand(LoadItems);
            ShowCreateNewCommand = new RelayCommand(ShowCreateNew);
            ShowEditCommand = new RelayCommand(ShowEdit);

            LoadItemsCommand.Execute(null);
        }
        #endregion

        #region ICommands
        public ICommand LoadItemsCommand { get; }
        public ICommand ShowCreateNewCommand { get; }
        public ICommand ShowEditCommand { get; }
        
        private void LoadItems(object obj)
        {
            var items = _repository.GetAll() ?? new();
            InventoryItems.Clear();
            foreach (var item in items)
            {
                InventoryItems.Add(item);
            }
        }

        private void ShowCreateNew(object obj)
        {
            var addItemVm = new AddInventoryItemViewModel(_repository, this);

            AddInventoryItem addItemWin = new AddInventoryItem(addItemVm)
            {
                Owner = obj as Window,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            addItemWin.Show();
        }

        private void ShowEdit(object obj)
        {
            if (SelectedItem == null)
                return;

            var editItemVm = new EditInventoryItemViewModel(_repository, SelectedItem, this);

            EditInventoryItem editItemWin = new EditInventoryItem(editItemVm)
            {
                Owner = obj as Window,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            editItemWin.Show();
        }
        #endregion
    }
}
