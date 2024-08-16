namespace HelpAnimal.Domain.Models;

public record AnimalPhoto
{
    public AnimalPhoto()
    {
        
    }
    private AnimalPhoto(string storagePath, bool isMain)
    {
        StoragePath = storagePath;
        IsMain = isMain;
    }

    public string StoragePath { get; } = default!;
    public bool IsMain { get; }

    public static AnimalPhoto Create(string storagePath, bool isMain)
    {
        return new AnimalPhoto(storagePath, isMain);
    }
}
