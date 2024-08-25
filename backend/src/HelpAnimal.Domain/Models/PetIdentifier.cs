using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record PetIdentifier
{
    public PetIdentifier()
    {
    }

    private PetIdentifier(Speciesid species, Guid breedid)
    {
        IdSpecies = species;
        IdBreed = breedid;
    }
    public Speciesid IdSpecies{ get; }
    public Guid IdBreed { get; }

    public static Result<PetIdentifier> Create(Speciesid species, Guid breedid)
    {
        return new PetIdentifier(species, breedid);
    }
}