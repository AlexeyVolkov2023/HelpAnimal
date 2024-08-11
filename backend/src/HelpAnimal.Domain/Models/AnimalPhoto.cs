namespace HelpAnimal.Domain.Models;

public class AnimalPhoto
{
    public Guid Id { get; private set; }
    public string StoragePath { get; private set; } = default!;
    public bool IsMain { get; private set; }

    public static AnimalPhoto Create(string storagePath, bool isMain)
    {
        return new AnimalPhoto
        {
            StoragePath = storagePath,
            IsMain = isMain,
        };

    }
}
