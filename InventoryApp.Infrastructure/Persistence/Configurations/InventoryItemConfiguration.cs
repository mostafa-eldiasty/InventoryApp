using InventoryApp.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryApp.Infrastructure.Persistence.Configurations
{
    class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Category).HasMaxLength(100);
            builder.Property(x => x.LastUpdated).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAddOrUpdate();

            builder.ToTable("InventoryItem", t =>
            {
                t.HasCheckConstraint("CK_InventoryItem_StockQuantity_Min", $"[StockQuantity] >= 0");
            });

            builder.HasData(
            new InventoryItem { Id = 1, Name = "Laptop", Category = "Electronics", StockQuantity = 5 },
            new InventoryItem { Id = 2, Name = "Television", Category = "Electronics", StockQuantity = 15 },
            new InventoryItem { Id = 3, Name = "Table", Category = "Furniture", StockQuantity = 25 },
            new InventoryItem { Id = 4, Name = "Chair", Category = "Furniture", StockQuantity = 35 });
        }
    }
}
