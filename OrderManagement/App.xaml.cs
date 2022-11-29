using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagement.Data;
using OrderManagement.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OrderManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? app { get; private set; }
        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=N:\OneDrive\CMS22\Databasteknik\DB-Assignment-1\OrderManagement\Data\OrderManagementDataBase.mdf;Integrated Security=True;Connect Timeout=30")); //Conetion till databas
                services.AddScoped<CustomerServices>();
                services.AddScoped<OrderServices>();
                services.AddScoped<ProductServices>();
            }).Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await app!.StartAsync();
            var MainWindow =app.Services.GetRequiredService<MainWindow>();
            //MainWindow.DataContext = MainWindow;
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
