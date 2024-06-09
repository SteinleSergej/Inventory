using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery:IRequest<ResponseDto>
    {
        public Guid CategoryId { get; set; }
    }
}
