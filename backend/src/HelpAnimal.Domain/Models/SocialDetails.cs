namespace HelpAnimal.Domain.Models;

public record SocialDetails
{
    public IReadOnlyList<SocialNetwork>? Networks { get; }
}