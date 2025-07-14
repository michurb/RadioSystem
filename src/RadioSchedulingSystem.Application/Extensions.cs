using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Validators;

namespace RadioSchedulingSystem.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(mediatRServiceConfiguration =>
            {
                mediatRServiceConfiguration.RegisterServicesFromAssembly(typeof(Extensions).Assembly);
            })
            .AddScoped<IValidator<CreateShowDto>, CreateShowValidator>();
        return services;
    }
}