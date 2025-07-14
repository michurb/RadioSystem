namespace RadioSchedulingSystem.Application.Interfaces;

public interface INotificationChannel
{
    Task NotifyAsync(string body, CancellationToken cancellationToken = default);
}