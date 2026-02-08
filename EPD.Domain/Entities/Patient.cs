using EPD.Domain.Interfaces;
using EPD.Domain.ValueObjects;

namespace EPD.Domain.Entities;

public class Patient : IIDExists
{
    public int Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string NationalRegisterNumber { get; set; }
    public required string Street { get; set; }
    public required int StreetNumber { get; set; }
    public int AptNumber { get; set; }
    public required string City { get; set; }

    private Email? _emailValueObject;

    public required string EmailAddress {
        get => _emailValueObject.Value;
        set => _emailValueObject = new Email(value);
    }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

    public static Patient Create(string firstName, string lastName, DateOnly dateOfBirth, string nationalRegisterNumber, string street, int streetNumber, int aptNumber, string city, string emailAddress)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException("First name is required.", nameof(firstName));
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Last name is required.", nameof(lastName));
        if (string.IsNullOrEmpty(street))
            throw new ArgumentException("Street is required.", nameof(street));

        var email = new Email(emailAddress);

        var patient = new Patient
        {
            LastName = lastName,
            FirstName = firstName,
            DateOfBirth = dateOfBirth,
            NationalRegisterNumber = nationalRegisterNumber,
            Street = street,
            StreetNumber = streetNumber,
            AptNumber = aptNumber,
            City = city,
            EmailAddress = email.Value,
            _emailValueObject = email
        };

        return patient;
    }

    public void AddAppointment(DateOnly date, string time, Physician physician)
    {
        var appointment = new Appointment
        {
            Date = date,
            Time = time,
            Physician = physician,
            Patient = this,
            PatientId = Id,
            PhysicianId = physician.Id
        };
        
        Appointments.Add(appointment);
    }
}
