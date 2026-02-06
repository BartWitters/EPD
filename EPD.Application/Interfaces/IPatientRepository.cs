namespace EPD.Application.Interfaces;

public interface IPatientRepository
{
    Task AddPatientAsync(Domain.Entities.Patient patient);

    IEnumerable<Domain.Entities.Patient> GetAllPatients();
    Task DeletePatientAsync(Domain.Entities.Patient patient);
}