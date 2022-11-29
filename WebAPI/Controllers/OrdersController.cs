using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Models;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var orderEntity = new OrderEntity
                {
                    
                    OrderDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(30),
                    
                    CustomerId = model.CustomerId,
                    ProductId = model.ProductId,



                };

                foreach (var product in model.Products)
                    orderEntity.Products.Add(new ProductEntity { Id = product.Id });

                _context.Add(orderEntity);

                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = new List<CustomerModel>();
            
            foreach (var item in await _context.Customers.ToListAsync()  )
                customers.Add(new CustomerModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                });

            var products = new List<ProductModel>();
            foreach (var items in await _context.Products.ToListAsync() )
                products.Add(new ProductModel
                {
                    Id = items.Id,
                    Name = items.Name,
                    Description = items.Description,
                    Price= items.Price,
                });

            return new OkObjectResult(customers);
            
        }
    }
}
