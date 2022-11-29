using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
