namespace EPD.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public required DateOnly Date {  get; set; }
    public required string Time { get; set; }
    public required int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public required int PhysicianId { get; set; }
    public Physician? Physician { get; set; }
}
