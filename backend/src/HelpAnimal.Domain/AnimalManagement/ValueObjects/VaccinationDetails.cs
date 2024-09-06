namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public class VaccinationDetails
{
    private VaccinationDetails()
    {
    }

    public VaccinationDetails(List<Vaccination> vaccinations)
    {
        Vaccinations = vaccinations;
    }

    public IReadOnlyList<Vaccination> Vaccinations { get;  }
}