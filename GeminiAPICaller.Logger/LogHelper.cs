using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Serilog;


namespace GeminiAPICaller.Logger
{
    public static class LogHelper
    {
        private static Serilog.ILogger _logger;

        static LogHelper()
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appSettings.json", optional: false, reloadOnChange: true)
                .Build();
                _logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
        }

        public static void LogInfo(string message, [CallerMemberName] string callerName = "")
        {
            _logger.Information($"[{callerName}]{message}");
        }

        public static void LogException(Exception exception, [CallerMemberName] string callerName = "", object customData = null)
        {
            _logger.Error(exception, $"[{callerName}] {exception.Message} ({exception.GetType().Name})" +
                                       $"\nStackTrace: {exception.StackTrace}" +
                                       (customData != null ? $"\nCustom Data: {customData}" : ""));
        }
        public static void LogDebug(string message, [CallerMemberName] string callerName = "")
        {
            _logger.Debug($"[{callerName}]{message}");
        }

    }
}
