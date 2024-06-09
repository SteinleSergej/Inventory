using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesRequestQuery:IRequest<ResponseDto>
    {
    }
}
