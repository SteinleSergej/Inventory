﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Supplier.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery:IRequest<ResponseDto>
    {
        public Guid Id { get; set; }
    }
}
