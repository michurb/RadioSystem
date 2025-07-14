using Microsoft.Extensions.Logging;
using RadioSchedulingSystem.Infrastructure.Logging;

namespace RadioSchedulingSystem.Tests;

public class ErrorLoggingTests
{
    private readonly string _logFilePath = "Logs/error_logs.txt";

    [Fact]
    public void LogError_WritesMessageToFile()
    {
        // Arrange
        var logger = new ErrorFileLogger("TestCategory");
        if (File.Exists(_logFilePath)) File.Delete(_logFilePath);

        var logMessage = "Test error occurred";

        // Act
        logger.Log(LogLevel.Error, new EventId(1, "TestEvent"), logMessage, null, (s, e) => s);

        // Assert
        Assert.True(File.Exists(_logFilePath), "Log file should exist.");
        var content = File.ReadAllText(_logFilePath);
        Assert.Contains("Test error occurred", content);
    }
}