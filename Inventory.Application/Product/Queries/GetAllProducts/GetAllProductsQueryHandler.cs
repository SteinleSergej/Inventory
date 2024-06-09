using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public GetAllProductsQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await context.Products.ToListAsync();
            return new ResponseDto
            {
                Data = products,
            };
        }
    }
}
