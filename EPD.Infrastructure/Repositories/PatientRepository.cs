using EPD.Application.Interfaces;
using EPD.Domain.Entities;

namespace EPD.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly EPDDbContext _dbContext;

    public PatientRepository(EPDDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPatientAsync(Patient Patient)
    {
        _dbContext.Patients.Add(Patient);
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<Patient> GetAllPatients()
    {
        return [.. _dbContext.Patients];
    }

    public async Task DeletePatientAsync(Patient Patient)
    {
        _dbContext.Patients.Remove(Patient);
        await _dbContext.SaveChangesAsync();
    }
}
