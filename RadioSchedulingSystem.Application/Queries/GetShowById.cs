using MediatR;
using RadioSchedulingSystem.Application.DTO;

namespace RadioSchedulingSystem.Application.Queries;

public record GetShowById(Guid id) : IRequest<ShowDto?>;