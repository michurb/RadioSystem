using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Domain.Entities;

namespace RadioSchedulingSystem.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static ShowDto AsDto(this Show show)
    {
        return new ShowDto
        {
            Id = show.Id,
            Title = show.Title,
            Presenter = show.Presenter,
            StartTime = show.StartTime,
            Duration = show.Duration
        };
    }
}