using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;
using OrderManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class ProductServices
    {
        private readonly DataContext _context;

        public ProductServices(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ProductRequest req) // Skapa procukt
        {
            _context.Add(new ProductEntity(req.Name, req.Description, req.Price));
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductEntity>> GetAllAsync() //Hemäta alla produkt från database
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<ProductEntity> GetAsync(int id) //Hämta en specifik item baserat på id
        {
            return await(_context.Products.FindAsync(id));
        }

        public async Task UpdateAsync(ProductEntity product)// Uppdatera en procukt
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync (int id)// ta bort en procukt
        {
            var productEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}
