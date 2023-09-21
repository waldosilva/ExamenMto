using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmvelTest.Entity.Entities
{
    public class Client : EntityBase
    {
        
        public string Name { get; set; }
    }
}
