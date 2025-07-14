using Microsoft.EntityFrameworkCore;
using RadioSchedulingSystem.Domain.Entities;

namespace RadioSchedulingSystem.Infrastructure.DAL;

public class RadioSystemDbContext : DbContext
{
    public RadioSystemDbContext(DbContextOptions<RadioSystemDbContext> options)
        : base(options)
    {
    }

    public DbSet<Show> Shows { get; set; }
}