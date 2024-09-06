using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record FullName
{
    public const int SURNAME_MAX_LENGTH = 15;
    public const int PATRONYMIC_MAX_LENGTH = 15;


    private FullName(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public string Name { get; }
    public string Surname { get; }
    public string? Patronymic { get; }

    public static Result<FullName, Error> Create(
        string name, 
        string surname,
        string patronymic)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.NAME_MAX_LENGTH)
        {
           return Errors.General.ValueIsInvalid("Name");
        }

        if (string.IsNullOrWhiteSpace(surname) || surname.Length > SURNAME_MAX_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Surname");
        }

        if (string.IsNullOrWhiteSpace(patronymic) || patronymic.Length > PATRONYMIC_MAX_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Patronymic");
        }


        return new FullName(name, surname, patronymic);
    }
}