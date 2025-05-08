using System.Net.Http.Headers;
using BookStore.Blazor.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc.Formatters;
namespace BookStore.Blazor.Infrastructure;
public static class ServicesExtensions
{
    public static void ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
        services.AddHttpClient("BookStoreApi", client =>
        {
            var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            client.BaseAddress = new Uri(apiSettings?.BaseUrl ?? string.Empty);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
       
    }
}