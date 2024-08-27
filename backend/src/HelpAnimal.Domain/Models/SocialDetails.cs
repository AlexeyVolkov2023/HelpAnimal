namespace HelpAnimal.Domain.Models;

public record SocialDetails
{
    public List<SocialNetwork>? Networks { get; private set;}
}