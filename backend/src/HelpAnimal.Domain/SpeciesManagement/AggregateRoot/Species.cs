using CSharpFunctionalExtensions;
using HelpAnimal.Domain.SpeciesManagement.Entities;
using HelpAnimal.Domain.SpeciesManagement.ID;

namespace HelpAnimal.Domain.SpeciesManagement.AggregateRoot;

public class Species : Shared.Entity<SpeciesId>
{
    public const int MAX_TITLE_SPECIES_LENGTH = 15;
    
    private Species(SpeciesId id) : base(id)
    {
    }
    private Species(string title, SpeciesId id, List<Breed> breeds) : base(id)
    {
        Title = title;
        Breeds = breeds;
    }

    public string Title { get;  } 
    public List<Breed>? Breeds { get;  } = []; 

    
    public static Result<Species> Create(string title, SpeciesId id, List<Breed> breeds)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_SPECIES_LENGTH)
        {
            return Result.Failure<Species>(
                $"Description cannot be empty or separated by a space or" +
                $" be more than {MAX_TITLE_SPECIES_LENGTH}");
        }
        
        return Result.Success(new Species(title,id, breeds));
    }
}