using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record Vaccination
{
    private Vaccination(string nameVaccine, DateTime dateVaccination)
    {
        NameVaccine = nameVaccine;
        DateVaccination = dateVaccination;
    }

    public string NameVaccine { get; }
    public DateTime DateVaccination { get; }

    public static Result<Vaccination, Error> Create(string nameVaccine, DateTime dateVaccination)
    {
        if (string.IsNullOrWhiteSpace(nameVaccine))
        {
            return Errors.General.ValueIsInvalid("Name of vaccine");
        }

        if (dateVaccination > DateTime.Now)
        {
            return Errors.General.ValueIsInvalid("Vaccination date");
        }

        return new Vaccination(nameVaccine, dateVaccination);
    }
}