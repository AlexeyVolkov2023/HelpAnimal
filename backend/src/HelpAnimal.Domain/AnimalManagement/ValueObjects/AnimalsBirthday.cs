using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record AnimalsBirthday 
{
    private AnimalsBirthday(DateTime birthday)
    {
        Birthday = birthday;
    }
    
    public DateTime Birthday { get; }

    public static Result<AnimalsBirthday, Error> Create(DateTime birthday)
    {
        if (birthday > DateTime.Now)
        {
            return Errors.General.ValueIsInvalid("Birthday");
        }

        return new AnimalsBirthday(birthday);
    }
}