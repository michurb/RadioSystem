using Microsoft.EntityFrameworkCore;
using RadioSchedulingSystem.Domain.Entities;
using RadioSchedulingSystem.Domain.Interfaces;
using RadioSchedulingSystem.Infrastructure.DAL;

namespace RadioSchedulingSystem.Infrastructure.Repositories;

public class ShowRepository : IShowRepository
{
    private readonly RadioSystemDbContext _context;

    public ShowRepository(RadioSystemDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAsync(Show show)
    {
        _context.Shows.Add(show);
        await _context.SaveChangesAsync();
    }

    public async Task<Show?> GetByIdAsync(Guid id)
    {
        return await _context.Shows
            .FirstAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Show>> GetShowsByDateAsync(DateTime date)
    {
        return await _context.Shows
            .Where(s => s.StartTime.Date == date)
            .ToListAsync();
    }
}