using InventoryApp.Common.Interfaces.Repositories;
using InventoryApp.Infrastructure.Data;
using InventoryApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace InventoryApp.Infrastructure
{
    public static class DebendencyInjectionRegister
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            return services;
        }
    }
}
