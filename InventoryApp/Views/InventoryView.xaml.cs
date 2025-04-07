using InventoryApp.Common.Models;
using InventoryApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp.Views
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : Window
    {
        public InventoryView(InventoryViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Items.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var item = (InventoryItem)obj;
            return item.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void StockStatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Items == null) return;

            var selected = (StockStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (selected)
            {
                case "In Stock":
                    Items.Items.Filter = FilterDropDownInStockMethod;
                    break;
                case "Low Stock":
                    Items.Items.Filter = FilterDropDownLowStockMethod;
                    break;
                case "All":
                default:
                    Items.Items.Filter = FilterDropDownAllStockMethod;
                    break;
            }
        }

        private bool FilterDropDownInStockMethod(object obj)
        {
            var item = (InventoryItem)obj;
            return item.StockQuantity > 5;
        }

        private bool FilterDropDownLowStockMethod(object obj)
        {
            var item = (InventoryItem)obj;
            return item.StockQuantity <= 5;
        }

        private bool FilterDropDownAllStockMethod(object obj)
        {
            return true;
        }
    }
}
