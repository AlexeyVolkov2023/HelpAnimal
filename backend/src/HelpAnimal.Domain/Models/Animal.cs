using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public class Animal : Entity<Animalid>
{
    private Animal(Animalid id) : base(id)
    {
    }


    private Animal(
        Animalid animalid,
        string name,
        string description,
        IdentifierAnimal identifier,
        string color,
        string healthInfo,
        Address address,
        double weight,
        double height,
        PhoneNumber phone,
        bool isNeutered,
        DateTime dateOfBirth,
        VaccinationDetails alreadyVaccinated,
        HelpStatus status,
        RequisiteDetails requisites,
        AnimalPhotosDetails animalPhotos) : base(animalid)
    {
        Name = name;
        Description = description;
        Identifier = identifier;
        Color = color;
        HealthInfo = healthInfo;
        AnimalAddress = address;
        Weight = weight;
        Height = height;
        Phone = phone;
        IsNeutered = isNeutered;
        DateOfBirth = dateOfBirth;
        AlreadyVaccinated = alreadyVaccinated;
        Status = status;
        CreatedAt = DateTime.Now;
        RequisiteCollection = requisites;
        AnimalPhotos = animalPhotos;
    }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public IdentifierAnimal Identifier { get; private set; }
    public string Color { get; private set; } = default!;
    public string HealthInfo { get; private set; } = default!;
    public Address AnimalAddress { get; private set; } = default!;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public PhoneNumber Phone { get; private set; } // Номер телефона для связи с владельцем
    public bool IsNeutered { get; private set; } // Кастрирован или нет
    public DateTime DateOfBirth { get; private set; }
    public VaccinationDetails AlreadyVaccinated { get; private set; }
    public HelpStatus? Status { get; private set; } // Статус помощи
    public DateTime CreatedAt { get; set; }
    public AnimalPhotosDetails? AnimalPhotos { get; private set; }
    public RequisiteDetails? RequisiteCollection { get; private set; }


    public static Result<Animal> Create(
        Animalid animalid,
        string name,
        string description,
        IdentifierAnimal identifier,
        string color,
        string healthInfo,
        Address address,
        double weight,
        double height,
        PhoneNumber phone,
        bool isNeutered,
        DateTime dateOfBirth,
        VaccinationDetails alreadyVaccinated,
        HelpStatus status,
        RequisiteDetails requisites,
        AnimalPhotosDetails animalPhotos)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.NAME_MAX_LENGTH)
        {
            return $"Name cannot be empty or separated by a space or be more than {Constants.NAME_MAX_LENGTH}";
        }

        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.HIGH_TEXT_LENGTH)
        {
            return $"Description cannot be empty or separated by a space or be more than {Constants.HIGH_TEXT_LENGTH}";
        }

        if (string.IsNullOrWhiteSpace(color))
        {
            return "Color cannot be empty or whitespace.";
        }

        if (string.IsNullOrWhiteSpace(healthInfo) || healthInfo.Length > Constants.MEDIUM_TEXT_LENGTH)
        {
            return $"HealthInfo cannot be empty or separated by a space or be more than {Constants.HIGH_TEXT_LENGTH}";
        }

        if (weight <= 0)
        {
            return "Weight must be greater than 0.";
        }

        if (height <= 0)
        {
            return "Height must be greater than 0.";
        }

        if (dateOfBirth > DateTime.Now)
        {
            return "Date of birth cannot be in the future.";
        }


        return new Animal(
            animalid,
            name,
            description,
            identifier,
            color,
            healthInfo,
            address,
            weight,
            height,
            phone,
            isNeutered,
            dateOfBirth,
            alreadyVaccinated,
            status,
            requisites,
            animalPhotos);
    }
}