namespace HelpAnimal.Domain.Models;

public record RequisiteDetails
{
    public List<Requisite> Requisites { get; private set; }
}