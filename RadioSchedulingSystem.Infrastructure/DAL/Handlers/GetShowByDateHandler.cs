using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Queries;
using RadioSchedulingSystem.Domain.Entities;
using RadioSchedulingSystem.Domain.Interfaces;

namespace RadioSchedulingSystem.Infrastructure.DAL.Handlers;

public class GetShowByDateHandler : IRequestHandler<GetShowByDate, IEnumerable<ShowDto>>
{
    private readonly IShowRepository _showRepository;

    public GetShowByDateHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }
    
    public async Task<IEnumerable<ShowDto>> Handle(GetShowByDate request, CancellationToken cancellationToken)
    {
        var shows = await _showRepository.GetShowsByDateAsync(request.date.Date);
        return shows.Select(show => show.AsDto()).ToList();
    }
}