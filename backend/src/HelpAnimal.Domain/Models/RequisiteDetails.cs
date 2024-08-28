namespace HelpAnimal.Domain.Models;

public record RequisiteDetails
{
    public IReadOnlyList<Requisite> Requisites { get; }
}