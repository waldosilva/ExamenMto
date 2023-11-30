using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarlosMto.Entity.Entities;

namespace CarlosMto.Application.Services.Request
{
    public class RequestSale
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }


        public  List<RequestConcept>? Items { get; set; }

    }
}
