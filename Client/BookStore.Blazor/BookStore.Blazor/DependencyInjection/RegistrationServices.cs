using BookStore.Blazor.Contracts;
using BookStore.Blazor.Infrastructure.Utilities;
using Services;

namespace BookStore.Blazor.DependencyInjection;

public static class RegistrationServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<ICategoryService, CategoryManager>();  
        services.AddScoped<BookStateService>();
        services.AddScoped<CategoryStateService>();
    }
}