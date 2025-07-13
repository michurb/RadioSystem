using MediatR;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Domain.Entities;

namespace RadioSchedulingSystem.Application.Queries;

public record GetShowByDate(DateTime date) : IRequest<IEnumerable<ShowDto>>;