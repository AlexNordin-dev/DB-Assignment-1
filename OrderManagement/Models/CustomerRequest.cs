using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class CustomerRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
