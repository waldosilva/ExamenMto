using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmvelTest.Entity.Entities
{
    public class Sale : EntityBase
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        //public decimal Total() => Products.Sum(_ => _.Amount);

        public virtual ICollection<Concept> Products { get; set; }

        public Sale(int customerId,DateTime date)
        {
            CustomerId = customerId;
            Date = date;
            Products = new List<Concept>();
        }
        
    }
}
