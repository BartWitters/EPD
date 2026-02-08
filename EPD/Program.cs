using EPD.Application.Interfaces;
using EPD.Application.Services;
using EPD.Domain.Entities;
using EPD.Infrastructure;
using EPD.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EPD.Presentation;

public class Program
{
    #region FreeCodeForAssignment
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<EPDDbContext>(options => options.UseSqlite("Data Source=epd.db"));

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IPhysicianRepository, PhysicianRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<PatientService>();
        services.AddScoped<PhysicianService>();
        services.AddScoped<AppointmentService>();
        services.AddTransient<Menu>();

        using var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<EPDDbContext>();
        dbContext.Database.EnsureCreated();

        var menu = serviceProvider.GetRequiredService<Menu>();

        while (await ShowMenu(menu, serviceProvider))
        {
            Console.WriteLine("Om terug naar het menu te gaan, druk op een knop naar keuze.");
            Console.ReadKey();
        }
    }

    public static async Task<bool> ShowMenu(Menu menu, IServiceProvider serviceProvider)
    {
        Console.Clear();
        foreach (var line in File.ReadAllLines("logo.txt"))
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("");
        Console.WriteLine("1 - Patient toevoegen");
        Console.WriteLine("2 - Patienten verwijderen");
        Console.WriteLine("3 - Arts toevoegen");
        Console.WriteLine("4 - Arts verwijderen");
        Console.WriteLine("5 - Afspraak toevoegen");
        Console.WriteLine("6 - Afspraken inzien voor patiënt");
        Console.WriteLine("7 - Afspraken inzien voor dokter");
        Console.WriteLine("8 - Sluiten");
        Console.WriteLine("9 - Reset db");

        if (int.TryParse(Console.ReadLine(), out int option))
        {
            switch (option)
            {
                case 1:
                    await menu.AddPatientAsync();
                    return true;
                case 2:
                    await menu.DeletePatientAsync();
                    return true;
                case 3:
                    await menu.AddPhysicianAsync();
                    return true;
                case 4:
                    await menu.DeletePhysicianAsync();
                    return true;
                case 5:
                    await menu.AddAppointmentAsync();
                    return true;
                case 6:
                    await menu.ShowAppointmentsForPersonAsync<Patient>();
                    return true;
                case 7:
                    await menu.ShowAppointmentsForPersonAsync<Physician>();
                    return true;
                case 8:
                    return false;
                case 9:
                    var dbContext = serviceProvider.GetRequiredService<EPDDbContext>();
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    return true;
                default:
                    return true;
            }
        }
        return true;
    }
    #endregion
}