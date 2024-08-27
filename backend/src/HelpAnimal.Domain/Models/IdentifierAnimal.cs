using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

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
        return new IdentifierAnimal(species, breed);
    }
}