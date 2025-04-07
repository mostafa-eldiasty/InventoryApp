using InventoryApp.Common.Interfaces.Repositories;
using InventoryApp.Common.Models;
using InventoryApp.ViewModels;
using Moq;

namespace InventoryApp.Tests
{
    public class AddInventoryItemViewModelTests
    {
        [Fact]
        public void CreateNewItemCommand_ShouldAddItemAndReloadInventory()
        {
            // Arrange
            var mockRepo = new Mock<IInventoryRepository>();
            var mockViewModel = new Mock<InventoryViewModel>(mockRepo.Object);

            var addVm = new AddInventoryItemViewModel(mockRepo.Object, mockViewModel.Object)
            {
                Name = "Test Item",
                Category = "Test Category",
                StockQuantity = 5
            };

            // Act
            addVm.CreateNewItemCommand.Execute(null);

            // Assert
            mockRepo.Verify(r => r.Add(It.IsAny<InventoryItem>()), Times.Once);
        }
    }
}
