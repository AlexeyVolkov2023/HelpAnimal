using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record AnimalPhoto
{
    private AnimalPhoto(string storagePath, bool isMain)
    {
        StoragePath = storagePath;
        IsMain = isMain;
    }

    public string StoragePath { get; } 
    public bool IsMain { get; }

    public static Result<AnimalPhoto> Create(string storagePath, bool isMain)
    {
        if (string.IsNullOrWhiteSpace(storagePath))
        {
            return "Storage path cannot be empty or whitespace.";
        }

        return new AnimalPhoto(storagePath, isMain);
       
    }
}
