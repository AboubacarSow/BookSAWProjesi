using Serilog;
namespace WebApi.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static void ConfigureLogging(this ConfigureHostBuilder host)
        {
            var logfilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "app_log.txt");
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.File(logfilePath,
                            rollingInterval: RollingInterval.Day,
                            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] | {Message}  [{Exception}]{NewLine}")
                        .Filter.ByIncludingOnly(logEvent =>
                            logEvent.Properties.ContainsKey("SourceContext")  &&
                            logEvent.Properties["SourceContext"].ToString() != null &&
                            logEvent.Properties["SourceContext"].ToString().Contains("LoggerManager"))
                        .CreateLogger();
            host.UseSerilog();
        }
        public static void ConfigureLoggingParams(this ILoggingBuilder logging)
        {
            logging.AddDebug();
            
        }
    }
}
