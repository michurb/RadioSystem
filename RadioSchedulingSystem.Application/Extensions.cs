using Microsoft.Extensions.DependencyInjection;

namespace RadioSchedulingSystem.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(mediatRServiceConfiguration =>
        {
            mediatRServiceConfiguration.RegisterServicesFromAssembly(typeof(Extensions).Assembly);
        });
        return services;
    }
}