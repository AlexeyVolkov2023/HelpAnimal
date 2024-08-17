

namespace HelpAnimal.Domain.Models;

public record Animalid 
{
    private Animalid(Guid value) 
    {
        Value = value;
    }

    public Guid Value { get;  }

    public static Animalid NewAnimalid() => new(Guid.NewGuid());

    public static Animalid Empty() => new(Guid.Empty);

    public static Animalid Create(Guid id) => new(id);
}

