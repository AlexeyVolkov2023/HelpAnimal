using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record Email
{
    private const string EMAIL_REGEX_PATTERN = @"^[^@]+@[^@]+\.[^@]+$";
    
    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; }


    public static Result<Email, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) 
            || !Regex.IsMatch(value, EMAIL_REGEX_PATTERN))
        {
            return Errors.General.ValueIsInvalid("Email");
        }
        
        return new Email(value);
    }
}

