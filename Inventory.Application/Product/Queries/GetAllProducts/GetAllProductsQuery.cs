using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<ResponseDto>
    {
    }
}
