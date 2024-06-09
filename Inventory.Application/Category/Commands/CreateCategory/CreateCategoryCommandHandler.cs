using Inventory.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inventory.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public CreateCategoryCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            context.Categories.Add(new Domain.Category { Name = request.Name});
           var saved = await context.SaveChangesAsync();
           if(saved > 0)
            {
                return new ResponseDto { };
            }

           return new ResponseDto { IsSuccess= false};
        }
    }
}
