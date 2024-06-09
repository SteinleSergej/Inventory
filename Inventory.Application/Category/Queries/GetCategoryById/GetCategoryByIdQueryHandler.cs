using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public GetCategoryByIdQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            
                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);
                if (category == null) {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        Message = "Category not found"
                    };
                }

                return new ResponseDto
                {
                    Data = category
                };
            
        }
    }
}
