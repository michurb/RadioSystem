using RadioSchedulingSystem.Domain.Entities;

namespace RadioSchedulingSystem.Domain.Interfaces;

public interface IShowRepository
{
    Task AddAsync(Show show);
    Task<Show?> GetByIdAsync(Guid id);
    Task<IEnumerable<Show>> GetShowsByDateAsync(DateTime date);
}