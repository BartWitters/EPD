using EPD.Application.Interfaces;
using EPD.Domain.Entities;

namespace EPD.Application.Services;

public class PatientService
{
    private readonly IPatientRepository _PatientRepository;

    public PatientService(IPatientRepository PatientRepository)
    {
        _PatientRepository = PatientRepository;
    }

    public async Task AddPatientAsync(string firstName, string lastName, DateOnly dateOfBirth, string nationalRegisterNumber, string street, int streetNumber, int aptNumber, string city, string emailAddress)
    {
        
        var patient = Patient.Create(firstName, lastName, dateOfBirth, nationalRegisterNumber, street, streetNumber, aptNumber, city, emailAddress);

        await _PatientRepository.AddPatientAsync(patient);
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
        return await _PatientRepository.GetAllPatientsAsync();
    }

    public async Task DeletePatientAsync(int patientId)
    {
        var patientToDelete = await _PatientRepository.GetPatientByIdAsync(patientId);
        if (patientToDelete != null)
        {
            await _PatientRepository.DeletePatientAsync(patientToDelete);
        }
    }
}
