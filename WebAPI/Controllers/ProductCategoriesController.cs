using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductCategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productCategories = new List<ProductCategoryModel>();
            foreach (var category in await _context.ProductCategories.ToListAsync())
                productCategories.Add(new ProductCategoryModel
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });

            return new OkObjectResult(productCategories);
        }
    }
}
