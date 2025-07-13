using System.Reflection;
using RadioSchedulingSystem.Application.Commands;
using RadioSchedulingSystem.Infrastructure;
using RadioSchedulingSystem.Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateShow).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(Extensions).Assembly);
});

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RadioSystemDbContext>();

    await context.Database.EnsureCreatedAsync();
    DatabaseInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();