namespace HelpAnimal.Domain.Shared.ValueObject;

public record RequisiteDetails
{
    private RequisiteDetails()
    {
    }

    public RequisiteDetails(IEnumerable<Requisite> requisites)
    {
        Requisites = requisites.ToList();
    }

    public IReadOnlyList<Requisite> Requisites { get; }
}