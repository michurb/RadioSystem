using MediatR;
using RadioSchedulingSystem.Application.Exceptions;
using RadioSchedulingSystem.Domain.Entities;
using RadioSchedulingSystem.Domain.Interfaces;

namespace RadioSchedulingSystem.Application.Commands.Handlers;

public sealed class CreateShowHandler : IRequestHandler<CreateShow, Guid>
{
    private readonly IShowRepository _showRepository;

    public CreateShowHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public async Task<Guid> Handle(CreateShow request, CancellationToken cancellationToken)
    {
        var showsOnDay = await _showRepository.GetShowsByDateAsync(request.dto.StartTime.Date);

        var newStart = request.dto.StartTime;
        var newEnd = newStart.AddMinutes(request.dto.DurationMinutes);

        var overlap = showsOnDay.Any(show =>
            newStart < show.StartTime.AddMinutes(show.Duration) && newEnd > show.StartTime);


        if (overlap)
            throw new ShowConflictException("Show overlaps with an existing show.");

        var show = new Show
        {
            Id = Guid.NewGuid(),
            Title = request.dto.Title,
            Presenter = request.dto.Presenter,
            StartTime = request.dto.StartTime,
            Duration = request.dto.DurationMinutes
        };

        await _showRepository.AddAsync(show);

        return show.Id;
    }
}