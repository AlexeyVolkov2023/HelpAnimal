namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public class VaccinationDetails
{
    private VaccinationDetails()
    {
    }

    public VaccinationDetails(IEnumerable<Vaccination> vaccinations)
    {
        Vaccinations = vaccinations.ToList();
    }

    public IReadOnlyList<Vaccination> Vaccinations { get;  }
}