using EPD.Application.Interfaces;
using EPD.Domain.Entities;

namespace EPD.Application.Services;

public class PhysicianService
{
    private readonly IPhysicianRepository _PhysicianRepository;

    public PhysicianService(IPhysicianRepository PhysicianRepository)
    {
        _PhysicianRepository = PhysicianRepository;
    }

    public async Task AddPhysicianAsync(string firstName, string lastName, string specialization)
    {
        var Physician = new Physician
        {
            LastName = lastName,
            FirstName = firstName,
            Specialization = specialization
        };

        await _PhysicianRepository.AddPhysicianAsync(Physician);
    }

    public IEnumerable<Physician> GetAllPhysicians()
    {
        return _PhysicianRepository.GetAllPhysicians();
    }

    public async Task DeletePhysicianAsync(int PhysicianId)
    {
        var allPhysicians = _PhysicianRepository.GetAllPhysicians();
        var PhysicianToDelete = allPhysicians.FirstOrDefault(d => d.Id == PhysicianId);
        if (PhysicianToDelete != null)
        {
            await _PhysicianRepository.DeletePhysicianAsync(PhysicianToDelete);
        }
    }
}
