namespace HelpAnimal.Domain.Models;

public class Animal
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = String.Empty;
    public string Species { get; private set; } = String.Empty;// Вид (собака, кошка и т.д.)
    public string Description { get; private set; } = String.Empty;
    public string Breed { get;private set; } = String.Empty;// Порода
    public string Color { get;private set; } = String.Empty;
    public string HealthInfo { get;private set; } = String.Empty;
    public string Address { get;private set; } = String.Empty;
    public double Weight { get;private set; } 
    public double Height { get;private set; } 
    public string OwnerContactNumber { get;private set; } = String.Empty;// Номер телефона для связи с владельцем
    public bool IsNeutered { get;private set; } // Кастрирован или нет
    public DateTime DateOfBirth { get;private set; } 
    public bool IsVaccinated { get;private set; } 
    public HelpStatus Status { get;private set; } // Статус помощи
    public List<HelpDetails> HelpDetails { get;private set; } // Реквизиты для помощи
    public DateTime CreatedAt { get; set; } 

    
    public static Animal Create (string name, string species, string description,
                                       string breed, string color, string healthInfo,
                                       string address, double weight, double height,
                                       string ownerContactNumber, bool isNeutered,
                                       DateTime dateOfBirth, bool isVaccinated,
                                       HelpStatus status, List<HelpDetails> helpDetails)
    {
        return new Animal
        {
            Id = Guid.NewGuid(),
            Name = name,
            Species = species,
            Description = description,
            Breed = breed,
            Color = color,
            HealthInfo = healthInfo,
            Address = address,
            Weight = weight,
            Height = height,
            OwnerContactNumber = ownerContactNumber,
            IsNeutered = isNeutered,
            DateOfBirth = dateOfBirth,
            IsVaccinated = isVaccinated,
            Status = status,
            HelpDetails = helpDetails,
            CreatedAt = DateTime.Now,
        };
    }
}