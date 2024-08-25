namespace HelpAnimal.Domain.Models;

public record Breedid
{
    private Breedid(Guid value) 
    {
        Value = value;
    }

    public Guid Value { get;  }

    public static Breedid NewBreedid() => new(Guid.NewGuid());

    public static Breedid Empty() => new(Guid.Empty);

    public static Breedid Create(Guid id) => new(id);
    
}