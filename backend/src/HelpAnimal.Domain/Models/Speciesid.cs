namespace HelpAnimal.Domain.Models;

public record Speciesid 
{
    private Speciesid(Guid value) 
    {
        Value = value;
    }

    public Guid Value { get;  }

    public static Speciesid NewSpeciesid() => new(Guid.NewGuid());

    public static Speciesid Empty() => new(Guid.Empty);

    public static Speciesid Create(Guid id) => new(id);
}