using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models.Entities
{
    public class ProductEntity
    {
        public ProductEntity(string name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName="money")]
        public decimal Price { get; set;}
    }
}
