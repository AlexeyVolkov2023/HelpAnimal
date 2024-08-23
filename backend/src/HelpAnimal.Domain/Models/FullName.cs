using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record FullName
{
   public const int SURNAME_MAX_LENGTH = 15;
    
    private FullName(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public string Name { get; set; }
    public string Surname { get; set; }

    public static  Result<FullName> Create(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.NAME_MAX_LENGTH)
        {
            return $"Name cannot be empty or separated by a space or be more than {Constants.NAME_MAX_LENGTH}";
        }

        if (string.IsNullOrWhiteSpace(surname) || surname.Length > SURNAME_MAX_LENGTH)
        {
            return $"Name cannot be empty or separated by a space or be more than {SURNAME_MAX_LENGTH}";
        }

        return new FullName(name, surname);
       
    }
    
}