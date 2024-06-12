using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public GetSupplierByIdQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
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

            return new ResponseDto
            {
                Data = supplier
            };
        }
    }
}
