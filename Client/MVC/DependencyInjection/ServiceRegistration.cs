using Contracts;
using MVC.Contracts;
using MVC.Services;
using Services;

namespace MVC.DependencyInjection;

public static class RegistrationServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ISubscriberService, SubscriberManager>();
        
    }
}
