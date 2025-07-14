using Moq;
using RadioSchedulingSystem.Application.Queries;
using RadioSchedulingSystem.Domain.Entities;
using RadioSchedulingSystem.Domain.Interfaces;
using RadioSchedulingSystem.Infrastructure.DAL.Handlers;

namespace RadioSchedulingSystem.Tests;

public class DailyReportTests
{
    [Fact]
    public async Task GetDailyReport_CalculatesTotalDurationCorrectly()
    {
        // Arrange
        var targetDate = new DateTime(2025, 7, 14);

        var shows = new List<Show>
        {
            new()
            {
                Id = Guid.NewGuid(), Title = "Morning Show", Presenter = "A", StartTime = targetDate.AddHours(9),
                Duration = 60
            },
            new()
            {
                Id = Guid.NewGuid(), Title = "News", Presenter = "B", StartTime = targetDate.AddHours(10), Duration = 30
            },
            new()
            {
                Id = Guid.NewGuid(), Title = "Evening Rock", Presenter = "C", StartTime = targetDate.AddHours(17),
                Duration = 90
            }
        };

        var repoMock = new Mock<IShowRepository>();
        repoMock.Setup(r => r.GetShowsByDateAsync(targetDate))
            .ReturnsAsync(shows);

        var handler = new GetDailyReportHandler(repoMock.Object);

        // Act
        var result = await handler.Handle(new GetDailyReport(targetDate), CancellationToken.None);

        // Assert
        Assert.Equal(3, result.TotalShows);
        Assert.Equal(180, result.TotalDuration);
    }
}