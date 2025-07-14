using Moq;
using RadioSchedulingSystem.Application.Commands;
using RadioSchedulingSystem.Application.Commands.Handlers;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Exceptions;
using RadioSchedulingSystem.Domain.Entities;
using RadioSchedulingSystem.Domain.Interfaces;

namespace RadioSchedulingSystem.Tests;
public class RadioShowTests
{
    [Fact]
    public async Task Handle_ShouldAddShow_WhenNoOverlapExists()
    {
        // Arrange
        var mockRepo = new Mock<IShowRepository>();

        mockRepo.Setup(repo => repo.GetShowsByDateAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<Show>());

        var handler = new CreateShowHandler(mockRepo.Object);

        var dto = new CreateShowDto
        {
            Title = "Evening Talk",
            Presenter = "Jane Doe",
            StartTime = DateTime.UtcNow.AddDays(1).Date.AddHours(18),
            DurationMinutes = 60
        };

        var command = new CreateShow(dto);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        mockRepo.Verify(repo => repo.AddAsync(It.Is<Show>(
            s => s.Title == dto.Title &&
                 s.Presenter == dto.Presenter &&
                 s.StartTime == dto.StartTime &&
                 s.Duration == dto.DurationMinutes)), Times.Once);
    }
    
    [Fact]
    public async Task Handle_ShouldThrowShowConflictException_WhenShowOverlaps()
    {
        // Arrange
        var existingShow = new Show
        {
            Id = Guid.NewGuid(),
            Title = "Morning Jazz",
            Presenter = "Alice Smith",
            StartTime = DateTime.UtcNow.Date.AddHours(9),
            Duration = 60
        };

        var mockRepo = new Mock<IShowRepository>();

        mockRepo.Setup(repo => repo.GetShowsByDateAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<Show> { existingShow });

        var handler = new CreateShowHandler(mockRepo.Object);

        var overlappingDto = new CreateShowDto
        {
            Title = "Overlapping Show",
            Presenter = "Bob Jones",
            StartTime = existingShow.StartTime.AddMinutes(30),
            DurationMinutes = 30
        };

        var command = new CreateShow(overlappingDto);

        // Act & Assert
        await Assert.ThrowsAsync<ShowConflictException>(() =>
            handler.Handle(command, CancellationToken.None));
    }
}