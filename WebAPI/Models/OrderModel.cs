using WebAPI.Models.Entities;

namespace WebAPI.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        
    }
}
