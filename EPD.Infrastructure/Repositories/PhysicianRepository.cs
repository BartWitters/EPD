using EPD.Application.Interfaces;
using EPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Physician>> GetAllPhysiciansAsync()
    {
        return await _dbContext.Physicians.ToListAsync();
    }

    public async Task<Physician?> GetPhysicianByIdAsync(int id)
    {
        return await _dbContext.Physicians.FirstOrDefaultAsync(physician => physician.Id == id);
    }

    public async Task DeletePhysicianAsync(Physician Physician)
    {
        _dbContext.Physicians.Remove(Physician);
        await _dbContext.SaveChangesAsync();
    }
}
