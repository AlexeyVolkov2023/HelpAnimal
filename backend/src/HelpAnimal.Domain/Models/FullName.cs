namespace HelpAnimal.Domain.Models;

public record FullName
{
    public const int NAME_MAX_LENGTH = 15;
    public const int SURNAME_MAX_LENGTH = 15;
    
    
    
    private FullName()
    {
    }

    private FullName(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public string Name { get; set; }
    public string Surname { get; set; }

    public static FullName Create(string name, string surname)
    {
        return new FullName(name, surname);
    }
    
}