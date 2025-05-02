using BookSAW.Contracts;
using Services;

namespace DependencyInjection
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            
        }
    }
}