using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<ResponseDto>
    {
        public Domain.Category Category { get; set; }
    }
}
