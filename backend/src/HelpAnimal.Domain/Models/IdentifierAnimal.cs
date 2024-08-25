using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record IdentifierAnimal
{
    public IdentifierAnimal()
    {
    }

    public IdentifierAnimal(Speciesid speciesId, Guid breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }
    
    public Speciesid SpeciesId { get; }
    public Guid BreedId { get; }
    
    
    public static Result<IdentifierAnimal> Create(Speciesid speciesId, Guid breedId)
    {
        return new IdentifierAnimal(speciesId, breedId);
    }
}