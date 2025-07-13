using RadioSchedulingSystem.Domain.Entities;

namespace RadioSchedulingSystem.Infrastructure.DAL;

public static class DatabaseInitializer
{
 public static void Initialize(RadioSystemDbContext context)
 {
     if (context.Shows.Any()) return;

     var shows = new List<Show>
     {
         new()
         {
             Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
             Title = "Morning Jazz",
             Presenter = "Alice Smith",
             StartTime = DateTime.UtcNow.Date.AddHours(9),
             Duration = 60
         },
         new()
         {
             Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
             Title = "News Hour",
             Presenter = "Bob Johnson",
             StartTime = DateTime.UtcNow.Date.AddHours(10),
             Duration = 30
         },
         new()
         {
             Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
             Title = "Afternoon Rock",
             Presenter = "Cathy Lee",
             StartTime = DateTime.UtcNow.Date.AddHours(14),
             Duration = 90
         }
     };
     
     context.Shows.AddRange(shows);
     context.SaveChanges();
 }
}