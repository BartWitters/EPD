namespace EPD.Application.DTOs;

internal class AppointmentDto
{
    public required DateOnly Date { get; set; }
    public required TimeOnly Time { get; set; }
    public required string PhysicianLastName { get; set; }
    public required string PatientFullName { get; set; }
}
