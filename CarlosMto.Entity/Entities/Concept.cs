using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosMto.Entity.Entities
{
    public class Concept : EntityBase
    {
        public decimal Quantity { get; set; }
        public virtual Product Product { get; set; }

        public int saleId { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        
    }
}
