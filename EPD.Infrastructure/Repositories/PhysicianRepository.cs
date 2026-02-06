using EPD.Application.Interfaces;
using EPD.Domain.Entities;

namespace EPD.Infrastructure.Repositories;

public class PhysicianRepository : IPhysicianRepository
{
    private readonly EPDDbContext _dbContext;

    public PhysicianRepository(EPDDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPhysicianAsync(Physician Physician)
    {
        _dbContext.Physicians.Add(Physician);
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<Physician> GetAllPhysicians()
    {
        return [.. _dbContext.Physicians];
    }

    public async Task DeletePhysicianAsync(Physician Physician)
    {
        _dbContext.Physicians.Remove(Physician);
        await _dbContext.SaveChangesAsync();
    }
}
