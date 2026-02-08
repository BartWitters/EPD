using EPD.Application.Interfaces;
using EPD.Domain.Entities;

namespace EPD.Application.Services;

public class AppointmentService
{
    private readonly IAppointmentRepository _AppointmentRepository;
    private readonly IPatientRepository _PatientRepository;
    private readonly IPhysicianRepository _PhysicianRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, IPhysicianRepository physicianRepository)
    {
        _AppointmentRepository = appointmentRepository;
        _PatientRepository = patientRepository;
        _PhysicianRepository = physicianRepository;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
    {
        return await _AppointmentRepository.GetAllAppointmentsAsync();
    }

    public async Task AddAppointmentAsync(int patientId, int physicianId, DateOnly date, string time)
    {
        var patient = await _PatientRepository.GetPatientByIdAsync(patientId) ?? throw new ArgumentException($"Patient with ID {patientId} does not exist.");
        var physician = await _PhysicianRepository.GetPhysicianByIdAsync(physicianId) ?? throw new ArgumentException($"Physician with ID {physicianId} does not exist.");
        
        var appointment = new Appointment
        {
            PatientId = patientId,
            PhysicianId = physicianId,
            Date = date,
            Time = time
        };

        patient.AddAppointment(date, time, physician);
        await _PatientRepository.SaveAsync(patient);
    }
}
