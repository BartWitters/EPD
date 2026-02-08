using EPD.Domain.Interfaces;

namespace EPD.Domain.Entities;

public class Physician : IIDExists
{
    public int Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public required string Specialization { get; set; }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();
}
