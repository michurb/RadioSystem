using MediatR;
using RadioSchedulingSystem.Application.DTO;

namespace RadioSchedulingSystem.Application.Commands;

public sealed record CreateShow(CreateShowDto dto) : IRequest<Guid>;