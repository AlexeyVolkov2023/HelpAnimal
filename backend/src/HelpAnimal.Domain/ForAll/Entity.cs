namespace HelpAnimal.Domain.ForAll;

public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; private set; }

    protected Entity(TId id) => Id = id;
    
}