using EPD.Domain.Interfaces;

namespace EPD.Domain.Entities;

public class Patient : IIDExists
{
    public int Id { get; set; }
    public required string LastName { get; set;  }
    public required string FirstName { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string NationalRegisterNumber { get; set; }
    public required string Street {  get; set; }
    public required int StreetNumber { get; set; }
    public int AptNumber { get; set; }
    public required string City { get; set; }
    public required string EmailAddress { get; set; }
    public List<Appointment>? Appointments { get; set; }
}
