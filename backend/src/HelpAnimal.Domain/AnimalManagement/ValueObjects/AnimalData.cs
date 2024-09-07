using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record AnimalData
{
    public AnimalData(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }


    public static Result<AnimalData, Error> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name) 
            || name.Length > Constants.NAME_MAX_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Name");
        }

        if (string.IsNullOrWhiteSpace(description) 
            || description.Length > Constants.HIGH_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid($"Description");
        }

        return new AnimalData(name, description);

    }
}
