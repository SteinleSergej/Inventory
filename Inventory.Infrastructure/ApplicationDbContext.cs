using Inventory.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var categoryComputers = new Category { Id = Guid.NewGuid(), Name = "Computers" };
            var categoryAccessories = new Category { Id = Guid.NewGuid(), Name = "Accessories" };
            var categoryStorage = new Category { Id = Guid.NewGuid(), Name = "Storage Devices" };

            modelBuilder.Entity<Category>().HasData(
                categoryComputers,
                categoryAccessories,
                categoryStorage
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Gaming Laptop",
                    Description = "High performance gaming laptop with advanced cooling system.",
                    Price = 1499.99,
                    QuantityInStock = 10,
                    CategoryId = categoryComputers.Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with adjustable DPI for precision control.",
                    Price = 29.99,
                    QuantityInStock = 50,
                    CategoryId = categoryAccessories.Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "External SSD",
                    Description = "Portable and high-speed external SSD, 1TB capacity.",
                    Price = 199.99,
                    QuantityInStock = 30,
                    CategoryId = categoryStorage.Id
                }
            );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
