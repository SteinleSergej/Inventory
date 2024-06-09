using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<ResponseDto>
    {
        public Domain.Product Product { get; set; }
    }
}
