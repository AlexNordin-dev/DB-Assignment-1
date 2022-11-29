namespace WebAPI.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
       

        public int CustomerId { get; set; }
        public ICollection<CustomerEntity> Customers { get; set; }

        public int ProductId { get; set; }
        public ICollection<ProductEntity> Products { get; set; }




    }
}
