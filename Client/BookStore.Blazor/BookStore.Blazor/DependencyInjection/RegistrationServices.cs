using BookStore.Blazor.Contracts;
using Services;

namespace DependencyInjection;

public static class RegistrationServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<ICategoryService, CategoryManager>();  
    }
}