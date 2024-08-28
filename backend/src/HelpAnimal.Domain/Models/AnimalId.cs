

using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record AnimalId 
{
    private AnimalId(Guid value) 
    {
        Value = value;
    }

    public Guid Value { get;  }

    public static AnimalId NewAnimalId() => new(Guid.NewGuid());

    public static AnimalId Empty() => new(Guid.Empty);

    public static AnimalId Create(Guid id) => new(id);
}

