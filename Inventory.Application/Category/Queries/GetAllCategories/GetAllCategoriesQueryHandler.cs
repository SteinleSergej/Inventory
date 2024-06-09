using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesRequestQuery, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public GetAllCategoriesQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(GetAllCategoriesRequestQuery request, CancellationToken cancellationToken)
        {
            var list = await context.Categories.ToListAsync();
            return new ResponseDto
            {
                Data = list
            };
        }
    }
}
