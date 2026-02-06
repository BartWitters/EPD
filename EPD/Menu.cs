using EPD.Application.Services;
using EPD.Infrastructure;

namespace EPD.Presentation;

public class Menu
{
    private readonly PatientService _patientService;
    private readonly PhysicianService _physicianService;

    public Menu(EPDDbContext dbContext)
    {
        _patientService = new PatientService(new Infrastructure.Repositories.PatientRepository(dbContext));
        _physicianService = new PhysicianService(new Infrastructure.Repositories.PhysicianRepository(dbContext));
    }

    public async Task AddPatientAsync()
    {
        var lastNamePatient = InputHelper.GetNonEmptyStringInput("familienaam");
        var firstNamePatient = InputHelper.GetNonEmptyStringInput("voornaam");
        var dateOfBirthPatient = InputHelper.GetValidDateOfBirth();
        var nationalRegisterNumberPatient = InputHelper.GetValidNationalRegisterNumber(dateOfBirthPatient);
        var streetPatient = InputHelper.GetNonEmptyStringInput("straatnaam");
        var streetNumberPatient = InputHelper.GetValidPositiveIntegerInput("straatnummer");
        var aptNumberPatient = InputHelper.GetValidAptNumberInput();
        var cityPatient = InputHelper.GetNonEmptyStringInput("stad");
        var emailAddressPatient = InputHelper.GetValidEmailInput();

        await _patientService.AddPatientAsync(firstNamePatient, lastNamePatient, dateOfBirthPatient, nationalRegisterNumberPatient, streetPatient, streetNumberPatient, aptNumberPatient, cityPatient, emailAddressPatient);

        Console.WriteLine($"Patient {lastNamePatient} {firstNamePatient} is toegevoegd.");
    }

    public async Task DeletePhysicianAsync()
    {
        var allDoctors = _physicianService.GetAllPhysicians();

        if (!allDoctors.Any())
        {
            Console.WriteLine("Er zijn geen dokters om te verwijderen.");
            return;
        }

        foreach (var doctor in allDoctors)
        {
            Console.WriteLine($"ID: {doctor.Id}, naam: {doctor.LastName} {doctor.FirstName}");
        }

        var doctorIdToDelete = InputHelper.GetExistingId("dokter", allDoctors);

        await _physicianService.DeletePhysicianAsync(doctorIdToDelete);

        Console.WriteLine($"Dokter met ID {doctorIdToDelete} is verwijderd.");
    }

    public void AddAppointment()
    {

    }

    public void ShowAppointment()
    {

    }

    public async Task AddPhysicianAsync()
    {
        Console.WriteLine("Geef familienaam dokter in:");
        var lastNamePhysician = InputHelper.GetNonEmptyStringInput("familienaam");

        Console.WriteLine("Geef voornaam dokter in:");
        var firstNamePhysician = InputHelper.GetNonEmptyStringInput("voornaam");

        Console.WriteLine("Geef specialisatie dokter in:");
        var specializationPhysician = InputHelper.GetNonEmptyStringInput("specialisatie");

        await _physicianService.AddPhysicianAsync(firstNamePhysician, lastNamePhysician, specializationPhysician);

        Console.WriteLine($"Dokter {lastNamePhysician} {firstNamePhysician} is toegevoegd.");
    }

    public async Task DeletePatientAsync()
    {
        var allPatients = _patientService.GetAllPatients();

        if (!allPatients.Any())
        {
            Console.WriteLine("Er zijn geen patiënten om te verwijderen.");
            return;
        }

        foreach (var patient in allPatients)
        {
            Console.WriteLine($"ID: {patient.Id}, naam: {patient.LastName} {patient.FirstName}");
        }

        var patientIdToDelete = InputHelper.GetExistingId("patient", allPatients);

        await _patientService.DeletePatientAsync(patientIdToDelete);


        Console.WriteLine($"Patiënt met ID {patientIdToDelete} is verwijderd.");
    }
}
