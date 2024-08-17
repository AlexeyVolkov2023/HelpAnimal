namespace HelpAnimal.Domain.Models;

public record Volunteerid
{
    private Volunteerid(Guid value)
    {
        Value = value;
    }

    public Guid Value { get;  }

    public static Volunteerid NewAnimalid() => new(Guid.NewGuid());

    public static Volunteerid Empty() => new(Guid.Empty);

    public static Volunteerid Create(Guid id) => new(id);
}