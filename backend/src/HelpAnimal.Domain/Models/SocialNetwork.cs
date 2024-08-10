namespace HelpAnimal.Domain.Models;

public class SocialNetwork
{
    public string Name { get;private set; } // Название социальной сети
    public string Link { get;private set; } // Ссылка на профиль

    public SocialNetwork(string name, string link)
    {
        Name = name;
        Link = link;
    }
}