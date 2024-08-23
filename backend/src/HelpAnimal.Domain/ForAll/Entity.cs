namespace HelpAnimal.Domain.ForAll;

public abstract class Entity<TId> where TId : notnull
{
   protected Entity(TId id) => Id = id;
    public TId Id { get; private set; }
    
}