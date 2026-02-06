namespace EPD.Application.Interfaces;

public interface IPhysicianRepository
{
    Task AddPhysicianAsync(Domain.Entities.Physician Physician);
    IEnumerable<Domain.Entities.Physician> GetAllPhysicians();
    Task DeletePhysicianAsync(Domain.Entities.Physician Physician);
}