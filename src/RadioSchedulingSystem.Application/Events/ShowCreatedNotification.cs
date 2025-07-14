using MediatR;
using RadioSchedulingSystem.Domain.Entities;

namespace RadioSchedulingSystem.Application.Events;

public record ShowCreatedNotification(Show Show) : INotification;