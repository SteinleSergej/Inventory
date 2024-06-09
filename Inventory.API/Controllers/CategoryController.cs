using Inventory.API.Dtos.Category;
using Inventory.Application.Category.Commands.CreateCategory;
using Inventory.Application.Category.Commands.DeleteCategory;
using Inventory.Application.Category.Commands.UpdateCategory;
using Inventory.Application.Category.Queries.GetAllCategories;
using Inventory.Application.Category.Queries.GetCategoryById;
using Inventory.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await mediator.Send(new GetAllCategoriesRequestQuery { });

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryDto dto)
        {
            var response =await mediator.Send(new CreateCategoryCommand { Name = dto.CategoryName });
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var response = await mediator.Send(new GetCategoryByIdQuery { CategoryId = id });
            if (!response.IsSuccess) { 
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory (Category category)
        {
            var response = await mediator.Send(new UpdateCategoryCommand { Category = category });
            if (!response.IsSuccess) { 
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var response = await mediator.Send(new DeleteCategoryCommand { CategoryId = id });
            if (!response.IsSuccess) {
                return BadRequest(response);
            }
            return NoContent();
        }
    }
}
