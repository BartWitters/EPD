using EPD.Infrastructure;

namespace EPD.Presentation;

public class Program
{
    #region FreeCodeForAssignment
    static async Task Main(string[] args)
    {
        EPDDbContext dbContext = new();
        dbContext.Database.EnsureCreated();

        var menu = new Menu(dbContext);

        while (await ShowMenu(menu))
        {
            Console.WriteLine("Om terug naar het menu te gaan, druk op een knop naar keuze.");
            Console.ReadKey();
        }
    }

    public static async Task<bool> ShowMenu(Menu menu)
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
        Console.WriteLine("6 - Afspraken inzien");
        Console.WriteLine("7 - Sluiten");
        Console.WriteLine("8 - Reset db");

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
                    menu.AddAppointment();
                    return true;
                case 6:
                    menu.ShowAppointment();
                    return true;
                case 7:
                    return false;
                case 8:
                    EPDDbContext dbContext = new EPDDbContext();
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