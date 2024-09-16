using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;
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


    public static Result<IdentifierAnimal, Error> Create(SpeciesId species, Guid breed)
    {
        return new IdentifierAnimal(species, breed);
    }
}