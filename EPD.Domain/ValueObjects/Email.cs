namespace EPD.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email address is required.", nameof(value));

        // Example of check on the @ symbol.
        if (!value.Contains('@'))
            throw new ArgumentException("Email address is invalid.", nameof(value));

        Value = value;
    }
}
