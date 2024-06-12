using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public DeleteSupplierHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await context.Suppliers.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (supplier == null)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Supplier not found"
                };
            }

            context.Suppliers.Remove(supplier);
            await context.SaveChangesAsync();

            return new ResponseDto
            {

            };
        }
    }
}
