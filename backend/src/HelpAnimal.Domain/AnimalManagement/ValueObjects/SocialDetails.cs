namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record SocialDetails
{
    private SocialDetails()
    {
    }

    public SocialDetails(IEnumerable<SocialNetwork>? networks)
    {
        Networks = networks.ToList();
    }

    public IReadOnlyList<SocialNetwork>? Networks { get; }
}