using OrderManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class OrderRequest
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        public int ProductId { get; set; }
       
        public decimal Price { get; set; }
        public int AntalOrder { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
