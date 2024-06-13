﻿// <auto-generated />
using System;
using Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inventory.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("70f36af7-cda7-47fd-92aa-0932faa52b0f"),
                            Name = "Computers"
                        },
                        new
                        {
                            Id = new Guid("9501c0bf-c6d3-4ab7-aed4-15835d41fa54"),
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = new Guid("a9ecf1d0-f981-4084-af6e-8ce88f6a490f"),
                            Name = "Storage Devices"
                        });
                });

            modelBuilder.Entity("Inventory.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e3a06244-bc0e-4176-b219-2c79e88dc05f"),
                            CategoryId = new Guid("70f36af7-cda7-47fd-92aa-0932faa52b0f"),
                            Description = "High performance gaming laptop with advanced cooling system.",
                            Name = "Gaming Laptop",
                            Price = 1499.99,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = new Guid("1e821611-b47b-4638-b285-997871d3baa7"),
                            CategoryId = new Guid("9501c0bf-c6d3-4ab7-aed4-15835d41fa54"),
                            Description = "Ergonomic wireless mouse with adjustable DPI for precision control.",
                            Name = "Wireless Mouse",
                            Price = 29.989999999999998,
                            QuantityInStock = 50
                        },
                        new
                        {
                            Id = new Guid("1358f001-ab92-493b-a0a7-622fe1a855f3"),
                            CategoryId = new Guid("a9ecf1d0-f981-4084-af6e-8ce88f6a490f"),
                            Description = "Portable and high-speed external SSD, 1TB capacity.",
                            Name = "External SSD",
                            Price = 199.99000000000001,
                            QuantityInStock = 30
                        });
                });

            modelBuilder.Entity("Inventory.Domain.ProductSupplier", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductSuppliers");
                });

            modelBuilder.Entity("Inventory.Domain.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Inventory.Domain.Product", b =>
                {
                    b.HasOne("Inventory.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Inventory.Domain.ProductSupplier", b =>
                {
                    b.HasOne("Inventory.Domain.Product", "Product")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Domain.Supplier", "Supplier")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Inventory.Domain.Product", b =>
                {
                    b.Navigation("ProductSuppliers");
                });

            modelBuilder.Entity("Inventory.Domain.Supplier", b =>
                {
                    b.Navigation("ProductSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
