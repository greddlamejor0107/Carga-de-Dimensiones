using LoadDWVentas.Data.Context;
using LoadDWVentas.WorkerService;
using Microsoft.EntityFrameworkCore;
using LoadDWVentas.Data.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
       CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) => {

            services.AddDbContextPool<NorwindContext>(options => 
                                                      options.UseSqlServer(hostContext.Configuration.GetConnectionString("NorthwindContext")));

            services.AddDbContextPool<NorthwindOrder>(options => 
                                                      options.UseSqlServer(hostContext.Configuration.GetConnectionString("NorthwindOrders")));
 

           // services.AddScoped<IDataServiceDwVentas, DataServiceDwVentas>();

            
            services.AddHostedService<Worker>();
        });
}