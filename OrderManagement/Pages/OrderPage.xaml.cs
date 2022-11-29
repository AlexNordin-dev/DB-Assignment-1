using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OrderManagement.Data;
using OrderManagement.Models;
using OrderManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebAPI.Models;

namespace OrderManagement.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {

        
        
        public OrderPage()
        {
            InitializeComponent();
           
            PopulateProducts().ConfigureAwait(false);
            PopulateCustomers().ConfigureAwait(false);
        }
        public async Task PopulateProducts()
        {
            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            using var client = new HttpClient();

            foreach (var product in await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7151/api/products"))
                collection.Add(new KeyValuePair<string, int > (product.Name,  product.Id));

            cb_product.ItemsSource = collection;
        }

        public async Task PopulateCustomers()
        {
            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            using var client = new HttpClient();

            foreach (var customer in await client.GetFromJsonAsync<IEnumerable<CustomerModel>>("https://localhost:7151/api/customers"))
                collection.Add(new KeyValuePair<string, int>(customer.Name, customer.Id));

            cb_customer.ItemsSource = collection;
        }


        private async void btn_AddProductToList_Click(object sender, RoutedEventArgs e)
        {
            //var id = cb_product.SelectedValue;
            //var product = await _context.Products.FindAsync(id);
            var customer = (KeyValuePair<string, int>)cb_customer.SelectedItem;
            var product = (KeyValuePair<string, int>)cb_product.SelectedItem;
            using var client = new HttpClient();
            lb_addOrderToList.Items.Add("Customer: " + customer.Key + "\n Product: " + product.Key +  "\n");
            
        }

        private async void btn_OrderSave_Click(object sender, RoutedEventArgs e)
        {
            
            var customer = (KeyValuePair<string, int>)cb_customer.SelectedItem;
            var product = (KeyValuePair<string, int>)cb_product.SelectedItem;
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7151/api/orders", new OrderCreateModel
            {
                
                OrderDate = DateTime.Now,
                DueDate = DateTime.Now,
                CustomerId = customer.Value,
                ProductId = product.Value           
                
            });
            cb_customer.SelectedIndex= -1;
            cb_product.SelectedIndex= -1;



        }

       
    }
    
}
