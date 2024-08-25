using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public class Volunteer : Entity<Volunteerid>
{
    private Volunteer(Volunteerid id) : base(id)
    {
    }

    private Volunteer(
        Volunteerid volunteerid,
        FullName name,
        string description,
        int experienceYears,
        int adoptedAnimalsCount,
        int currentAnimalsCount,
        int animalsInTreatmentCount,
        PhoneNumber phone,
        SocialDetails socialNetwork,
        RequisiteDetails requisite,
        List<Animal> animals) : base(volunteerid)
    {
        FullName = name;
        Description = description;
        ExperienceYears = experienceYears;
        AdoptedAnimalsCount = adoptedAnimalsCount;
        CurrentAnimalsCount = currentAnimalsCount;
        AnimalsInTreatmentCount = animalsInTreatmentCount;
        Phone = phone;
        SocialNetworks = socialNetwork;
        RequisiteCollection = requisite;
        Animals = animals;
    }

    public FullName FullName { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public int ExperienceYears { get; private set; } // Опыт в годах
    public int AdoptedAnimalsCount { get; private set; } // Количество домашних животных, которые нашли дом
    public int CurrentAnimalsCount { get; private set; } // Количество домашних животных, которые ищут дом
    public int AnimalsInTreatmentCount { get; private set; } // Количество животных на лечении
    public PhoneNumber Phone { get; private set; }
    public SocialDetails? SocialNetworks { get; private set; }
    public RequisiteDetails? RequisiteCollection { get; private set; }
    public List<Animal>? Animals { get; private set; } = []; // Список домашних животных

    public static Result<Volunteer> Create(
        Volunteerid volunteerid,
        FullName name,
        string description,
        int experienceYears,
        int adoptedAnimalsCount,
        int currentAnimalsCount,
        int animalsInTreatmentCount,
        PhoneNumber phone,
        SocialDetails socialNetworks,
        RequisiteDetails requisite,
        List<Animal> animals)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.HIGH_TEXT_LENGTH)
        {
            return $"Description cannot be empty or separated by a space or be more than {Constants.HIGH_TEXT_LENGTH}";
        }

        if (experienceYears is > Constants.MAX_EXPERIENCE_YEARS or < 0)
        {
            return $"ExperienceYears could not be more {Constants.MAX_EXPERIENCE_YEARS}";
        }

        if (adoptedAnimalsCount < 0)
        {
            return "AdoptedAnimalsCount must be greater than 0.";
        }

        if (currentAnimalsCount < 0)
        {
            return "CurrentAnimalsCount must be greater than 0.";
        }

        if (animalsInTreatmentCount < 0)
        {
            return "AnimalsInTreatmentCount must be greater than 0.";
        }

        return new Volunteer(
            volunteerid,
            name,
            description,
            experienceYears,
            adoptedAnimalsCount,
            currentAnimalsCount,
            animalsInTreatmentCount,
            phone,
            socialNetworks,
            requisite,
            animals);
    }
}