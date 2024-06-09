using Inventory.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                context.Products.Update(request.Product);
                await context.SaveChangesAsync();
                return new ResponseDto
                {
                    Data = request.Product,

                };
            }
            catch (Exception e)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }
    }
}
