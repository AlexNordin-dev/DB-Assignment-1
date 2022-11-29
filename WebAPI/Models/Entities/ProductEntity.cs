﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public ProductCategoryEntity Category { get; set; }
        
        public ICollection<OrderEntity> Orders { get; set; }

    }
}
