namespace HelpAnimal.Domain.Models;
public class Volunteer
{
    public Guid Id { get;private set; } // Идентификатор
    public string FullName { get;private set; } 
    public string Description { get;private set; } 
    public int ExperienceYears { get;private set; } // Опыт в годах
    public int AdoptedAnimalsCount { get;private set; } // Количество домашних животных, которые нашли дом
    public int CurrentAnimalsCount { get;private set; } // Количество домашних животных, которые ищут дом
    public int AnimalsInTreatmentCount { get;private set; } // Количество животных на лечении
    public string PhoneNumber { get;private set; } 
    public List<SocialNetwork> SocialNetworks { get;private set; } // Список социальных сетей
    public List<HelpDetails> Requisite { get;private set; } 
    public List<Animal> Animals { get; set; } // Список домашних животных

    public static Volunteer Create(string fullName, string description, int experienceYears,
                                    int adoptedAnimalsCount, int currentAnimalsCount,
                                    int animalsInTreatmentCount, string phoneNumber,
                                    List<SocialNetwork> socialNetworks,
                                    List<HelpDetails> requisite,
                                    List<Animal> animals)
    {
        return new Volunteer
        {
            Id = new Guid(),
            FullName = fullName,
            Description = description,
            ExperienceYears = experienceYears,
            AdoptedAnimalsCount = adoptedAnimalsCount,
            CurrentAnimalsCount = currentAnimalsCount,
            AnimalsInTreatmentCount = animalsInTreatmentCount,
            PhoneNumber = phoneNumber,
            SocialNetworks = socialNetworks,
            Requisite = requisite,
            Animals = animals,
        };
    }
}
