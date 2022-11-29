using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Entities;

namespace WebAPI.Models
{
    public class OrderCreateModel
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
                  
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        
    }
}
