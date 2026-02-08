using EPD.Application.Interfaces;
using EPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPD.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{

    private readonly EPDDbContext _dbContext;

    public AppointmentRepository(EPDDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
    {
        return await _dbContext.Appointments
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Physician)
            .ToListAsync();
    }
}
