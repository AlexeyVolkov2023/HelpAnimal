namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record SocialDetails
{
    private SocialDetails()
    {
    }

    public SocialDetails(List<SocialNetwork>? networks)
    {
        Networks = networks;
    }

    public IReadOnlyList<SocialNetwork>? Networks { get; }
}