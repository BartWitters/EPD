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
        var Patient = new Patient
        {
            LastName = lastName,
            FirstName = firstName,
            DateOfBirth = dateOfBirth,
            NationalRegisterNumber = nationalRegisterNumber,
            Street = street,
            StreetNumber = streetNumber,
            AptNumber = aptNumber,
            City = city,
            EmailAddress = emailAddress
        };

        await _PatientRepository.AddPatientAsync(Patient);
    }

    public IEnumerable<Patient> GetAllPatients()
    {
        return _PatientRepository.GetAllPatients();
    }

    public async Task DeletePatientAsync(int PatientId)
    {
        var allPatients = _PatientRepository.GetAllPatients();
        var patientToDelete = allPatients.FirstOrDefault(p => p.Id == PatientId);
        if (patientToDelete != null)
        {
            await _PatientRepository.DeletePatientAsync(patientToDelete);
        }
    }
}
