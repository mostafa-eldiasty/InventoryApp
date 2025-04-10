﻿// <auto-generated />
using System;
using InventoryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryApp.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250406015940_AddInventoryItemTable")]
    partial class AddInventoryItemTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventoryApp.Common.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InventoryItem", null, t =>
                        {
                            t.HasCheckConstraint("CK_InventoryItem_StockQuantity_Min", "[StockQuantity] >= 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Electronics",
                            LastUpdated = new DateTime(2025, 4, 6, 1, 59, 38, 718, DateTimeKind.Utc).AddTicks(666),
                            Name = "Laptop",
                            StockQuantity = 5
                        },
                        new
                        {
                            Id = 2,
                            Category = "Electronics",
                            LastUpdated = new DateTime(2025, 4, 6, 1, 59, 38, 718, DateTimeKind.Utc).AddTicks(1529),
                            Name = "Television",
                            StockQuantity = 15
                        },
                        new
                        {
                            Id = 3,
                            Category = "Furniture",
                            LastUpdated = new DateTime(2025, 4, 6, 1, 59, 38, 718, DateTimeKind.Utc).AddTicks(1530),
                            Name = "Table",
                            StockQuantity = 25
                        },
                        new
                        {
                            Id = 4,
                            Category = "Furniture",
                            LastUpdated = new DateTime(2025, 4, 6, 1, 59, 38, 718, DateTimeKind.Utc).AddTicks(1531),
                            Name = "Chair",
                            StockQuantity = 35
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
