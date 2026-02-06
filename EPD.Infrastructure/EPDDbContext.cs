using EPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPD.Infrastructure;

public class EPDDbContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Physician> Physicians { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=epd.db");
}
