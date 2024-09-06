namespace HelpAnimal.Domain.Shared.ValueObject;

public record RequisiteDetails
{
    private RequisiteDetails()
    {
    }

    public RequisiteDetails(List<Requisite> requisites)
    {
        Requisites = requisites;
    }

    public IReadOnlyList<Requisite> Requisites { get; }
}