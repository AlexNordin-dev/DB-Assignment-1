using OrderManagement.Data;
using OrderManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrderManagement.Services
{
    public class OrderServices
    {
        private readonly DataContext _context;

        public OrderServices(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(OrderEntity order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            MessageBox.Show("Order skapad.");
        }

        //public async Task CreateRowsAsync(ObservableCollection<Order> orderRows, int orderId)
        //{
        //    foreach (var row in orderRows)
        //    {
        //        var orderRow = new OrderEntity
        //        {
        //            OrderId = orderId,
        //            ProductId = row.ProductId,
        //            Quantity = row.Quantity,
        //            Price = row.Price
        //        };
        //        _context.Add(orderRow);
        //    }
        //    await _context.SaveChangesAsync();
        //}
    }
}
