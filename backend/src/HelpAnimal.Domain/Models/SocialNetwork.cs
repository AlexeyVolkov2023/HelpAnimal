namespace HelpAnimal.Domain.Models;

public class SocialNetwork
{
    private SocialNetwork(string name, string link)
    {
        Name = name;
        Link = link;
    }

    public string Name { get;private set; } // Название социальной сети
    public string Link { get;private set; } // Ссылка на профиль

    public static SocialNetwork Create(string name, string link)
    {
        return new SocialNetwork(name, link);
    }
}