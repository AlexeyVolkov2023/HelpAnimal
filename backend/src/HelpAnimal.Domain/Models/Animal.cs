namespace HelpAnimal.Domain.Models;

public class Animal
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Species { get; set; } = String.Empty;// Вид (собака, кошка и т.д.)
    public string Description { get; set; } = String.Empty;
    public string Breed { get; set; } = String.Empty;// Порода
    public string Color { get; set; } = String.Empty;
    public string HealthInfo { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    public double Weight { get; set; } 
    public double Height { get; set; } 
    public string OwnerContactNumber { get; set; } = String.Empty;// Номер телефона для связи с владельцем
    public bool IsNeutered { get; set; } // Кастрирован или нет
    public DateTime DateOfBirth { get; set; } 
    public bool IsVaccinated { get; set; } 
    public HelpStatus Status { get; set; } // Статус помощи
    public HelpDetails HelpDetails { get; set; } // Реквизиты для помощи
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    
    public static Animal Create (Guid id, string name, string species, string description,
                                       string breed, string color, string healthInfo,
                                       string address, double weight, double height,
                                       string ownerContactNumber, bool isNeutered,
                                       DateTime dateOfBirth, bool isVaccinated,
                                       HelpStatus status, HelpDetails helpDetails)
    {
        return new Animal
        {
            Id = id,
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
        };
    }
}