using MediatR;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Queries;
using RadioSchedulingSystem.Domain.Interfaces;

namespace RadioSchedulingSystem.Infrastructure.DAL.Handlers;

public class GetDailyReportHandler : IRequestHandler<GetDailyReport, ShowReportDto>
{
    private readonly IShowRepository _repository;

    public GetDailyReportHandler(IShowRepository repository)
    {
        _repository = repository;
    }

    public async Task<ShowReportDto> Handle(GetDailyReport request, CancellationToken cancellationToken)
    {
        var shows = (await _repository.GetShowsByDateAsync(request.date.Date))
            .OrderBy(s => s.StartTime)
            .ToList();

        return new ShowReportDto
        {
            Date = request.date.Date,
            TotalShows = shows.Count,
            TotalDuration = shows.Sum(s => s.Duration),
            Shows = shows.Select(s => s.AsDto()).ToList()
        };
    }
}