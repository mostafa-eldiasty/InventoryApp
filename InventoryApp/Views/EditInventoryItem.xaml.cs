using InventoryApp.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace InventoryApp.Views
{
    /// <summary>
    /// Interaction logic for EditInventoryItem.xaml
    /// </summary>
    public partial class EditInventoryItem : Window
    {
        public EditInventoryItem(EditInventoryItemViewModel editItemViewModel)
        {
            InitializeComponent();
            DataContext = editItemViewModel;
        }

        private void StockQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex _numericRegex = new Regex("[^0-9]+");
            e.Handled = _numericRegex.IsMatch(e.Text);
        }

        private void StockQuantity_DisablePaste(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }
    }
}
