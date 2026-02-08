using EPD.Domain.Entities;
using EPD.Domain.Interfaces;

namespace EPD.Presentation;

public class InputHelper
{
    public static string GetNonEmptyStringInput(string prompt)
    {
        Console.WriteLine($"Geef {prompt} in: ");
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input mag niet leeg zijn, probeer opnieuw:");
            input = Console.ReadLine();
        }

        return input;
    }

    public static DateOnly GetValidDateOfBirth()
    {
        Console.WriteLine($"Geef geboortedatum (formaat dd/MM/yyyy) patiënt in: ");
        string? input = Console.ReadLine();

        DateOnly dateOfBirth;

        while (!Validators.DateIsValid(input, out dateOfBirth) || dateOfBirth > DateOnly.FromDateTime(DateTime.Now))
        {
            Console.WriteLine("Input is niet geldig, probeer opnieuw (formaat moet dd/MM/yyyy zijn):");
            input = Console.ReadLine();
        }

        return dateOfBirth;
    }

    public static string GetValidNationalRegisterNumber(DateOnly dateOfBirth)
    {
        Console.WriteLine($"Geef rijksregisternummer patiënt in (11 cijfers achter elkaar):");
        string? input = Console.ReadLine();

        while (string.IsNullOrEmpty(input) || !Validators.NationalRegisterNumberIsValid(input, dateOfBirth))
        {
            Console.WriteLine("Input is niet geldig, probeer opnieuw:");
            input = Console.ReadLine();
        }

        return $"{input[..2]}.{input.Substring(2, 2)}.{input.Substring(4, 2)}-{input.Substring(6, 3)}.{input.Substring(9, 2)}";
    }

    public static int GetValidPositiveIntegerInput(string prompt)
    {
        Console.WriteLine($"Geef {prompt} patiënt in (enkel cijfers):");
        string? input = Console.ReadLine();

        int integerValue;
        
        while (!Validators.InputIsIntegerAndGreaterThanZero(input, out integerValue))
        {
            Console.WriteLine("Input is niet geldig, probeer opnieuw (formaat mag enkel cijfers bevatten):");
            input = Console.ReadLine();
        }

        return integerValue;
    }

    public static int GetValidAptNumberInput()
    {
        Console.WriteLine("Geef busnummer patiënt in (indien geen busnummer, vul dan 0 in; enkel cijfers):");
        string? input = Console.ReadLine();

        int integerValue;
        
        while (!Validators.InputIsIntegerAndGreaterThanZero(input, out integerValue) && input != "0")
        {
            Console.WriteLine("Input is niet geldig, probeer opnieuw (formaat mag enkel cijfers bevatten, of vul 0 in indien geen busnummer):");
            input = Console.ReadLine();
        }

        return integerValue;
    }

    public static string GetValidEmailInput()
    {
        Console.WriteLine("Geef e-mailadres patiënt in:");
        string? input = Console.ReadLine();

        while (string.IsNullOrEmpty(input) || !Validators.EmailIsValid(input))
        {
            Console.WriteLine("Input is niet geldig, probeer opnieuw (e-mailadres moet een '@' bevatten):");
            input = Console.ReadLine();
        }

        return input;
    }

    public static int GetExistingId<T>(string prompt, IEnumerable<T> collection) where T : IIDExists
    {
        Console.WriteLine($"Geef Id {prompt} in:");
        string? input = Console.ReadLine();

        int integerValue;

        while (!Validators.InputIsIntegerAndGreaterThanZero(input, out integerValue) || !collection.Any(value => value.Id == integerValue))
        {
            Console.WriteLine("Input is niet geldig, probeer opnieuw (nummer moet uit de lijst komen):");
            input = Console.ReadLine();
        }

        return integerValue;
    }
}
