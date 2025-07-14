using MediatR;
using RadioSchedulingSystem.Application.DTO;

namespace RadioSchedulingSystem.Application.Queries;

public record GetShowByDate(DateTime date) : IRequest<IEnumerable<ShowDto>>;