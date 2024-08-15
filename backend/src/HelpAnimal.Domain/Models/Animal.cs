namespace HelpAnimal.Domain.Models;

public class Animal
{
    public Animal()
    {
    }
    
     private Animal(string name, string species, string description,
                     string breed, string color, string healthInfo, string address,
                     double weight, double height, string ownerContactNumber, 
                     bool isNeutered, DateTime dateOfBirth, bool isVaccinated, 
                     HelpStatus status, List<HelpDetail> requisite, List<AnimalPhoto> photos)
    {
        Name = name;
        Species = species;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        OwnerContactNumber = ownerContactNumber;
        IsNeutered = isNeutered;
        DateOfBirth = dateOfBirth;
        IsVaccinated = isVaccinated;
        Status = status;
        CreatedAt = DateTime.Now;
        Requisite = requisite;
        Photos = photos;
    }

    

    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string Species { get; private set; } = default!;// Вид (собака, кошка и т.д.)
    public string Description { get; private set; } = default!;
    public string Breed { get;private set; } = default!;// Порода
    public string Color { get;private set; } = default!;
    public string HealthInfo { get;private set; } = default!;
    public string Address { get;private set; } = default!;
    public double Weight { get;private set; } 
    public double Height { get;private set; } 
    public string OwnerContactNumber { get;private set; } = default!;// Номер телефона для связи с владельцем
    public bool IsNeutered { get;private set; } // Кастрирован или нет
    public DateTime DateOfBirth { get;private set; } 
    public bool IsVaccinated { get;private set; } 
    public HelpStatus Status { get;private set; } // Статус помощи
    public DateTime CreatedAt { get; set; }
    public List<AnimalPhoto> Photos { get; private set; } = []; 
    public List<HelpDetail> Requisite { get; private set; } = [];
    
    
    
    
   
        public static Animal Create(string name, string species, string description,
                                        string breed, string color, string healthInfo,
                                        string address, double weight, double height,
                                        string ownerContactNumber, bool isNeutered,
                                        DateTime dateOfBirth, bool isVaccinated,
                                        HelpStatus status, List<HelpDetail> requisite,
                                        List<AnimalPhoto> photos)
        {
            return new Animal(name, species, description, breed, color, healthInfo,
                address, weight, height, ownerContactNumber, isNeutered,
                dateOfBirth, isVaccinated, status, requisite, photos);
        }
    }
