using CSharpFunctionalExtensions;
using HelpAnimal.Domain.SpeciesManagement.ID;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record IdentifierAnimal
{
    private IdentifierAnimal()
    {
    }

    private IdentifierAnimal(SpeciesId species, Guid breed)
    {
        SpeciesIdentifier = species;
        BreedGuid = breed;
    }

    public SpeciesId SpeciesIdentifier { get; }
    public Guid BreedGuid { get; }


    public static Result<IdentifierAnimal> Create(SpeciesId species, Guid breed)
    {
        return Result.Success(new IdentifierAnimal(species, breed));
    }
}