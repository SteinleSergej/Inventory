﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty ;

        public double Price { get; set; }

        public int QuantityInStock { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<ProductSupplier> ProductSuppliers { get; set; } = new();
    }
}
