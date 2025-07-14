using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadioSchedulingSystem.Application.Interfaces;
using RadioSchedulingSystem.Domain.Interfaces;
using RadioSchedulingSystem.Infrastructure.DAL;
using RadioSchedulingSystem.Infrastructure.Notifications;
using RadioSchedulingSystem.Infrastructure.Repositories;

namespace RadioSchedulingSystem.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RadioSystemDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("RadioSystemDb")));
        services.AddScoped<IShowRepository, ShowRepository>();
        services.AddScoped<INotificationChannel, EmailChannel>();
        
        services.AddMediatR(mediatRServiceConfiguration =>
        {
            mediatRServiceConfiguration.RegisterServicesFromAssembly(typeof(Extensions).Assembly);
        });
        
        return services;
    }
}