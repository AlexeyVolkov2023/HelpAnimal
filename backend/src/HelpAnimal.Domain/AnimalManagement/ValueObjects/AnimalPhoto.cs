using CSharpFunctionalExtensions;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

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
            return Result.Failure<AnimalPhoto>
                ("Storage path cannot be empty or whitespace.");
        }

        return Result.Success(new  AnimalPhoto(storagePath, isMain));
       
    }
}
