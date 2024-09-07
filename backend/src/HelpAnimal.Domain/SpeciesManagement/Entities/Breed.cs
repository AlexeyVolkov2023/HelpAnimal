using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.SpeciesManagement.ID;

namespace HelpAnimal.Domain.SpeciesManagement.Entities;

public class Breed : Shared.Entity<BreedId>
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
            return Result.Failure<Breed>("Title cannot be empty or whitespace.");
        }

        return Result.Success(new Breed(id, title));
    }
}