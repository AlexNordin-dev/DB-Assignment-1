using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }     
        public int CustomerId { get; set; }        
        public int ProductId { get; set; }
       




    }
}
