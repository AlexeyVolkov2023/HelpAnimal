using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record Vaccination
{
   private Vaccination(
        string nameVaccine,
        DateTime dateVaccination)
    {
        NameVaccine = nameVaccine;
        DateVaccination = dateVaccination;
    }

    public string NameVaccine { get; }
    public DateTime DateVaccination { get;  }

    public static Result<Vaccination> Create(string nameVaccine, DateTime dateVaccination)
    {
        if (string.IsNullOrWhiteSpace(nameVaccine))
        {
            return "Name of vaccine cannot be empty or whitespace.";
        }
        if (dateVaccination > DateTime.Now)
        {
            return "Vaccination date cannot be in the future.";
        }

        return new Vaccination(nameVaccine, dateVaccination);
    }
}