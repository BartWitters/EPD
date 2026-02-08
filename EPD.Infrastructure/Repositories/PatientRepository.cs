using EPD.Application.Interfaces;
using EPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPD.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly EPDDbContext _dbContext;

    public PatientRepository(EPDDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPatientAsync(Patient patient)
    {
        _dbContext.Patients.Add(patient);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
        return await _dbContext.Patients.ToListAsync();
    }

    public async Task<Patient?> GetPatientByIdAsync(int id)
    {
        return await _dbContext.Patients.FirstOrDefaultAsync(patient => patient.Id == id);
    }

    public async Task DeletePatientAsync(Patient patient)
    {
        _dbContext.Patients.Remove(patient);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveAsync(Patient patient)
    {
        await _dbContext.SaveChangesAsync();
    }
}
