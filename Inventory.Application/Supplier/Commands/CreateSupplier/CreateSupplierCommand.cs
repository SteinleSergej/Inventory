using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierCommand:IRequest<ResponseDto>
    {
        public Domain.Supplier Supplier { get; set; }
    }
}
