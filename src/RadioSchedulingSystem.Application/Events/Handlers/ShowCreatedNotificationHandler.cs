using MediatR;
using RadioSchedulingSystem.Application.Interfaces;

namespace RadioSchedulingSystem.Application.Events.Handlers;

public sealed class ShowCreatedNotificationHandler : INotificationHandler<ShowCreatedNotification>
{
    private readonly IEnumerable<INotificationChannel> _channels;

    public ShowCreatedNotificationHandler(IEnumerable<INotificationChannel> notifications)
    {
        _channels = notifications ?? throw new ArgumentNullException(nameof(notifications));
    }

    public async Task Handle(ShowCreatedNotification notification, CancellationToken cancellationToken)
    {
        var body =
            $"Nowa audycja: {notification.Show.Title}" +
            $" o {notification.Show.StartTime:yyyy-MM-dd HH:mm}" +
            $"prowadzona przez {notification.Show.Presenter}.";

        foreach (var channel in _channels) await channel.NotifyAsync(body, cancellationToken);
    }
}