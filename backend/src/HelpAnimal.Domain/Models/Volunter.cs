﻿namespace HelpAnimal.Domain.Models;
public class Volunteer
{
    private  Volunteer()
    {
       
        
    }

    private Volunteer(string fullName, string description, int experienceYears,
                        int adoptedAnimalsCount, int currentAnimalsCount,
                        int animalsInTreatmentCount, string phoneNumber,
                        SocialDetails socialNetwork, RequisiteDetails requisite,
                        List<Animal> animals)
    {
        FullName = fullName;
        Description = description;
        ExperienceYears = experienceYears;
        AdoptedAnimalsCount = adoptedAnimalsCount;
        CurrentAnimalsCount = currentAnimalsCount;
        AnimalsInTreatmentCount = animalsInTreatmentCount;
        PhoneNumber = phoneNumber;
        SocialNetworks = socialNetwork;
        RequisiteCollection = requisite;
        Animals = animals;
    }

    public Guid Id { get;private set; } // Идентификатор
    public string FullName { get; private set; } = default!;
    public string Description { get;private set; } = default!;
    public int ExperienceYears { get;private set; } // Опыт в годах
    public int AdoptedAnimalsCount { get;private set; } // Количество домашних животных, которые нашли дом
    public int CurrentAnimalsCount { get;private set; } // Количество домашних животных, которые ищут дом
    public int AnimalsInTreatmentCount { get;private set; } // Количество животных на лечении
    public string PhoneNumber { get;private set; } = default!;
    public SocialDetails SocialNetworks { get; private set; } 
    public RequisiteDetails RequisiteCollection { get;private set; } 
    public List<Animal> Animals { get;private set; }  = [];// Список домашних животных

    public static Volunteer Create(string fullName, string description, int experienceYears,
                                    int adoptedAnimalsCount, int currentAnimalsCount,
                                    int animalsInTreatmentCount, string phoneNumber,
                                    SocialDetails socialNetworks,
                                    RequisiteDetails requisite,
                                    List<Animal> animals)
    {
        return new Volunteer(fullName, description, experienceYears, adoptedAnimalsCount,
                                currentAnimalsCount, animalsInTreatmentCount, phoneNumber, 
                                socialNetworks, requisite, animals);
    }
}
