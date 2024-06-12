using Inventory.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public UpdateSupplierCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                context.Suppliers.Update(request.Supplier);
                await context.SaveChangesAsync();
                return new ResponseDto
                {
                    Data = request.Supplier,

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
