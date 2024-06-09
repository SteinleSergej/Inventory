﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand:IRequest<ResponseDto>
    {
        public Guid Id { get; set; }
    }
}
