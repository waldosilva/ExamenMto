using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosMto.Entity.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Cost { get; set; }
    }
}
