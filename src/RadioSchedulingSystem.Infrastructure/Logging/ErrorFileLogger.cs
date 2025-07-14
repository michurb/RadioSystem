using System.Text;
using Microsoft.Extensions.Logging;

namespace RadioSchedulingSystem.Infrastructure.Logging;

public class ErrorFileLogger : ILogger
{
    public string CategoryName { get; }
    private const string LogFilePath = "Logs/error_logs.txt";

    public ErrorFileLogger(string categoryName)
    {
        CategoryName = categoryName;
    }

    public IDisposable? BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel == LogLevel.Error;

    public void Log<TState>(LogLevel logLevel, EventId eventId,
        TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (logLevel != LogLevel.Error) return;

        try
        {
            var directory = Path.GetDirectoryName(LogFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var message = formatter(state, exception);
            var entry = $"[{timestamp}] ERROR: {message} ;{Environment.NewLine}";

            File.AppendAllText(LogFilePath, entry, Encoding.UTF8);
        }
        catch
        {
            // If logging fails, we do not throw an exception not to stop application.
        }
    }
}