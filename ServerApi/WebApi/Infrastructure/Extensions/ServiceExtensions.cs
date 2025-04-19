using Microsoft.EntityFrameworkCore;
using Presentation.ActionsFilters;
using Repositories.Contracts;
using Repositories.EFCore.Context;
using Repositories.EFCore.Models;
using Services.Contracts;
using Services.Models;

namespace WebApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
        }
        public static void ConfigureLoggerManager(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerManager>();
        }
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IBookService, BookManager>();
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<LogFilterAttribute>();
            services.AddScoped<ValidationFilterAttribute>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }
       
    }
}
