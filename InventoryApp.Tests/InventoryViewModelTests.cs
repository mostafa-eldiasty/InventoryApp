using InventoryApp.Common.Interfaces.Repositories;
using InventoryApp.Common.Models;
using Moq;
using InventoryApp.ViewModels;

namespace InventoryApp.Tests
{
    public class InventoryViewModelTests
    {
        [Fact]
        public void LoadItemsCommand_ShouldLoadItemsFromRepository()
        {
            // Arrange
            var mockRepository = new Mock<IInventoryRepository>();
            var testItems = new List<InventoryItem>
            {
                new InventoryItem { Name = "Item 1", Category = "Cat A", StockQuantity = 10 },
                new InventoryItem { Name = "Item 2", Category = "Cat B", StockQuantity = 5 }
            };
            mockRepository.Setup(repo => repo.GetAll()).Returns(testItems);

            //Act
            var viewModel = new InventoryViewModel(mockRepository.Object);
            viewModel.LoadItemsCommand.Execute(null);

            // Assert
            Assert.Equal(2, viewModel.InventoryItems.Count);
            Assert.Equal("Item 1", viewModel.InventoryItems[0].Name);
            Assert.Equal("Item 2", viewModel.InventoryItems[1].Name);
        }

        [Fact]
        public void ShowEditCommand_ShouldDoNothing_WhenSelectedItemIsNull()
        {
            // Arrange
            var mockRepository = new Mock<IInventoryRepository>();
            var viewModel = new InventoryViewModel(mockRepository.Object);

            // Act
            var exception = Record.Exception(() =>
                viewModel.ShowEditCommand.Execute(null));

            //Assert
            Assert.Null(exception);
        }
    }
}
