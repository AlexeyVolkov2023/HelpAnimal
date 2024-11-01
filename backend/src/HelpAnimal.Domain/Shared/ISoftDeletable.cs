namespace HelpAnimal.Domain.Shared;

public interface ISoftDeletable
{
    void Delete();
    void Restore();
}