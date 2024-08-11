namespace HelpAnimal.Domain.Models;

public class SocialNetwork
{
    public string Name { get;private set; } // Название социальной сети
    public string Link { get;private set; } // Ссылка на профиль

    public static SocialNetwork Create(string name, string link)
    {
        return new SocialNetwork()
        {
            Name = name,
            Link = link,
        };
    }
}