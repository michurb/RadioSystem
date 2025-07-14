using MediatR;
using RadioSchedulingSystem.Application.DTO;

namespace RadioSchedulingSystem.Application.Queries;

public record GetDailyReport(DateTime date) : IRequest<ShowReportDto>;