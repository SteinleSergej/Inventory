using Inventory.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Commands.CreateSupplier
{
    
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public CreateSupplierCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            context.Suppliers.Add(request.Supplier);

            var saved = await context.SaveChangesAsync();

            if (saved > 0)
            {
                return new ResponseDto { };
            }

            return new ResponseDto { IsSuccess = false };
        }
    }
}
