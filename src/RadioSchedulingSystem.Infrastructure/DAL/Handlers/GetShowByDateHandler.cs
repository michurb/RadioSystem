using MediatR;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Queries;
using RadioSchedulingSystem.Domain.Interfaces;

namespace RadioSchedulingSystem.Infrastructure.DAL.Handlers;

public class GetShowByDateHandler : IRequestHandler<GetShowByDate, IEnumerable<ShowDto>>
{
    private readonly IShowRepository _showRepository;

    public GetShowByDateHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository ?? throw new ArgumentNullException(nameof(showRepository));
    }

    public async Task<IEnumerable<ShowDto>> Handle(GetShowByDate request, CancellationToken cancellationToken)
    {
        var shows = await _showRepository.GetShowsByDateAsync(request.date.Date);
        return shows.Select(show => show.AsDto()).ToList();
    }
}