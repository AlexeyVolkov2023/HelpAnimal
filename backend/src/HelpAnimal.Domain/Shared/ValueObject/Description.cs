using CSharpFunctionalExtensions;

namespace HelpAnimal.Domain.Shared.ValueObject;

public record Description
{
    private Description(string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static Result<Description, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) 
            || value.Length > Constants.HIGH_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Description");
        }

        return new Description(value);
    }
}