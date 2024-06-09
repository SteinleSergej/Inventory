using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product == null) {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Product not found"
                };
            }

            return new ResponseDto
            {
                Data = product
            };
        }
    }
}
