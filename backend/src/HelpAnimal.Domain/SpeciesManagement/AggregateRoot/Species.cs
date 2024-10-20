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
    private Species(string title, SpeciesId id) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }
    public IReadOnlyList<Breed>? Breeds => _breeds;

    private readonly List<Breed> _breeds;
    

    
    public static Result<Species> Create(string title, SpeciesId id)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_SPECIES_LENGTH)
        {
            return Result.Failure<Species>(
                $"Description cannot be empty or separated by a space or" +
                $" be more than {MAX_TITLE_SPECIES_LENGTH}");
        }
        
        return Result.Success(new Species(title,id));
    }
}