using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OrderManagement.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        public int ProductId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int AntalOrder { get; set; }
        public DateTime OrderDate { get; set; }
           
    }

   
}
