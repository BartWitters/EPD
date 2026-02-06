namespace EPD.Application.DTOs;

public class PhysicianDto
{
    public record AddPhysicianRequest(string FirstName, string LastName, string Specialization);
}
