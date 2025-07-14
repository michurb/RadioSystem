using MediatR;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Queries;
using RadioSchedulingSystem.Domain.Interfaces;

namespace RadioSchedulingSystem.Infrastructure.DAL.Handlers;

public class GetShowByIdHandler : IRequestHandler<GetShowById, ShowDto>
{
    private readonly IShowRepository _showRepository;

    public GetShowByIdHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public async Task<ShowDto> Handle(GetShowById request, CancellationToken cancellationToken)
    {
        var show = await _showRepository.GetByIdAsync(request.id);
        return show.AsDto();
    }
}