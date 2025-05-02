
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using WebApi.Infrastructure.Extensions;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Updated to use the recommended method for configuring NLog
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Logging.ConfigureLoggingParams();
            builder.Host.ConfigureLogging();


            builder.Services.AddControllers(config =>
                            {
                                //Content Negociation configuration
                                config.RespectBrowserAcceptHeader = true;
                                config.ReturnHttpNotAcceptable = true;
                            })
                            .AddXmlSerializerFormatters()// record don't like AddXmlDataContractSerializerFormatters
                            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
                            .AddNewtonsoftJson();
            builder.Services.ConfigureRepositoryContext(builder.Configuration);
            builder.Services.ConfigureAutoMapper();
            builder.Services.ConfigureLoggerManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureActionFilters();
            builder.Services.ConfigureResponseCaching();
            builder.Services.ConfigureHttpCacheHeaders();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.ConfigureCors();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            var logger = app.Services.GetRequiredService<ILoggerService>();
            logger.LogInfo("Application is Running...");
            app.ConfigureExceptionHandler(logger);

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //This force our app to be used only under Https: Hsts(Http strict transport security)
            if (app.Environment.IsProduction())
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseResponseCaching();
            app.UseHttpCacheHeaders();//This method must be called after UseCors()

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
