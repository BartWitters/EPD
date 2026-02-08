using EPD.Domain.Entities;

namespace EPD.Application.Interfaces;

public interface IPatientRepository
{
    Task AddPatientAsync(Patient patient);
    Task<IEnumerable<Patient>> GetAllPatientsAsync();
    Task<Patient?> GetPatientByIdAsync(int id);
    Task DeletePatientAsync(Patient patient);
    Task SaveAsync(Patient patient);
}