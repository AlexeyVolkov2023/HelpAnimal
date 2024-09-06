using CSharpFunctionalExtensions;

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

    public static Result<Vaccination> Create(string nameVaccine, DateTime dateVaccination)
    {
        if (string.IsNullOrWhiteSpace(nameVaccine))
        {
            return Result.Failure<Vaccination>("Name of vaccine cannot be empty or whitespace.");
        }

        if (dateVaccination > DateTime.Now)
        {
            return Result.Failure<Vaccination>("Vaccination date cannot be in the future.");
        }

        return Result.Success(new Vaccination(nameVaccine, dateVaccination));
    }
}