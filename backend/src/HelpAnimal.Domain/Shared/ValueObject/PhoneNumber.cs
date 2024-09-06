using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace HelpAnimal.Domain.Shared.ValueObject;

public record PhoneNumber
{
    private PhoneNumber(string number)
    {
        Number = number;
    }

    public string Number { get; }


    public static Result<PhoneNumber, Error> Create(string number)
    {
        const string PHONE_NUMBER_REGEX = @"^\+?\d{10,15}$";

        if (string.IsNullOrWhiteSpace(number))
        {
            return Errors.General.ValueIsInvalid("Number");
        }

        if (!Regex.IsMatch(number, PHONE_NUMBER_REGEX))
        {
            return Errors.General.ValueIsInvalid("Number");
        }

        return new PhoneNumber(number);
    }
}