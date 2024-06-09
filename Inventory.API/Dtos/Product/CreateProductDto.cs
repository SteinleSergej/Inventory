namespace Inventory.API.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public int QuantityInStock { get; set; }

        public Guid CategoryId { get; set; }
    }
}
