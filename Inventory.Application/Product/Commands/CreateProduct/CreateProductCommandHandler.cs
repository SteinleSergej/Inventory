using Inventory.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            context.Products.Add(request.Product);

            var saved =await context.SaveChangesAsync();

            if(saved > 0)
            {
                return new ResponseDto { };
            }

            return new ResponseDto { IsSuccess = false };
        }
    }
}
