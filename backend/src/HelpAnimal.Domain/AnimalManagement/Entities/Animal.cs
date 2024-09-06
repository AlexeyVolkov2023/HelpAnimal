using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Domain.AnimalManagement.Entities;

public class Animal : Shared.Entity<AnimalId>
{
    private Animal(AnimalId id) : base(id)
    {
    }


    private Animal(
        AnimalId id,
        AnimalData profile,
        IdentifierAnimal identifier,
        AnimalInformation information,
        Address address,
        PhoneNumber phone,
        DateTime dateOfBirth,
        VaccinationDetails alreadyVaccinated,
        HelpStatus status,
        RequisiteDetails requisites,
        AnimalPhotosDetails animalPhotos) : base(id)
    {
        Profile = profile;
        Identifier = identifier;
        Information = information;
        AnimalAddress = address;
        Phone = phone;
        DateOfBirth = dateOfBirth;
        AlreadyVaccinated = alreadyVaccinated;
        Status = status;
        CreatedAt = DateTime.Now;
        RequisiteCollection = requisites;
        AnimalPhotos = animalPhotos;
    }

    public AnimalData Profile { get; private set; }
    public IdentifierAnimal Identifier { get; private set; }
    public AnimalInformation Information { get; private set; }
    public Address AnimalAddress { get; private set; } = default!;
    public PhoneNumber Phone { get; private set; } // Номер телефона для связи с владельцем
    public DateTime DateOfBirth { get; private set; }
    public VaccinationDetails? AlreadyVaccinated { get; private set; }
    public HelpStatus Status { get; private set; } // Статус помощи
    public DateTime CreatedAt { get; set; }
    public AnimalPhotosDetails AnimalPhotos { get; private set; }
    public RequisiteDetails RequisiteCollection { get; private set; }


    public static Result<Animal> Create(
        AnimalId id,
        AnimalData profile,
        IdentifierAnimal identifier,
        AnimalInformation information,
        Address address,
        PhoneNumber phone,
        DateTime dateOfBirth,
        VaccinationDetails alreadyVaccinated,
        HelpStatus status,
        RequisiteDetails requisites,
        AnimalPhotosDetails animalPhotos)
    {
        if (dateOfBirth > DateTime.Now)
        {
            return Result.Failure<Animal>("Date of birth cannot be in the future.");
        }


        return Result.Success(new Animal(
            id,
            profile,
            identifier,
            information,
            address,
            phone,
            dateOfBirth,
            alreadyVaccinated,
            status,
            requisites,
            animalPhotos));
    }
}