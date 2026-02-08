using EPD.Application.Services;
using EPD.Domain.Entities;
using EPD.Domain.Interfaces;

namespace EPD.Presentation;

public class Menu
{
    private readonly PatientService _patientService;
    private readonly PhysicianService _physicianService;
    private readonly AppointmentService _appointmentService;

    public Menu(PatientService patientService, PhysicianService physicianService, AppointmentService appointmentService)
    {
        _patientService = patientService;
        _physicianService = physicianService;
        _appointmentService = appointmentService;
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
        var allPhysicians = await _physicianService.GetAllPhysiciansAsync();

        if (!allPhysicians.Any())
        {
            Console.WriteLine("Er zijn geen dokters om te verwijderen.");
            return;
        }

        foreach (var doctor in allPhysicians)
        {
            Console.WriteLine($"ID: {doctor.Id}, naam: {doctor.LastName} {doctor.FirstName}");
        }

        var doctorIdToDelete = InputHelper.GetExistingId("dokter", allPhysicians);

        await _physicianService.DeletePhysicianAsync(doctorIdToDelete);

        Console.WriteLine($"Dokter met ID {doctorIdToDelete} is verwijderd.");
    }

    public async Task AddAppointmentAsync()
    {
        var allPatients = await _patientService.GetAllPatientsAsync();

        if (!allPatients.Any())
        {
            Console.WriteLine("Er zijn geen patiënten om te verwijderen.");
            return;
        }

        foreach (var patient in allPatients)
        {
            Console.WriteLine($"ID: {patient.Id}, naam: {patient.LastName} {patient.FirstName}");
        }

        var patientIdToBeUpdated = InputHelper.GetExistingId("patient", allPatients);

        var allPhysicians = await _physicianService.GetAllPhysiciansAsync();

        if (!allPhysicians.Any())
        {
            Console.WriteLine("Er zijn geen dokters om te verwijderen.");
            return;
        }

        foreach (var doctor in allPhysicians)
        {
            Console.WriteLine($"ID: {doctor.Id}, naam: {doctor.LastName} {doctor.FirstName}");
        }

        var physicianIdToBeAdded = InputHelper.GetExistingId("dokter", allPhysicians);

        Console.WriteLine("Geef datum van afspraak in (dd-mm-jjjj):");
        var dateOfAppointment = Console.ReadLine();

        Console.WriteLine("Geef tijd van afspraak in (hh:mm):");
        var timeOfAppointment = Console.ReadLine();

        await _appointmentService.AddAppointmentAsync(patientIdToBeUpdated, physicianIdToBeAdded, DateOnly.ParseExact(dateOfAppointment, "dd-MM-yyyy"), timeOfAppointment);

        Console.WriteLine($"Afspraak voor patiënt met ID {patientIdToBeUpdated} is aangemaakt.");
    }

    public async Task ShowAppointmentsForPersonAsync<T>() where T : IIDExists
    {
        var allAppointments = await _appointmentService.GetAllAppointmentsAsync();
        if (allAppointments == null || !allAppointments.Any())
        {
            Console.WriteLine("Er zijn geen afspraken.");
            return;
        }

        IEnumerable<T> allPersons;
        string personTextSingular;
        string personTextPlural;

        if (typeof(T) == typeof(Patient))
        {
            allPersons = (IEnumerable<T>)await _patientService.GetAllPatientsAsync();
            personTextSingular = "patiënt";
            personTextPlural = "patiënten";
        }
        else if(typeof(T) == typeof(Physician))
        {
            allPersons = (IEnumerable<T>)await _physicianService.GetAllPhysiciansAsync();
            personTextSingular = "dokter";
            personTextPlural = "dokters";
        }
        else
        {
            Console.WriteLine("Dit type persoon bestaat (nog) niet.");
            return;
        }

        if (!allPersons.Any())
        {
            Console.WriteLine($"Er zijn geen {personTextPlural}.");
            return;
        }

        foreach (var person in allPersons)
        {
            Console.WriteLine($"ID: {person.Id}, naam: {person.LastName} {person.FirstName}");
        }

        var personId = InputHelper.GetExistingId(personTextSingular, allPersons);

        var appointmentsForPerson = allAppointments.Where(appointment => (typeof(T) == typeof(Patient) && appointment.PatientId == personId) || (typeof(T) == typeof(Physician) && appointment.PhysicianId == personId));

        if (!appointmentsForPerson.Any())
        {
            Console.WriteLine($"Er zijn geen afspraken voor deze {personTextSingular}.");
            return;
        }

        foreach (var appointment in appointmentsForPerson)
        {
            Console.WriteLine($"Afspraak ID: {appointment.Id}, Dokter ID: {(typeof(T) == typeof(Patient) ? appointment.PatientId : appointment.PhysicianId)}, Datum: {appointment.Date}, Tijd: {appointment.Time}");
        }
    }

    public async Task AddPhysicianAsync()
    {
        var lastNamePhysician = InputHelper.GetNonEmptyStringInput("familienaam");
        var firstNamePhysician = InputHelper.GetNonEmptyStringInput("voornaam");
        var specializationPhysician = InputHelper.GetNonEmptyStringInput("specialisatie");

        await _physicianService.AddPhysicianAsync(firstNamePhysician, lastNamePhysician, specializationPhysician);

        Console.WriteLine($"Dokter {lastNamePhysician} {firstNamePhysician} is toegevoegd.");
    }

    public async Task DeletePatientAsync()
    {
        var allPatients = await _patientService.GetAllPatientsAsync();

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
