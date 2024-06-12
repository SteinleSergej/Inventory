using Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public GetAllSuppliersQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await context.Suppliers.ToListAsync();
            return new ResponseDto
            {
                Data = suppliers,
            };
        }
    }
}
