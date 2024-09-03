using AzureSqlConsoleApp.Data;
using AzureSqlConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var dbContext = host.Services.GetRequiredService<ApplicationDbContext>();

        // Fetch data from the database
        List<MyDataModel> data = dbContext.MyData.ToList();

        foreach (var item in data)
        {
            Console.WriteLine($"CustomerID: {item.CustomerId}, First Name: {item.FirstName}, Last Name: {item.LastName}, Company Name: {item.CompanyName}");
        }
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
            });
}
