using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ResponseDto>
    {
        public Guid Id { get; set; }
    }
}
