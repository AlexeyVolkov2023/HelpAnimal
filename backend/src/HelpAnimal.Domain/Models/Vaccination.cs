namespace HelpAnimal.Domain.Models;

public record Vaccination
{
    public Vaccination()
    {
    }

    private Vaccination(
        string nameVaccine,
        DateTime dateVaccination)
    {
        NameVaccine = nameVaccine;
        DateVaccination = dateVaccination;
    }

    public string NameVaccine { get; }
    public DateTime DateVaccination { get;  }

    public static Vaccination Create(
        string nameVaccine,
        DateTime dateVaccination)
    {
        return new Vaccination(
            nameVaccine, 
            dateVaccination);
    }
}