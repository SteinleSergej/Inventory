using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSupplierEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSuppliers",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSuppliers", x => new { x.ProductId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("70f36af7-cda7-47fd-92aa-0932faa52b0f"), "Computers" },
                    { new Guid("9501c0bf-c6d3-4ab7-aed4-15835d41fa54"), "Accessories" },
                    { new Guid("a9ecf1d0-f981-4084-af6e-8ce88f6a490f"), "Storage Devices" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("1358f001-ab92-493b-a0a7-622fe1a855f3"), new Guid("a9ecf1d0-f981-4084-af6e-8ce88f6a490f"), "Portable and high-speed external SSD, 1TB capacity.", "External SSD", 199.99000000000001, 30 },
                    { new Guid("1e821611-b47b-4638-b285-997871d3baa7"), new Guid("9501c0bf-c6d3-4ab7-aed4-15835d41fa54"), "Ergonomic wireless mouse with adjustable DPI for precision control.", "Wireless Mouse", 29.989999999999998, 50 },
                    { new Guid("e3a06244-bc0e-4176-b219-2c79e88dc05f"), new Guid("70f36af7-cda7-47fd-92aa-0932faa52b0f"), "High performance gaming laptop with advanced cooling system.", "Gaming Laptop", 1499.99, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_SupplierId",
                table: "ProductSuppliers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSuppliers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1358f001-ab92-493b-a0a7-622fe1a855f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1e821611-b47b-4638-b285-997871d3baa7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e3a06244-bc0e-4176-b219-2c79e88dc05f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70f36af7-cda7-47fd-92aa-0932faa52b0f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9501c0bf-c6d3-4ab7-aed4-15835d41fa54"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a9ecf1d0-f981-4084-af6e-8ce88f6a490f"));

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
    }
}
