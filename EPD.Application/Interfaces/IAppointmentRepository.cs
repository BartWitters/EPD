using EPD.Domain.Entities;

namespace EPD.Application.Interfaces;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();

}