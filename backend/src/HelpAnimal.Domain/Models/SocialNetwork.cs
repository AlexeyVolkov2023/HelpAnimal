namespace HelpAnimal.Domain.Models;

public class SocialNetwork
{
    private SocialNetwork(string name, string link)
    {
        Name = name;
        Link = link;
    }

    public Guid Id { get; private set; }
    public string Name { get;private set; } 
    public string Link { get;private set; } 

    public static SocialNetwork Create(string name, string link)
    {
        return new SocialNetwork(name, link);
    }
}