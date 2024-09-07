using CSharpFunctionalExtensions;

namespace HelpAnimal.Domain.Shared.ValueObject;

public record Requisite
{
    private Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; }
    public string Description { get; }


    public static Result<Requisite, Error> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Errors.General.ValueIsInvalid("Title requisite");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return Errors.General.ValueIsInvalid("Description requisite");
        }

        return new Requisite(title, description);
    }
}