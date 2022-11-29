using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.Entities;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OrderManagement.Data;

namespace OrderManagement.Services
{
    public class CustomerServices
    {
        private readonly DataContext _context;

        public CustomerServices(DataContext context)
        {
            _context = context;
        }

        public async void CreateAsync(CustomerRequest customerReq)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(x => x.Email == customerReq.Email);
                if (customer == null)
                {
                    customer = new CustomerEntity
                    {
                        Name = customerReq.Name,                        
                        Email = customerReq.Email,                        
                    };
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Kund har lagts till");
                }
                else
                {
                    MessageBox.Show("Det finns redan en kund med denna Mail.");
                }
            }
            catch
            {
                MessageBox.Show("Kunde inte lägga till kund.");
            }
        }

        public async Task<IEnumerable<CustomerRequest>> GetAllAsync()
        {
            var customers = new List<CustomerRequest>();

            try
            {
                foreach (var customer in await _context.Customers.ToListAsync())
                {
                    customers.Add(new CustomerRequest
                    {
                       Name = customer.Name,
                        
                  
                    });
                }
                return customers;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return customers;
        }

        public async Task<CustomerRequest> GetAsync(int id)
        {
            try
            {
                var customerEntity = await _context.Customers.FindAsync(id);

                var customerReq = new CustomerRequest
                {
                    Name = customerEntity.Name,
                    Email = customerEntity.Email,
              
                };


                return customerReq;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new CustomerRequest();
        }

        public async void UpdateCustomer(int id, CustomerRequest customerRequest)
        {
            try
            {
                var customerEntity = await _context.Customers.FindAsync(id);

                customerEntity.Name = customerRequest.Name;
                customerEntity.Email = customerRequest.Email;

                _context.Entry(customerEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                MessageBox.Show("Kund har uppdaterats");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                MessageBox.Show("Kunde inte uppdatera Kundinformation.");
            }
        }
    }
}
