using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public class AnimalData
{
    public AnimalData(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }


    public static Result<AnimalData> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.NAME_MAX_LENGTH)
        {
            return Result.Failure<AnimalData>(
                $"Name cannot be empty or separated by a space or" +
                $" be more than {Constants.NAME_MAX_LENGTH}");
        }

        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.HIGH_TEXT_LENGTH)
        {
            return Result.Failure<AnimalData>(
                $"Description cannot be empty or separated by a space or " +
                $"be more than {Constants.HIGH_TEXT_LENGTH}");
        }

        return Result.Success(new AnimalData(name, description));

    }
}
