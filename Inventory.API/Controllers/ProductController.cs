using Inventory.API.Dtos.Category;
using Inventory.API.Dtos.Product;
using Inventory.Application.Category.Commands.CreateCategory;
using Inventory.Application.Category.Commands.DeleteCategory;
using Inventory.Application.Category.Commands.UpdateCategory;
using Inventory.Application.Category.Queries.GetAllCategories;
using Inventory.Application.Category.Queries.GetCategoryById;
using Inventory.Application.Product.Commands.CreateProduct;
using Inventory.Application.Product.Commands.DeleteProduct;
using Inventory.Application.Product.Commands.UpdateProduct;
using Inventory.Application.Product.Queries.GetAllProducts;
using Inventory.Application.Product.Queries.GetProductById;
using Inventory.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQuery { });

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var prod = new Domain.Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                QuantityInStock = dto.QuantityInStock,
                CategoryId = dto.CategoryId,
            };
            var response = await mediator.Send(new CreateProductCommand { Product= prod});
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var response = await mediator.Send(new GetProductByIdQuery {  Id= id});
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var response = await mediator.Send(new UpdateProductCommand { Product = product});
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await mediator.Send(new DeleteProductCommand { Id = id});
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return NoContent();
        }
    }
}
