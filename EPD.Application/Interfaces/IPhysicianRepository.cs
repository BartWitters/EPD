using EPD.Domain.Entities;

namespace EPD.Application.Interfaces;

public interface IPhysicianRepository
{
    Task AddPhysicianAsync(Physician Physician);
    Task<IEnumerable<Physician>> GetAllPhysiciansAsync();
    Task<Physician?> GetPhysicianByIdAsync(int id);
    Task DeletePhysicianAsync(Physician Physician);
}