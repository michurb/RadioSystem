using Microsoft.EntityFrameworkCore;
using RadioSchedulingSystem.Domain.Entities;

namespace RadioSchedulingSystem.Infrastructure.DAL;

public class RadioSystemDbContext : DbContext
{
    public DbSet<Show> Shows { get; set; }
    
    public RadioSystemDbContext(DbContextOptions<RadioSystemDbContext> options)
        : base(options)
    {
    }
}