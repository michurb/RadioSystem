using MediatR;
using Moq;
using RadioSchedulingSystem.Application.Commands;
using RadioSchedulingSystem.Application.Commands.Handlers;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Events;
using RadioSchedulingSystem.Domain.Entities;
using RadioSchedulingSystem.Domain.Interfaces;

namespace RadioSchedulingSystem.Tests;

public class NotificationTests
{
    [Fact]
    public async Task CreatingShow_PublishesNotification()
    {
        // Arrange
        var repo   = new Mock<IShowRepository>();
        repo.Setup(r => r.GetShowsByDateAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(Array.Empty<Show>());

        var mediator = new Mock<IMediator>();
        var handler = new CreateShowHandler(repo.Object, mediator.Object);

        var dto = new CreateShowDto
        {
            Title = "Morning Show",
            Presenter = "John Doe",
            StartTime = DateTime.UtcNow.AddDays(1).Date.AddHours(9),
            DurationMinutes = 60
        };
        var command = new CreateShow(dto);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mediator.Verify(m =>
                m.Publish(It.Is<ShowCreatedNotification>(n => n.Show.Title == dto.Title),
                    It.IsAny<CancellationToken>()),
            Times.Once);
    }
}