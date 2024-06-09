using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<ResponseDto>
    {
        public string Name { get; set; } = string.Empty;
    }
}
