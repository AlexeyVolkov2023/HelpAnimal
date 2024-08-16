namespace HelpAnimal.Domain.Models;

public record SocialNetwork
{
    public SocialNetwork()
    {
        
    }
    private SocialNetwork(string name, string link)
    {
        Name = name;
        Link = link;
    }

   public string? Name { get; } 
    public string? Link { get; } 

    public static SocialNetwork Create(string name, string link)
    {
        return new SocialNetwork(name, link);
    }
}