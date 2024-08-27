using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public class Breed : Entity<BreedId>
{
    private Breed(BreedId id) : base(id)
    {
    }

    private Breed(BreedId id, string title) : base(id)
    {
        Title = title;
    }

    public string? Title { get; private set; }


    public static Result<Breed> Create(BreedId id, string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.LOW_TEXT_LENGTH)
        {
            return "Title cannot be empty or whitespace.";
        }

        return new Breed(id, title);
    }
}