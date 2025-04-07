using InventoryApp.Infrastructure;
using InventoryApp.ViewModels;
using InventoryApp.Views;
using Microsoft.Extensions.DependencyInjection;
using InventoryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private readonly IServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();

        services.AddLogging();
        services.AddScoped<InventoryViewModel>();
        services.AddScoped<InventoryView>();
        services.AddInfrastructure();
        
        _serviceProvider = services.BuildServiceProvider();

        var dbContext = _serviceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();

        var mainWindow = _serviceProvider.GetRequiredService<InventoryView>();
        mainWindow.Show();
    }
}