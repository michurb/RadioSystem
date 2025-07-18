using RadioSchedulingSystem.Application;
using RadioSchedulingSystem.Infrastructure;
using RadioSchedulingSystem.Infrastructure.DAL;
using RadioSchedulingSystem.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddProvider(new ErrorFileLoggerProvider());

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RadioSystemDbContext>();

    await context.Database.EnsureCreatedAsync();
    DatabaseInitializer.Initialize(context);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();