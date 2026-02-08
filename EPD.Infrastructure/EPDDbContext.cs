using EPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPD.Infrastructure;

public class EPDDbContext : DbContext
{
    public EPDDbContext(DbContextOptions<EPDDbContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Physician> Physicians { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Patient)
        .WithMany(p => p.Appointments)
        .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Physician)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.PhysicianId);

        base.OnModelCreating(modelBuilder);
    }
}
