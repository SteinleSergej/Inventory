using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (product == null)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Product not found"
                };
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return new ResponseDto
            {

            };
        }
    }
}
