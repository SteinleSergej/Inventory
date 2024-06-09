using Inventory.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResponseDto>
    {
        private readonly ApplicationDbContext context;

        public UpdateCategoryCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ResponseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                context.Categories.Update(request.Category);
                await context.SaveChangesAsync();
                return new ResponseDto
                {
                    Data = request.Category,

                };
            }
            catch(Exception e)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }
    }
}
