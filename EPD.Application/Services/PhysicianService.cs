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

    /// <summary>
    /// This will asynchronously add a new physician  to the database.
    /// </summary>
    /// <param name="firstName">First name of the physician</param>
    /// <param name="lastName">Last name of the physician</param>
    /// <param name="specialization">Specialization of the physician</param>
    /// <returns></returns>
    public async Task AddPhysicianAsync(string firstName, string lastName, string specialization)
    {
        var physician = new Physician
        {
            LastName = lastName,
            FirstName = firstName,
            Specialization = specialization
        };

        await _PhysicianRepository.AddPhysicianAsync(physician);
    }

    /// <summary>
    /// This will asynchronously retrieves a collection of all physicians from the repository.
    /// </summary>
    /// <returns>An enumerable collection of Physician objects</returns>
    public async Task<IEnumerable<Physician>> GetAllPhysiciansAsync()
    {
        return await _PhysicianRepository.GetAllPhysiciansAsync();
    }

    /// <summary>
    /// This will asynchronously delete a physician from the database.
    /// </summary>
    /// <param name="physicianId">The Id of the physician</param>
    /// <returns></returns>
    public async Task DeletePhysicianAsync(int physicianId)
    {
        var physicianToDelete = await _PhysicianRepository.GetPhysicianByIdAsync(physicianId);
        if (physicianToDelete != null)
        {
            await _PhysicianRepository.DeletePhysicianAsync(physicianToDelete);
        }
    }
}
