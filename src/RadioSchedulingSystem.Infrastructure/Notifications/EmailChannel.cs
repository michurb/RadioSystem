using RadioSchedulingSystem.Application.Interfaces;

namespace RadioSchedulingSystem.Infrastructure.Notifications;

public class EmailChannel : INotificationChannel
{
    public Task NotifyAsync(string body, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Sending email body: {body}");
        return Task.CompletedTask;
    }
}