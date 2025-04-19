using Serilog;
using Services.Contracts;

namespace Services.Models
{
    public class LoggerManager : ILoggerService
    {
        private static ILogger _logger = Log.ForContext<LoggerManager>(); // Fixed: Use Serilog's Log.ForContext method
        public void LogDebug(string message) => _logger.Debug(message);
        public void LogError(string message) => _logger.Error(message);
        public void LogInfo(string message) => _logger.Information(message); // Fixed: Corrected method name to match Serilog's API
        public void LogWarn(string message) => _logger.Warning(message); // Fixed: Corrected method name to match Serilog's API
    }
}
