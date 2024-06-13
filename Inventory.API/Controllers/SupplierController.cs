using Inventory.API.Dtos.Supplier;
using Inventory.Application.Product.Commands.DeleteProduct;
using Inventory.Application.Product.Commands.UpdateProduct;
using Inventory.Application.Product.Queries.GetProductById;
using Inventory.Application.Supplier.Commands.CreateSupplier;
using Inventory.Application.Supplier.Commands.DeleteSupplier;
using Inventory.Application.Supplier.Commands.UpdateSupplier;
using Inventory.Application.Supplier.Queries.GetAllSuppliers;
using Inventory.Application.Supplier.Queries.GetSupplierById;
using Inventory.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController:ControllerBase
    {
        private readonly IMediator mediator;

        public SupplierController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(CreateSupplierDto dto)
        {
            var sup = new Domain.Supplier
            {
                Name = dto.Name,
                ContactInformation = dto.ContactInformation,
            };

            var response = await mediator.Send(new CreateSupplierCommand { Supplier = sup });
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var response = await mediator.Send(new GetAllSuppliersQuery { });
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSupplierById(Guid id)
        {
            var response = await mediator.Send(new GetSupplierByIdQuery { Id = id});
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(Supplier supplier)
        {
            var response = await mediator.Send(new UpdateSupplierCommand { Supplier = supplier});
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            var response = await mediator.Send(new DeleteSupplierCommand { Id = id});
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return NoContent();
        }
    }
}
