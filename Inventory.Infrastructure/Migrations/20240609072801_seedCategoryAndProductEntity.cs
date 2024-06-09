using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedCategoryAndProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b5e3648-09a2-4572-883f-2d2e99486de6"), "Storage Devices" },
                    { new Guid("60ea3bb3-ae87-49ea-a6f5-c2420d6a33d5"), "Computers" },
                    { new Guid("a1849836-50ca-412c-9034-2a8dcab07d58"), "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("42992dcf-53f9-4a94-8976-cfaea71a76d8"), new Guid("60ea3bb3-ae87-49ea-a6f5-c2420d6a33d5"), "High performance gaming laptop with advanced cooling system.", "Gaming Laptop", 1499.99, 10 },
                    { new Guid("764a833a-7d3c-4de4-9c39-69cc0c1dcf9a"), new Guid("a1849836-50ca-412c-9034-2a8dcab07d58"), "Ergonomic wireless mouse with adjustable DPI for precision control.", "Wireless Mouse", 29.989999999999998, 50 },
                    { new Guid("87ee11b9-136b-41bc-9ae8-374b7b5f83d2"), new Guid("5b5e3648-09a2-4572-883f-2d2e99486de6"), "Portable and high-speed external SSD, 1TB capacity.", "External SSD", 199.99000000000001, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("42992dcf-53f9-4a94-8976-cfaea71a76d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("764a833a-7d3c-4de4-9c39-69cc0c1dcf9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87ee11b9-136b-41bc-9ae8-374b7b5f83d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5b5e3648-09a2-4572-883f-2d2e99486de6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("60ea3bb3-ae87-49ea-a6f5-c2420d6a33d5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1849836-50ca-412c-9034-2a8dcab07d58"));
        }
    }
}
