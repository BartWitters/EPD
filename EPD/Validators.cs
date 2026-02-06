using System.Globalization;

namespace EPD.Presentation;

internal class Validators
{
    public static bool DateIsValid(string? input, out DateOnly dateOfBirth)
        => DateOnly.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

    public static bool HourIsValid(string? input, out TimeOnly appointmentHour)
        => TimeOnly.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out appointmentHour);

    public static bool NationalRegisterNumberIsValid(string? input, DateOnly dateOfBirth)
    {
        if (string.IsNullOrEmpty(input) || input.Length != 11 || !input.All(char.IsDigit) || !input.StartsWith(dateOfBirth.ToString("yyMMdd")))
        {
            return false;
        }

        return true;
    }

    public static bool InputIsIntegerAndGreaterThanZero(string? input, out int integerValue)
        => Int32.TryParse(input, out integerValue) && integerValue > 0;

    public static bool EmailIsValid(string? input)
    {
        try
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var address = new System.Net.Mail.MailAddress(input);
            return address.Address == input;
        }
        catch
        {
            return false;
        }
    }
}
