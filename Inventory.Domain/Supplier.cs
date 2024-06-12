using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string ContactInformation { get; set; } = string.Empty;

        public List<ProductSupplier> ProductSuppliers { get; set; } = new();
    }
}
