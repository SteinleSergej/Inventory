using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public DeleteCategoryCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);
            if(category == null)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return new ResponseDto
            {

            };
        }
    }
}
