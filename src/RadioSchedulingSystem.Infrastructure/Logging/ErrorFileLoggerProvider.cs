using Microsoft.Extensions.Logging;

namespace RadioSchedulingSystem.Infrastructure.Logging;

public class ErrorFileLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new ErrorFileLogger();
    }

    public void Dispose()
    {
    }
}