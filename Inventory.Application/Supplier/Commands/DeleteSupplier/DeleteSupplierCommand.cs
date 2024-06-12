using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand:IRequest<ResponseDto>
    {
        public Guid Id { get; set; }
    }
}
