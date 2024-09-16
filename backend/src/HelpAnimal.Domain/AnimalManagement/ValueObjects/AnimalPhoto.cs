using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

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

    public static Result<AnimalPhoto, Error> Create(string storagePath, bool isMain)
    {
        if (string.IsNullOrWhiteSpace(storagePath))
        {
            return Errors.General.ValueIsInvalid("Storage path");
        }

        return new  AnimalPhoto(storagePath, isMain);
       
    }
}
