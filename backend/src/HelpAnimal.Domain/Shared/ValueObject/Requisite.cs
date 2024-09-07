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


    public static Result<Requisite> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Requisite>("Title cannot be empty or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure<Requisite>("Description cannot be empty or whitespace.");
        }

        return Result.Success(new Requisite(title, description));
    }
}