using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Entities
{
    public class ProductCategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public ICollection<ProductEntity> Products { get; set; }
        
    }
}
